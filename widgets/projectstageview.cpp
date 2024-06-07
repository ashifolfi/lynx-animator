#include "projectstageview.h"

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

    // create the stage backdrop
    QList<StageVertex> stageVerts = {
        StageVertex(QVector3D(-(project->stageWidth / 2), -(project->stageHeight / 2), 0), QVector3D(1, 1, 1), QVector2D(0, 0)),
        StageVertex(QVector3D( (project->stageWidth / 2), -(project->stageHeight / 2), 0), QVector3D(1, 1, 1), QVector2D(1, 0)),
        StageVertex(QVector3D( (project->stageWidth / 2),  (project->stageHeight / 2), 0), QVector3D(1, 1, 1), QVector2D(1, 1)),
        StageVertex(QVector3D(-(project->stageWidth / 2),  (project->stageHeight / 2), 0), QVector3D(1, 1, 1), QVector2D(0, 1))
    };

    QList<unsigned short> indices = {
        0, 3, 2,
        2, 1, 0
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

    QMatrix4x4 view;
    QVector3D translation(0, 0, 0);
    view.translate(translation);
    view.rotate(QQuaternion(0,0,0,0));
    this->mainShader.setUniformValue("uMVP", this->projection * view);

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
    this->projection.setToIdentity();
    this->projection.ortho(
        cameraZoom * -(project->stageWidth / 2),
        cameraZoom *  (project->stageWidth / 2),
        cameraZoom *  (project->stageHeight / 2),
        cameraZoom * -(project->stageHeight / 2),
        0, -20000);
}

void ProjectStageView::wheelEvent(QWheelEvent* event) {
    if (QPoint numDegrees = event->angleDelta() / 8; !numDegrees.isNull()) {
        this->cameraZoom -= static_cast<float>(numDegrees.y()) * this->distanceScale;

        this->cameraZoom = std::clamp(this->cameraZoom, 0.5f, 4.0f);

        this->projection.setToIdentity();
        this->projection.ortho(
            cameraZoom * -(project->stageWidth / 2),
            cameraZoom *  (project->stageWidth / 2),
            cameraZoom *  (project->stageHeight / 2),
            cameraZoom * -(project->stageHeight / 2),
            0, -20000);
        this->update();
    }
    event->accept();
}

void ProjectStageView::timerEvent(QTimerEvent* /*event*/) {
    this->update();
}
