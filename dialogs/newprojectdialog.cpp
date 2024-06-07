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
    ProjectData projDat;
    projDat.Title = "Untitled";
    projDat.stageHeight = ui->heightSpinBox->value();
    projDat.stageWidth = ui->widthSpinBox->value();

    static_cast<MainWindow*>(this->parent())->AddProject(&projDat);
    this->close();
}

void NewProjectDialog::on_buttonBox_rejected()
{
    this->close();
}

