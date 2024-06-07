#ifndef PROJECTSTAGEVIEW_H
#define PROJECTSTAGEVIEW_H

#include <QWidget>

#include <QWheelEvent>
#include <QMouseEvent>
#include <QTabletEvent>
#include <QtOpenGL/QOpenGLBuffer>
#include <QtOpenGL/QOpenGLFunctions_3_2_Core>
#include <QtOpenGL/QOpenGLShaderProgram>
#include <QtOpenGL/QOpenGLTexture>
#include <QtOpenGL/QOpenGLVertexArrayObject>
#include <QtOpenGLWidgets/QtOpenGLWidgets>

#include "../ProjectData.hpp"

#pragma pack(push, 1)
struct StageVertex
{
    StageVertex(QVector3D pos_, QVector3D color_, QVector2D uv_)
        : pos(pos_)
        , color(color_)
        , uv(uv_) {}

    QVector3D pos;
    QVector3D color;
    QVector2D uv;
};
#pragma pack(pop)

struct StageMesh
{
    QOpenGLBuffer ebo{QOpenGLBuffer::Type::IndexBuffer};
    int indexCount;
};

// special thanks to craftablescience's VPKEdit for assistance in learning how QtOpenGL works.
class ProjectStageView : public QOpenGLWidget, protected QOpenGLFunctions_3_2_Core
{
    Q_OBJECT

public:
    explicit ProjectStageView(ProjectData* projectData, QWidget *parent = nullptr);
    ~ProjectStageView();

    ProjectData* GetProjectData() { return this->project; };

protected:
    void initializeGL() override;
    void resizeGL(int w, int h) override;
    void paintGL() override;
    //void mousePressEvent(QMouseEvent* event) override;
    //void mouseReleaseEvent(QMouseEvent* event) override;
    //void mouseMoveEvent(QMouseEvent* event) override;
    void wheelEvent(QWheelEvent* event) override;
    void timerEvent(QTimerEvent* event) override;

private:
    QOpenGLShaderProgram mainShader;
    QMatrix4x4 projection;
    QOpenGLBuffer vertices{QOpenGLBuffer::Type::VertexBuffer};
    QOpenGLBuffer ebo{QOpenGLBuffer::Type::IndexBuffer};
    int vertexCount;
    int indexCount;
    QBasicTimer timer;

    float cameraPosition[2];
    float cameraZoom = 1.0;

    ProjectData* project = nullptr;
};

#endif // PROJECTSTAGEVIEW_H
