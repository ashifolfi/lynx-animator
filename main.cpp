#include "mainwindow.h"

#include <QApplication>
#include <QLocale>
#include <QTranslator>
#include <QSettings>
#include <QStyleFactory>

int main(int argc, char *argv[])
{   
    QApplication a(argc, argv);
    // enforce the fusion style.
    QApplication::setStyle(QStyleFactory::create("Fusion"));
    QTranslator translator;

    std::unique_ptr<QSettings> options;
    auto configPath = QApplication::applicationDirPath() + "/config.ini";
    options = std::make_unique<QSettings>(configPath, QSettings::Format::IniFormat);

    const QStringList uiLanguages = QLocale::system().uiLanguages();
    for (const QString &locale : uiLanguages) {
        const QString baseName = "LynxAnimator_" + QLocale(locale).name();
        if (translator.load(":/i18n/" + baseName)) {
            a.installTranslator(&translator);
            break;
        }
    }

    MainWindow w;
    w.showMaximized();
    return a.exec();
}
