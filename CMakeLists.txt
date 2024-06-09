# CMakeList.txt : CMake project for lynxanimator-imgui, include source and define
# project specific logic here.
#
cmake_minimum_required (VERSION 3.8)

# Enable Hot Reload for MSVC compilers if supported.
if (POLICY CMP0141)
  cmake_policy(SET CMP0141 NEW)
  set(CMAKE_MSVC_DEBUG_INFORMATION_FORMAT "$<IF:$<AND:$<C_COMPILER_ID:MSVC>,$<CXX_COMPILER_ID:MSVC>>,$<$<CONFIG:Debug,RelWithDebInfo>:EditAndContinue>,$<$<CONFIG:Debug,RelWithDebInfo>:ProgramDatabase>>")
endif()

set(CMAKE_MODULE_PATH ${CMAKE_MODULE_PATH} "${CMAKE_SOURCE_DIR}/cmake/modules")

project(
	"LynxAnimator"
	DESCRIPTION "An open source vector animation tool inspired by Adobe Flash"
	VERSION "0.3.0"
	HOMEPAGE_URL "https://github.com/ashifolfi/lynx-animator"
)

# Set up variables
set(PROJECT_NAME_PRETTY "Lynx Animator" CACHE STRING "" FORCE)
# If the tweak number exists, version is a beta or release candidate
if(PROJECT_VERSION_TWEAK STREQUAL "")
    # Proper release version
    set(PROJECT_VERSION_PRETTY "${PROJECT_VERSION}" CACHE STRING "" FORCE)
elseif(PROJECT_VERSION_TWEAK MATCHES "^99+$")
    # Release candidate, number of 9s controls the RC number
    string(LENGTH ${PROJECT_VERSION_TWEAK} PROJECT_VERSION_TWEAK_LENGTH)
    math(EXPR PROJECT_VERSION_TWEAK_LENGTH "${PROJECT_VERSION_TWEAK_LENGTH} - 1" OUTPUT_FORMAT DECIMAL)
    set(PROJECT_VERSION_PRETTY "${PROJECT_VERSION_MAJOR}.${PROJECT_VERSION_MINOR}.${PROJECT_VERSION_PATCH}-rc.${PROJECT_VERSION_TWEAK_LENGTH}" CACHE STRING "" FORCE)
else()
    # Beta version
    set(PROJECT_VERSION_PRETTY "${PROJECT_VERSION_MAJOR}.${PROJECT_VERSION_MINOR}.${PROJECT_VERSION_PATCH}-beta.${PROJECT_VERSION_TWEAK}" CACHE STRING "" FORCE)
endif()
set(PROJECT_ORGANIZATION_NAME "ashi/eden" CACHE STRING "" FORCE)

set(SRCDIR "${CMAKE_CURRENT_SOURCE_DIR}/src")

configure_file("${SRCDIR}/version.h.in" "${SRCDIR}/version.h")

set(PROJECT_SOURCES
	"${SRCDIR}/main.cpp"
	"${SRCDIR}/intl.h"
	"${SRCDIR}/version.h"

	"${SRCDIR}/MainWindow.hpp"
	"${SRCDIR}/MainWindow.cpp"

	"${SRCDIR}/data/ProjectData.hpp"

	"${SRCDIR}/gui/WidgetHelpers.hpp"
	"${SRCDIR}/gui/WidgetHelpers.cpp"
	"${SRCDIR}/gui/ImGuiPanel.hpp"
	"${SRCDIR}/gui/ImGuiPanel.cpp"
	"${SRCDIR}/gui/AboutPanel.hpp"
	"${SRCDIR}/gui/AboutPanel.cpp"
	"${SRCDIR}/gui/StagePanel.hpp"
	"${SRCDIR}/gui/StagePanel.cpp"
	"${SRCDIR}/gui/ToolsPanel.hpp"
	"${SRCDIR}/gui/ToolsPanel.cpp"

	# ImGui
	"thirdparty/imgui/imgui.cpp"
	"thirdparty/imgui/imgui.h"
	"thirdparty/imgui/imgui_internal.h"
	"thirdparty/imgui/imgui_demo.cpp"
	"thirdparty/imgui/imgui_draw.cpp"
	"thirdparty/imgui/imgui_tables.cpp"
	"thirdparty/imgui/imgui_widgets.cpp"
	"thirdparty/imgui/backends/imgui_impl_sdl2.cpp"
	"thirdparty/imgui/backends/imgui_impl_sdl2.h"
	"thirdparty/imgui/backends/imgui_impl_opengl3.cpp"
	"thirdparty/imgui/backends/imgui_impl_opengl3.h"

	# custom imgui extentions
	"thirdparty/imgui_extensions/imgui_markdown.h"
	"thirdparty/imgui_extensions/IconsFontAwesome6.h"
)

find_package(Intl REQUIRED)
find_package(SDL2 CONFIG REQUIRED)
find_package(OpenGL REQUIRED)
find_package(nlohmann_json REQUIRED)

add_subdirectory("thirdparty/fmt")

# Add source to this project's executable.
add_executable(${PROJECT_NAME} ${PROJECT_SOURCES})

if (CMAKE_VERSION VERSION_GREATER 3.12)
  set_property(TARGET ${PROJECT_NAME} PROPERTY CXX_STANDARD 20)
endif()

target_link_libraries(${PROJECT_NAME} PUBLIC
	${Intl_LIBRARY}
	${OPENGL_LIBRARIES}
	SDL2::SDL2
	SDL2::SDL2main
	fmt::fmt-header-only
	nlohmann_json::nlohmann_json
)
target_include_directories(${PROJECT_NAME} PUBLIC 
	"thirdparty/imgui_extensions"
	"thirdparty/imgui"
	"thirdparty/fmt/include"
	${OPENGL_INCLUDE_DIRS}
	${Intl_INCLUDE_DIRS}
	${SDL2_INCLUDE_DIRS}
)

# copy these next to the executable
configure_file("${CMAKE_CURRENT_SOURCE_DIR}/credits.md" "${CMAKE_BINARY_DIR}/credits.md" COPYONLY)
configure_file("${CMAKE_CURRENT_SOURCE_DIR}/LICENSE"    "${CMAKE_BINARY_DIR}/license.txt"COPYONLY)

# Copy resources
add_custom_target(CopyResources
        COMMAND ${CMAKE_COMMAND} -E copy_directory ${CMAKE_CURRENT_SOURCE_DIR}/res ${CMAKE_BINARY_DIR}/)
add_dependencies(${PROJECT_NAME} CopyResources)

# TODO: Add tests and install targets if needed.
