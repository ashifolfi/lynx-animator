#include "ToolsPanel.hpp"

#include <imgui.h>
#include <IconsFontAwesome6.h>
#include "WidgetHelpers.hpp"
#include "../intl.h"
#include <fmt/format.h>

using namespace lynxanim;

ToolsPanel::ToolsPanel()
	: ImGuiPanel(_("Tools"))
{
	m_StrId = "lynx-tools-panel";
	// size and pos don't matter at all, we default to docked anyways

	m_IconScale = 32.0f;
}

// oops uhh fuck
static float IconScale = 16.0f;

bool ToolPanelItem(const char* icon, const char* tooltip, const char* id)
{
	ImGui::PushStyleVar(ImGuiStyleVar_FramePadding, ImVec2(0, 0));
	if (IconScale == 16.0f || IconScale == 24.0f)
	{
		ImGui::PushFont(ImGui::GetIO().Fonts->Fonts[0]);
	}
	else if (IconScale == 32.0f)
	{
		ImGui::PushFont(ImGui::GetIO().Fonts->Fonts[1]);
	}
	else if (IconScale == 48.0f)
	{
		ImGui::PushFont(ImGui::GetIO().Fonts->Fonts[2]);
	}
	else if (IconScale == 64.0f)
	{
		ImGui::PushFont(ImGui::GetIO().Fonts->Fonts[3]);
	}

	bool ret = ImGui::Button(fmt::format("{}##{}", icon, id).c_str(), ImVec2(IconScale, IconScale));

	ImGui::PopFont();
	ImGui::PopStyleVar();
	
	if (ImGui::BeginItemTooltip())
	{
		ImGui::Text(tooltip);

		ImGui::EndTooltip();
	}
	return ret;
}

void ToolsPanel::RenderContents()
{
	if (ImGui::BeginPopupContextItem("lynx-anim-tools-icon-edit"))
	{
		if (ImGui::RadioButton("16x16", m_IconScale == 16.0f))
		{
			m_IconScale = 16.0f;
		}
		if (ImGui::RadioButton("24x24", m_IconScale == 24.0f))
		{
			m_IconScale = 24.0f;
		}
		if (ImGui::RadioButton("32x32", m_IconScale == 32.0f))
		{
			m_IconScale = 32.0f;
		}
		if (ImGui::RadioButton("48x48", m_IconScale == 48.0f))
		{
			m_IconScale = 48.0f;
		}
		if (ImGui::RadioButton("64x64", m_IconScale == 64.0f))
		{
			m_IconScale = 64.0f;
		}

		ImGui::EndPopup();
	}

	IconScale = m_IconScale;

	// tool buttons for debug purposes
	if (ToolPanelItem(ICON_FA_ARROW_POINTER, _("Object Select"), "lynx-tool-obj-sel"))
	{

	}
	if (ToolPanelItem(ICON_FA_FONT, _("Text"), "lynx-tool-create-text"))
	{

	}
	if (ToolPanelItem(ICON_FA_PEN_NIB, _("Freehand"), "lynx-tool-create-freehand"))
	{

	}
	if (ToolPanelItem(ICON_FA_DRAW_POLYGON, _("Polygon"), "lynx-tool-create-polygon"))
	{

	}
}
