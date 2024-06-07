#pragma once

#include <string>

struct ProjectData
{
    int Version;
    std::string Title;
    std::string Author;

    // stage info
    int stageWidth;
    int stageHeight;
};
