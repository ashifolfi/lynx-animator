#include "NewProjectPanel.hpp"

#include "../MainWindow.hpp"
#include "WidgetHelpers.hpp"
#include "../intl.h"
#include <imgui.h>

using namespace lynxanim;

NewProjectPanel::NewProjectPanel()
	: ImGuiPanel(_("New Project"))
{
	m_StrId = "new-lynx-project-dialog";
	m_Flags = ImGuiWindowFlags_Modal
		| ImGuiWindowFlags_NoSavedSettings
		| ImGuiWindowFlags_NoResize
		| ImGuiWindowFlags_NoCollapse
		| ImGuiWindowFlags_NoDocking
		| ImGuiWindowFlags_AlwaysAutoResize;

	m_Pos = ImVec2(300, 300);
	Visible = false;

	m_newProjectData.Version = 1;
	m_newProjectData.Title = "Untitled Project";
	m_newProjectData.Author = "Unknown";
	m_newProjectData.stageWidth = 200;
	m_newProjectData.stageHeight = 200;
}

void NewProjectPanel::RenderContents()
{
	ImGui::PushID("lynx-new-project-width");
	ImGui::InputInt(_("Width:"), &m_newProjectData.stageWidth);
	ImGui::PopID();

	ImGui::PushID("lynx-new-project-height");
	ImGui::InputInt(_("Height:"), &m_newProjectData.stageHeight);
	ImGui::PopID();

	ImGui::Separator();

	ImGui::PushID("lynx-new-project-create");
	if (ImGui::Button(_("Create")))
	{
		Visible = false;
		MainWindow::Instance->AddProject(m_newProjectData);
		// reset data
		m_newProjectData.Version = 1;
		m_newProjectData.Title = "Untitled Project";
		m_newProjectData.Author = "Unknown";
		m_newProjectData.stageWidth = 200;
		m_newProjectData.stageHeight = 200;
	}
	ImGui::PopID();
	ImGui::PushID("lynx-new-project-cancel");
	if (ImGui::Button(_("Cancel")))
	{
		Visible = false;
		// reset data
		m_newProjectData.Version = 1;
		m_newProjectData.Title = "Untitled Project";
		m_newProjectData.Author = "Unknown";
		m_newProjectData.stageWidth = 200;
		m_newProjectData.stageHeight = 200;
	}
	ImGui::PopID();
}
