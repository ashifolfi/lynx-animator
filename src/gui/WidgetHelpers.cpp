#include "WidgetHelpers.hpp"

#include <imgui.h>
#include <IconsFontAwesome6.h>

void LinkCallback(ImGui::MarkdownLinkCallbackData data_);

// windows specific functionality
#if defined(_WIN32) || defined(WIN32)
#define WIN32_LEAN_AND_MEAN
#include <Windows.h>
#include "Shellapi.h"

void LinkCallback(ImGui::MarkdownLinkCallbackData data_)
{
    std::string url(data_.link, data_.linkLength);
    if (!data_.isImage)
    {
        ShellExecuteA(NULL, "open", url.c_str(), NULL, NULL, SW_SHOWNORMAL);
    }
}
#endif

#include <fmt/format.h>

inline ImGui::MarkdownImageData ImageCallback(ImGui::MarkdownLinkCallbackData data_);

static ImFont* H1 = NULL;
static ImFont* H2 = NULL;
static ImFont* H3 = NULL;

static ImGui::MarkdownConfig mdConfig;

inline ImGui::MarkdownImageData ImageCallback(ImGui::MarkdownLinkCallbackData data_)
{
    // In your application you would load an image based on data_ input. Here we just use the imgui font texture.
    ImTextureID image = ImGui::GetIO().Fonts->TexID;
    // > C++14 can use ImGui::MarkdownImageData imageData{ true, false, image, ImVec2( 40.0f, 20.0f ) };
    ImGui::MarkdownImageData imageData;
    imageData.isValid = true;
    imageData.useLinkCallback = false;
    imageData.user_texture_id = image;
    imageData.size = ImVec2(40.0f, 20.0f);

    // For image resize when available size.x > image width, add
    ImVec2 const contentSize = ImGui::GetContentRegionAvail();
    if (imageData.size.x > contentSize.x)
    {
        float const ratio = imageData.size.y / imageData.size.x;
        imageData.size.x = contentSize.x;
        imageData.size.y = contentSize.x * ratio;
    }

    return imageData;
}

// initializes markdown with a static config and loads our default global font in multiple sizes
void LynxGui::InitMarkdown(float fontScale)
{
    ImGuiIO& io = ImGui::GetIO();

    // todo: get a bold font for this
    // Bold headings H2 and H3
    H2 = io.Fonts->AddFontFromFileTTF("fonts/DroidSans.ttf", fontScale * 1.1f);
    H3 = mdConfig.headingFormats[1].font;
    // bold heading H1
    H1 = io.Fonts->AddFontFromFileTTF("fonts/DroidSans.ttf", fontScale * 2.0f);
}

void LynxGui::Markdown(std::string text)
{
    mdConfig.linkCallback = LinkCallback;
    mdConfig.tooltipCallback = NULL;
    mdConfig.imageCallback = ImageCallback;
    mdConfig.linkIcon = ICON_FA_LINK;
    mdConfig.headingFormats[0] = { H1, true };
    mdConfig.headingFormats[1] = { H2, true };
    mdConfig.headingFormats[2] = { H3, false };
    mdConfig.userData = NULL;
    // we don't do anything special at this time
    mdConfig.formatCallback = ImGui::defaultMarkdownFormatCallback;
    ImGui::Markdown(text.c_str(), text.length(), mdConfig);
}

bool LynxGui::MenuIconItem(const char* icon, const char* label, const char* shortcut, bool *selected, bool enabled)
{
    return ImGui::MenuItem(fmt::format("{} {}", icon, label).c_str(), shortcut, selected, enabled);
}
