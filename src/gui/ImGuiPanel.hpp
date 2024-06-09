#pragma once

#include <string>
#include <imgui.h>

namespace lynxanim
{

class ImGuiPanel
{
public:
	ImGuiPanel(std::string title_);
	bool Visible;

	void Update();

	std::string GetPanelID();
	// returns both name + ID (used for dockbuilder)
	std::string GetFullName();
protected:
	// note: this is defined here because it doesn't do anything by default
	virtual void RenderContents() {};

	std::string m_StrId;
	std::string m_Title;
	bool m_CanClose;
	ImGuiWindowFlags m_Flags;
	ImVec2 m_Size;
	ImVec2 m_Pos;
};

}
