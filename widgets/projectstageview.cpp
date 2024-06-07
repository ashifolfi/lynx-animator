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
        QMessageBox::critical(this, tr("Error"), tr("Unable to initialize OpenGL 3.2 Core context! Please upgrade your computer to preview models."));
        return; // and probably crash right after
    }
}

void ProjectStageView::paintGL()
{
    // do nothing for now
}

void ProjectStageView::resizeGL(int width, int height)
{
    // do nothing for now
}
