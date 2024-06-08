#include "projectstageview.h"

#define remap( value, low1, high1, low2, high2 ) ( low2 + ( value - low1 ) * ( high2 - low2 ) / ( high1 - low1 ) )

ProjectStageView::ProjectStageView(ProjectData* projectData, QWidget *parent)
    : QOpenGLWidget(parent)
    , QOpenGLFunctions_3_2_Core()
    , project(projectData)
{
}

ProjectStageView::~ProjectStageView()
{
}

void ProjectStageView::initializeGL()
{
    if (!this->initializeOpenGLFunctions())
    {
        QMessageBox::critical(this, tr("Error"), tr("Unable to initialize OpenGL 3.2 Core context!"));
        return; // and probably crash right after
    }

    this->mainShader.addShaderFromSourceFile(QOpenGLShader::Vertex, ":/shaders/main.vert");
    this->mainShader.addShaderFromSourceFile(QOpenGLShader::Fragment, ":/shaders/main.frag");
    this->mainShader.link();

#define CANVAS_SCALE 100
    // create the stage backdrop
    float stageWidthH = (project->stageWidth / 2) / CANVAS_SCALE;
    float stageHeightH = (project->stageHeight / 2) / CANVAS_SCALE;

    QList<StageVertex> stageVerts = {
        StageVertex(QVector3D(-stageWidthH,  stageHeightH, 0), QVector3D(1, 0, 1), QVector2D(0, 0)),
        StageVertex(QVector3D( stageWidthH,  stageHeightH, 0), QVector3D(1, 1, 1), QVector2D(1, 0)),
        StageVertex(QVector3D( stageWidthH, -stageHeightH, 0), QVector3D(1, 1, 1), QVector2D(1, 1)),
        StageVertex(QVector3D(-stageWidthH, -stageHeightH, 0), QVector3D(1, 1, 1), QVector2D(0, 1))
    };
#undef CANVAS_SCALE

    QList<unsigned short> indices = {
        0, 1, 2,
        2, 3, 0
    };

    this->vertexCount = static_cast<int>(stageVerts.size());
    this->vertices.create();
    this->vertices.bind();
    this->vertices.setUsagePattern(QOpenGLBuffer::StaticDraw);
    this->vertices.allocate(stageVerts.constData(), static_cast<int>(this->vertexCount * sizeof(StageVertex)));
    this->vertices.release();

    this->indexCount = static_cast<int>(indices.size());
    this->ebo.create();
    this->ebo.bind();
    this->ebo.allocate(indices.constData(), static_cast<int>(this->indexCount * sizeof(unsigned short)));
    this->ebo.release();
}

void ProjectStageView::paintGL()
{
    QStyleOption opt;
    opt.initFrom(this);

    auto clearColor = opt.palette.color(QPalette::ColorRole::Window);
    this->glClearColor(clearColor.redF(), clearColor.greenF(), clearColor.blueF(), clearColor.alphaF());
    this->glClear(GL_COLOR_BUFFER_BIT);

    this->glEnable(GL_MULTISAMPLE);
    this->glDisable(GL_CULL_FACE);
    this->glPolygonMode(GL_FRONT_AND_BACK, GL_FILL);

    this->mainShader.bind();

    float aspect = (float)this->width() / (float)this->height();

    QMatrix4x4 projectionMatrix = {
                                   1, 0.0f, 0.0f, 0.0f,
                                   0.0f, 1, 0.0f, 0.0f,
                                   0.0f, 0.0f, 1.0f, 0.0f,
                                   0.0f, 0.0f, 0.0f, 1.0f };

    // TODO: figure this out properly, this feels terrible.
    int startWidht = this->width();
    int startHeight = this->height();

    // this literally does nothing????????
    float scalarX = (float)startWidht / this->width();
    float scalarY = (float)startHeight / this->height();

    float zoomFactor = 1 / cameraZoom;
    if (zoomFactor > 10)
        zoomFactor = 10;

    if (zoomFactor < 0.00000001)
        zoomFactor = 0.00000001;

    float xSpan = zoomFactor;
    float ySpan = zoomFactor;

    if (aspect > 1)
    {
        xSpan *= aspect;
    }
    else
    {
        ySpan = xSpan / aspect;
    }

    projectionMatrix.ortho(-1 * xSpan, xSpan, -1 * ySpan, ySpan, -0, 1);

    this->mainShader.setUniformValue("uMVP", projectionMatrix);

    float offs = (0.5f / aspect);
    QVector2D offsets = {
                                                // this just eqates to 0?????
        remap(xOffset_, 0, 4096, offs * (cameraZoom + (1 - scalarX)), -offs * (cameraZoom + (1 - scalarX))),
        remap(yOffset_, 0, 4096, -offs * (cameraZoom + (1 - scalarY)), offs * (cameraZoom + (1 - scalarY)))
    };

    int OFFSETProcessing = this->mainShader.uniformLocation("OFFSET");

    this->mainShader.setUniformValue(OFFSETProcessing, offsets);

    this->vertices.bind();
    this->ebo.bind();

    int offset = 0;
    int vertexPosLocation = this->mainShader.attributeLocation("vPos");
    this->mainShader.enableAttributeArray(vertexPosLocation);
    this->mainShader.setAttributeBuffer(vertexPosLocation, GL_FLOAT, offset, 3, sizeof(StageVertex));

    offset += sizeof(QVector3D);
    int vertexNormalLocation = this->mainShader.attributeLocation("vColor");
    this->mainShader.enableAttributeArray(vertexNormalLocation);
    this->mainShader.setAttributeBuffer(vertexNormalLocation, GL_FLOAT, offset, 3, sizeof(StageVertex));

    offset += sizeof(QVector3D);
    int vertexUVLocation = this->mainShader.attributeLocation("vUV");
    this->mainShader.enableAttributeArray(vertexUVLocation);
    this->mainShader.setAttributeBuffer(vertexUVLocation, GL_FLOAT, offset, 2, sizeof(StageVertex));

    this->glDrawElements(GL_TRIANGLES, this->indexCount, GL_UNSIGNED_SHORT, nullptr);
    this->ebo.release();

    this->vertices.release();
    this->mainShader.release();

    this->timer.start(12, this);
}

void ProjectStageView::resizeGL(int width, int height)
{
    this->glViewport(0, 0, width, height);
}

void ProjectStageView::wheelEvent(QWheelEvent* event) {
    if ( event->angleDelta().y() > 0 ) // up Wheel
    {
        this->cameraZoom += 0.1f;
        this->cameraZoom = std::clamp(this->cameraZoom, 0.01f, 4.0f);
        this->update();
    }
    else if ( event->angleDelta().y() < 0 ) // down Wheel
    {
        this->cameraZoom -= 0.1f;
        this->cameraZoom = std::clamp(this->cameraZoom, 0.01f, 4.0f);
        this->update();
    }
    event->accept();
}

void ProjectStageView::timerEvent(QTimerEvent* /*event*/) {
    this->update();
}
