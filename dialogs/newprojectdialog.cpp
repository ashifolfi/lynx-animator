#include "newprojectdialog.h"
#include "ui_newprojectdialog.h"
#include "../mainwindow.h"

NewProjectDialog::NewProjectDialog(QWidget *parent)
    : QDialog(parent)
    , ui(new Ui::NewProjectDialog)
{
    ui->setupUi(this);
}

NewProjectDialog::~NewProjectDialog()
{
    delete ui;
}

void NewProjectDialog::on_buttonBox_accepted()
{
    // this should be the main window
    static_cast<MainWindow*>(this->parent())->AddProject(nullptr);
    this->close();
}

void NewProjectDialog::on_buttonBox_rejected()
{
    this->close();
}

