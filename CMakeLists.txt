cmake_minimum_required(VERSION 3.5)

project(LynxAnimator VERSION 0.1 LANGUAGES CXX)

set(CMAKE_AUTOUIC ON)
set(CMAKE_AUTOMOC ON)
set(CMAKE_AUTORCC ON)

set(CMAKE_CXX_STANDARD 17)
set(CMAKE_CXX_STANDARD_REQUIRED ON)

find_package(Qt6 REQUIRED COMPONENTS Widgets OpenGL OpenGLWidgets LinguistTools)

set(TS_FILES res/lang/LynxAnimator_en_US.ts)

set(PROJECT_SOURCES
        main.cpp
        res/main.qrc

        ProjectData.hpp

        mainwindow.cpp
        mainwindow.h

        dialogs/aboutdialog.h
        dialogs/aboutdialog.cpp
        dialogs/newprojectdialog.h
        dialogs/newprojectdialog.cpp
        dialogs/newprojectdialog.ui

        widgets/projectstageview.h
        widgets/projectstageview.cpp

        ${TS_FILES}
)

qt_add_executable(LynxAnimator
    MANUAL_FINALIZATION
    ${PROJECT_SOURCES}
)
# Define target properties for Android with Qt 6 as:
#    set_property(TARGET LynxAnimator APPEND PROPERTY QT_ANDROID_PACKAGE_SOURCE_DIR
#                 ${CMAKE_CURRENT_SOURCE_DIR}/android)
# For more information, see https://doc.qt.io/qt-6/qt-add-executable.html#target-creation

qt_add_lupdate(SOURCE_TARGETS LynxAnimator TS_FILES ${TS_FILES})
qt_create_translation(QM_FILES ${CMAKE_SOURCE_DIR} ${TS_FILES})

target_link_libraries(LynxAnimator PRIVATE
    Qt::Widgets
    Qt::OpenGL
    Qt::OpenGLWidgets)

# Qt for iOS sets MACOSX_BUNDLE_GUI_IDENTIFIER automatically since Qt 6.1.
# If you are developing for iOS or macOS you should consider setting an
# explicit, fixed bundle identifier manually though.
set_target_properties(LynxAnimator PROPERTIES
    ${BUNDLE_ID_OPTION}
    MACOSX_BUNDLE_BUNDLE_VERSION ${PROJECT_VERSION}
    MACOSX_BUNDLE_SHORT_VERSION_STRING ${PROJECT_VERSION_MAJOR}.${PROJECT_VERSION_MINOR}
    MACOSX_BUNDLE TRUE
    WIN32_EXECUTABLE TRUE
)

include(GNUInstallDirs)
install(TARGETS LynxAnimator
    BUNDLE DESTINATION .
    LIBRARY DESTINATION ${CMAKE_INSTALL_LIBDIR}
    RUNTIME DESTINATION ${CMAKE_INSTALL_BINDIR}
)

qt_finalize_executable(LynxAnimator)
