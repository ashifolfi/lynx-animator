#pragma once

#include <imgui.h>
#include <imgui_markdown.h>
#include <string>

namespace LynxGui
{
void InitMarkdown(float fontScale = 14.0f);
void Markdown(std::string text);

// because icons are done via fonts in imgui
bool MenuIconItem(const char* icon, const char* label, const char* shortcut = "", bool *selected = false, bool enabled = true);
// Special button type that has gradients and whatnot
bool Button(std::string label, ImVec2 size = ImVec2(0, 0));
}
