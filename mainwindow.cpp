#include "mainwindow.h"
#include "./ui_mainwindow.h"
#include "dialogs/aboutdialog.h"
#include "dialogs/newprojectdialog.h"
#include "widgets/projectstageview.h"

#include <QLayout>

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::AddProject(ProjectData* data)
{
    // do nothing but add a tab
    ui->projectTabHolder->addTab(new ProjectStageView(data, ui->projectTabHolder), "New Project");
}

#pragma region slots
void MainWindow::on_actionQuit_triggered()
{
    // close the main window when you press quit (duh)
    this->close();
}

void MainWindow::on_actionAbout_Qt_triggered()
{
    QApplication::aboutQt();
}

void MainWindow::on_actionAbout_triggered()
{
    AboutDialog *aboutDialog = new AboutDialog(this);
    aboutDialog->show();
}

void MainWindow::on_actionNew_Project_triggered()
{
    NewProjectDialog *dialog = new NewProjectDialog(this);
    dialog->show();
}
#pragma endregion

