#include "aboutdialog.h"

#include <QLayout>
#include <QVBoxLayout>
#include <QLabel>
#include <QTextEdit>
#include <QTabWidget>
#include <QFile>
#include <QTextStream>
#include <QDialogButtonBox>

AboutDialog::AboutDialog(QWidget *parent)
    : QDialog(parent)
{
    this->setMinimumSize(450, 400);
    QVBoxLayout *layout = new QVBoxLayout(this);

    QLabel* projectTitle = new QLabel("Lynx Animator", this);
    projectTitle->setAlignment(Qt::AlignHCenter);
    layout->addWidget(projectTitle);

    QTabWidget* categories = new QTabWidget(this);

    // we use a readonly text edit
    QTextEdit *creditsNames = new QTextEdit(categories);
    creditsNames->setReadOnly(true);
    QString creditsText = QString("# Lynx Animator\n") + '*' +
                          tr("Created by %1").arg("[Eden/Ashi](https://github.com/ashifolfi)") +
                          "*\n<br/>\n";
    QFile creditsFile(":/credits.md");
    if (creditsFile.open(QIODevice::ReadOnly)) {
        QTextStream in(&creditsFile);
        creditsText += in.readAll();
        creditsFile.close();
    }
    creditsNames->setMarkdown(creditsText);
    categories->addTab(creditsNames, tr("Credits"));

    QTextEdit *licenseText = new QTextEdit(categories);
    licenseText->setReadOnly(true);
    QFile licenseFile(":/LICENSE");
    if (licenseFile.open(QIODevice::ReadOnly)) {
        QTextStream in(&licenseFile);
        licenseText->setText(in.readAll());
        creditsFile.close();
    }
    else
    {
        licenseText->setText(tr("Unable to load license text!"));
    }
    licenseFile.close();
    categories->addTab(licenseText, tr("License"));

    layout->addWidget(categories);

    // close button
    QDialogButtonBox *buttons = new QDialogButtonBox(QDialogButtonBox::Close);
    connect(buttons, &QDialogButtonBox::rejected, this, &QDialog::accept);

    layout->addWidget(buttons);
}

AboutDialog::~AboutDialog()
{
}

void AboutDialog::accept()
{
    this->close();
}
