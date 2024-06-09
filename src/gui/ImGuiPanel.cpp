#include "ImGuiPanel.hpp"

using namespace lynxanim;

ImGuiPanel::ImGuiPanel(std::string title_)
{
	m_Title = title_;
	Visible = true;
	m_Flags = 0;
	m_Size = ImVec2(200, 200);
	m_Pos = ImVec2(0, 0);
}

void ImGuiPanel::Update()
{
	if (!Visible)
	{
		// early return if the panel isn't even visible
		return;
	}
	
	// first use ever means it won't affect saved layouts
	ImGui::SetNextWindowPos(m_Pos, ImGuiCond_FirstUseEver);
	ImGui::SetNextWindowSize(m_Size, ImGuiCond_FirstUseEver);

	// todo: we could probably use fmt for this
	if (ImGui::Begin((m_Title + "##" + m_StrId).c_str(), &Visible, m_Flags))
	{
		RenderContents();

		ImGui::End();
	}
}

std::string ImGuiPanel::GetFullName()
{
	return this->m_Title + "##" + this->m_StrId;
}

std::string ImGuiPanel::GetPanelID()
{
	return this->m_StrId;
}
