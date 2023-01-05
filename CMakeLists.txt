cmake_minimum_required(VERSION 3.16)
project(LYNXANIMATOR)
set(CMAKE_CXX_STANDARD 20)

set(CMAKE_SKIP_BUILD_RPATH FALSE)
set(CMAKE_BUILD_RPATH_USE_ORIGIN TRUE)
set(CMAKE_INSTALL_RPATH $ORIGIN)

# Put all libraries in the executable folder
set(CMAKE_ARCHIVE_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/bin)
set(CMAKE_LIBRARY_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/bin)
set(CMAKE_RUNTIME_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/bin)

# libraries

# OPENGL
find_package(OpenGL REQUIRED)

# SDL
add_subdirectory(${CMAKE_CURRENT_SOURCE_DIR}/thirdparty/sdl)
list(APPEND PROJECT_LINK_LIBRARIES SDL2::SDL2)

# IMGUI

# Basic ImGui sources
list(APPEND IMGUI_HEADERS
        ${CMAKE_CURRENT_SOURCE_DIR}/thirdparty/imgui/imconfig.h
        ${CMAKE_CURRENT_SOURCE_DIR}/thirdparty/imgui/imgui.h
        ${CMAKE_CURRENT_SOURCE_DIR}/thirdparty/imgui/imgui_internal.h
        ${CMAKE_CURRENT_SOURCE_DIR}/thirdparty/imgui/imstb_rectpack.h
        ${CMAKE_CURRENT_SOURCE_DIR}/thirdparty/imgui/imstb_textedit.h
        ${CMAKE_CURRENT_SOURCE_DIR}/thirdparty/imgui/imstb_truetype.h)
list(APPEND IMGUI_SOURCES
        ${CMAKE_CURRENT_SOURCE_DIR}/thirdparty/imgui/imgui.cpp
        ${CMAKE_CURRENT_SOURCE_DIR}/thirdparty/imgui/imgui_demo.cpp
        ${CMAKE_CURRENT_SOURCE_DIR}/thirdparty/imgui/imgui_draw.cpp
        ${CMAKE_CURRENT_SOURCE_DIR}/thirdparty/imgui/imgui_tables.cpp
        ${CMAKE_CURRENT_SOURCE_DIR}/thirdparty/imgui/imgui_widgets.cpp)

list(APPEND IMGUI_HEADERS
            ${CMAKE_CURRENT_SOURCE_DIR}/thirdparty/imgui/backends/imgui_impl_sdl.h
            ${CMAKE_CURRENT_SOURCE_DIR}/thirdparty/imgui/backends/imgui_impl_opengl3.h)
list(APPEND IMGUI_SOURCES
            ${CMAKE_CURRENT_SOURCE_DIR}/thirdparty/imgui/backends/imgui_impl_sdl.cpp
            ${CMAKE_CURRENT_SOURCE_DIR}/thirdparty/imgui/backends/imgui_impl_opengl3.cpp)
list(APPEND IMGUI_INCLUDE_DIRS
            ${CMAKE_CURRENT_SOURCE_DIR}/thirdparty/sdl/include)
list(APPEND IMGUI_LINK_LIBRARIES SDL2::SDL2)


list(APPEND IMGUI_SOURCES ${IMGUI_HEADERS})
add_library(imgui STATIC ${IMGUI_SOURCES})
target_include_directories(imgui PRIVATE
        ${CMAKE_CURRENT_SOURCE_DIR}/thirdparty/imgui
        ${IMGUI_INCLUDE_DIRS})
target_link_libraries(imgui PRIVATE ${IMGUI_LINK_LIBRARIES})

list(APPEND PROJECT_LINK_LIBRARIES imgui)

include(${CMAKE_CURRENT_SOURCE_DIR}/src/CMakeLists.txt)
list(APPEND PROJECT_SOURCES ${PROJECT_HEADERS})

add_executable(${PROJECT_NAME} ${PROJECT_SOURCES})

target_include_directories(${PROJECT_NAME} PUBLIC
        ${OPENGL_INCLUDE_DIRS}
        ${CMAKE_CURRENT_SOURCE_DIR}/thirdparty/sdl/include
        ${CMAKE_CURRENT_SOURCE_DIR}/thirdparty/imgui)
target_include_directories(${PROJECT_NAME} PUBLIC ${CMAKE_CURRENT_SOURCE_DIR}/src)

target_link_libraries(${PROJECT_NAME} PUBLIC ${OPENGL_LIBRARIES} ${PROJECT_LINK_LIBRARIES})

target_include_directories(${PROJECT_NAME} PRIVATE ${CMAKE_CURRENT_SOURCE_DIR}/src)