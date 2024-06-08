#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <QTabWidget>

#include "data/ProjectData.hpp"

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    MainWindow(QWidget *parent = nullptr);
    ~MainWindow();

    void AddProject(ProjectData* data);

private:
    QTabWidget* projectTabHolder;
};
#endif // MAINWINDOW_H
