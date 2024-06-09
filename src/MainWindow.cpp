#include "MainWindow.hpp"

#include "gui/AboutPanel.hpp"
#include "gui/DockingTestPanel.hpp"
#include "gui/StagePanel.hpp"
#include "gui/WidgetHelpers.hpp"

#include "intl.h"
#include <imgui_internal.h>
#include <fmt/format.h>
#include <IconsFontAwesome6.h>
#include "version.h"

using namespace lynxanim;

MainWindow* MainWindow::Instance = nullptr;

MainWindow::MainWindow()
{
	MainWindow::Instance = this;

	// add our default panels
	AddPanel(new AboutPanel());
	AddPanel(new DockingTestPanel());
	AddPanel(new StagePanel());
}

void MainWindow::Update()
{
	const ImGuiViewport* viewport = ImGui::GetMainViewport();

	// custom titlebar for windows
	if (ImGui::BeginMainMenuBar())
	{
		if (ImGui::BeginMenu(_("File")))
		{
			LynxGui::MenuIconItem(ICON_FA_FILE, _("New Project"), "Ctrl+N");
			LynxGui::MenuIconItem(ICON_FA_FOLDER, _("Open Project"), "Ctrl+O");
			ImGui::Separator();
			LynxGui::MenuIconItem(ICON_FA_FLOPPY_DISK, _("Save Project"), "Ctrl+S");
			LynxGui::MenuIconItem(ICON_FA_FLOPPY_DISK, _("Save Project As"), "Ctrl+Shift+S");
			ImGui::Separator();
			LynxGui::MenuIconItem(ICON_FA_XMARK, _("Close Project"), "Ctrl+W");
			LynxGui::MenuIconItem(ICON_FA_XMARK, _("Close All Projects"));
			ImGui::Separator();
			LynxGui::MenuIconItem(ICON_FA_XMARK, _("Quit"), "Ctrl+Q");
			ImGui::EndMenu();
		}

		if (ImGui::BeginMenu(_("Edit")))
		{
			LynxGui::MenuIconItem(ICON_FA_REPLY, _("Undo"), "Ctrl+Z");
			LynxGui::MenuIconItem(ICON_FA_SHARE, _("Redo"), "Ctrl+Shift+Z");
			ImGui::Separator();
			LynxGui::MenuIconItem(ICON_FA_SCISSORS, _("Cut"), "Ctrl+X");
			LynxGui::MenuIconItem(ICON_FA_COPY, _("Copy"), "Ctrl+C");
			LynxGui::MenuIconItem(ICON_FA_PASTE, _("Paste"), "Ctrl+V");
			LynxGui::MenuIconItem(ICON_FA_TRASH, _("Delete"), "Delete");

			ImGui::EndMenu();
		}

		if (ImGui::BeginMenu(_("Help")))
		{
			if (LynxGui::MenuIconItem(ICON_FA_INFO, _("About Lynx Animator")))
			{
				GetPanel("about-lynx-animator")->Visible = true;
			}
			ImGui::Separator();
			LynxGui::MenuIconItem(ICON_FA_QUESTION, _("View Documentation"));

			ImGui::EndMenu();
		}

		std::string verString = fmt::format("Lynx Animator v{}", PROJECT_VERSION_PRETTY);
		ImGui::SetCursorPosX(viewport->WorkSize.x - ImGui::CalcTextSize(verString.c_str()).x - ImGui::GetStyle().WindowPadding.x);
		ImGui::TextColored(ImVec4(1.0f, 1.0f, 1.0f, 0.5f), verString.c_str());

		ImGui::EndMainMenuBar();
	}

#pragma region Dockspace/Dockbuilder
	// display our dockspace window
	ImGuiWindowFlags window_flags = 
		ImGuiWindowFlags_NoDocking
		| ImGuiWindowFlags_NoTitleBar
		| ImGuiWindowFlags_NoCollapse
		| ImGuiWindowFlags_NoResize
		| ImGuiWindowFlags_NoMove
		| ImGuiWindowFlags_NoBringToFrontOnFocus
		| ImGuiWindowFlags_NoNavFocus;
	ImGui::SetNextWindowPos(viewport->WorkPos);
	ImGui::SetNextWindowSize(viewport->WorkSize);
	ImGui::SetNextWindowViewport(viewport->ID);
	ImGui::PushStyleVar(ImGuiStyleVar_WindowRounding, 0.0f);
	ImGui::PushStyleVar(ImGuiStyleVar_WindowBorderSize, 0.0f);
	ImGui::PushStyleVar(ImGuiStyleVar_WindowPadding, ImVec2(0.0f, 0.0f));

	ImGui::Begin("MAINDOCKWINDOW", nullptr, window_flags);
	ImGui::PopStyleVar(3);

	ImGuiID dockspace_id = ImGui::GetID("CENTRALDOCKSPACE");
	ImGui::DockSpace(dockspace_id, ImVec2(0.0f, 0.0f), ImGuiDockNodeFlags_None);

	static auto first_time = true;
	if (first_time)
	{
		first_time = false;

		ImGui::DockBuilderRemoveNode(dockspace_id); // clear any previous layout
		ImGui::DockBuilderAddNode(dockspace_id, ImGuiDockNodeFlags_DockSpace);
		ImGui::DockBuilderSetNodeSize(dockspace_id, viewport->Size);

		auto dock_id_right = ImGui::DockBuilderSplitNode(dockspace_id, ImGuiDir_Right, 0.25f, nullptr, &dockspace_id);

		ImGui::DockBuilderDockWindow(GetPanel("docking-test-panel")->GetFullName().c_str(), dock_id_right);
		ImGui::DockBuilderDockWindow(GetPanel("lynx-stage-panel")->GetFullName().c_str(), dockspace_id);

		ImGui::DockBuilderFinish(dockspace_id);
	}

	ImGui::End();
#pragma endregion

	// temp
	ImGui::ShowDemoWindow();

	for (ImGuiPanel* panel : m_Panels)
	{
		panel->Update();
	}
}

void MainWindow::AddPanel(ImGuiPanel* panel)
{
	if (GetPanel(panel->GetPanelID()) != nullptr)
	{
		// todo: throw an error
		return;
	}
	
	m_Panels.push_back(panel);
}

ImGuiPanel* MainWindow::GetPanel(std::string id)
{
	for (ImGuiPanel* panel : m_Panels)
	{
		if (panel->GetPanelID() == id)
		{
			return panel;
		}
	}

	// return nullptr, no panel of that id exists
	return nullptr;
}
