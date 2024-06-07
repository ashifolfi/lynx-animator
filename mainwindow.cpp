#include "mainwindow.h"
#include "dialogs/aboutdialog.h"
#include "dialogs/newprojectdialog.h"
#include "widgets/projectstageview.h"

#include <QAction>
#include <QLayout>
#include <QApplication>
#include <QDockWidget>
#include <QMainWindow>
#include <QMenu>
#include <QMenuBar>
#include <QStatusBar>
#include <QTabWidget>
#include <QVBoxLayout>
#include <QWidget>
#include <QStyle>

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
{
    setWindowTitle(tr("Lynx Animator"));

    // welcome to hell (creating menus)
    QMenu *fileMenu = this->menuBar()->addMenu(tr("&File"));
    fileMenu->addAction(this->style()->standardIcon(QStyle::SP_FileIcon), tr("New Project"),  Qt::CTRL | Qt::Key_N, [this] {
        NewProjectDialog *dialog = new NewProjectDialog(this);
        dialog->show();
    });

    // just add the other actions with nothing for now
    fileMenu->addAction(this->style()->standardIcon(QStyle::SP_DirIcon), tr("Open Project"), [this] {});

    fileMenu->addSeparator();

    fileMenu->addAction(this->style()->standardIcon(QStyle::SP_DialogSaveButton), tr("Save Project"), Qt::CTRL | Qt::Key_S, [this] {});
    fileMenu->addAction(this->style()->standardIcon(QStyle::SP_DialogSaveButton), tr("Save Project As"), Qt::CTRL | Qt::SHIFT | Qt::Key_S, [this] {});

    fileMenu->addSeparator();

    fileMenu->addAction(this->style()->standardIcon(QStyle::SP_BrowserReload), tr("Close Project"), Qt::CTRL | Qt::Key_W, [this] {});
    fileMenu->addAction(this->style()->standardIcon(QStyle::SP_BrowserReload), tr("Close All Projects"), Qt::CTRL | Qt::SHIFT | Qt::Key_W, [this] {});

    fileMenu->addSeparator();

    fileMenu->addAction(this->style()->standardIcon(QStyle::SP_BrowserReload), tr("Quit"), Qt::CTRL | Qt::Key_Q, [this] {
        this->close();
    });

    QMenu *aboutMenu = this->menuBar()->addMenu(tr("&Help"));
    aboutMenu->addAction(this->style()->standardIcon(QStyle::SP_MessageBoxInformation), tr("About Animator"), [this] {
        AboutDialog *aboutDialog = new AboutDialog(this);
        aboutDialog->show();
    });
    aboutMenu->addAction(this->style()->standardIcon(QStyle::SP_MessageBoxInformation), tr("About Qt"), [this] {
        QApplication::aboutQt();
    });

    QVBoxLayout *layout = new QVBoxLayout(this);

    projectTabHolder = new QTabWidget(this);
    layout->addWidget(projectTabHolder);
}

MainWindow::~MainWindow()
{
}

void MainWindow::AddProject(ProjectData* data)
{
    // do nothing but add a tab
    projectTabHolder->addTab(new ProjectStageView(data, projectTabHolder), "New Project");
}
