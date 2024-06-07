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
    /*void mousePressEvent(QMouseEvent* event) override;
    void mouseReleaseEvent(QMouseEvent* event) override;
    void mouseMoveEvent(QMouseEvent* event) override;
    void wheelEvent(QWheelEvent* event) override;*/

private:

    ProjectData* project = nullptr;
};

#endif // PROJECTSTAGEVIEW_H
