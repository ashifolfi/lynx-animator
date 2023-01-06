macro(sourcefiles)
    foreach(FILE ${ARGV})
        list(APPEND PROJECT_SOURCES ${CMAKE_CURRENT_LIST_DIR}/${FILE})
    endforeach()
endmacro()

macro(include_dir NAME)
    include(${CMAKE_CURRENT_LIST_DIR}/${NAME}/CMakeLists.txt)
endmacro()