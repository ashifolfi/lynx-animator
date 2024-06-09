#include "MainWindow.hpp"

#include "gui/AboutPanel.hpp"
#include "gui/ToolsPanel.hpp"
#include "gui/StagePanel.hpp"
#include "gui/WidgetHelpers.hpp"

#include "intl.h"
#include <imgui_internal.h>
#include <fmt/format.h>
#include <IconsFontAwesome6.h>
#include "version.h"
#include <SDL.h>

using namespace lynxanim;

MainWindow* MainWindow::Instance = nullptr;

MainWindow::MainWindow()
{
	MainWindow::Instance = this;

	// add our default panels
	AddPanel(new AboutPanel());
	AddPanel(new ToolsPanel());
	AddPanel(new StagePanel());
}

// used to prevent exiting the rect from stopping a drag (annoying)
static bool isDragging = false;

void MainWindow::Update()
{
	const ImGuiViewport* viewport = ImGui::GetMainViewport();

	// custom titlebar
	ImGui::PushStyleVar(ImGuiStyleVar_FramePadding, ImVec2(4, 8));
	if (ImGui::BeginMainMenuBar())
	{
		// we use this for dragging later
		ImVec2 basePos = ImGui::GetCursorScreenPos();

#if defined(__APPLE__)
		// mac buttons
		// TODO: Add hover/pressed colors and icons

		const ImVec2 winBtnSize = ImVec2(16, 32);
		ImGui::PushFont(ImGui::GetIO().Fonts->Fonts[1]);
		ImGui::PushStyleVar(ImGuiStyleVar_FramePadding, ImVec2(0, 0));

		ImGui::GetWindowDrawList()->AddCircleFilled(
			ImVec2(ImGui::GetCursorScreenPos().x + 8, ImGui::GetCursorScreenPos().y + 16),
			6, ImGui::GetColorU32(ImVec4(1.0f, 0.37f, 0.34f, 1.0f)), 24
		);
		if (ImGui::InvisibleButton("mac-titlebar-close", winBtnSize))
		{
			SDL_Event ev;
			ev.type = SDL_QUIT;
			SDL_PushEvent(&ev);
		}
		
		ImGui::GetWindowDrawList()->AddCircleFilled(
			ImVec2(ImGui::GetCursorScreenPos().x + 8, ImGui::GetCursorScreenPos().y + 16),
			6, ImGui::GetColorU32(ImVec4(0.9f, 0.74f, 0.18f, 1.0f)), 24
		);
		if (ImGui::InvisibleButton("mac-titlebar-minimize", winBtnSize))
		{
			SDL_MinimizeWindow(SDL_GL_GetCurrentWindow());
		}
		
		ImGui::GetWindowDrawList()->AddCircleFilled(
			ImVec2(ImGui::GetCursorScreenPos().x + 8, ImGui::GetCursorScreenPos().y + 16),
			6, ImGui::GetColorU32(ImVec4(0.15f, 0.78f, 0.25f, 1.0f)), 24
		);
		if (ImGui::InvisibleButton("mac-titlebar-maximize", winBtnSize))
		{
			SDL_MaximizeWindow(SDL_GL_GetCurrentWindow());
		}
		ImGui::PopFont();
		ImGui::PopStyleVar();
#endif

#pragma region Menubar
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
#pragma endregion

		// centered titlebar text
		std::string titlebarText = fmt::format("{} - Lynx Animator", "No Document");
		float curPos = ImGui::GetCursorPosX();
		ImGui::SetCursorPosX(((viewport->WorkSize.x - curPos) / 2) - (ImGui::CalcTextSize(titlebarText.c_str()).x / 2));
		ImGui::Text(titlebarText.c_str());

		// windows and linux generally have right aligned buttons, mac code is above as mac uses left aligned
#if defined(WIN32) || defined(_WIN32) || defined(__unix__)
		float ButtonTotalSize = (ImGui::GetStyle().ItemSpacing.x * 3) + (58 * 3);
		ImGui::SetCursorPosX(viewport->WorkSize.x - ButtonTotalSize - ImGui::GetStyle().WindowPadding.x);

		const ImVec2 winBtnSize = ImVec2(58, 32);
		ImGui::PushFont(ImGui::GetIO().Fonts->Fonts[1]);
		ImGui::PushStyleVar(ImGuiStyleVar_FramePadding, ImVec2(0, 0));
		if (ImGui::Button(ICON_FA_WINDOW_MINIMIZE, winBtnSize))
		{
			SDL_MinimizeWindow(SDL_GL_GetCurrentWindow());
		}
		if (ImGui::Button(ICON_FA_WINDOW_MAXIMIZE, winBtnSize))
		{
			SDL_MaximizeWindow(SDL_GL_GetCurrentWindow());
		}
		if (ImGui::Button(ICON_FA_X, winBtnSize))
		{
			SDL_Event ev;
			ev.type = SDL_QUIT;
			SDL_PushEvent(&ev);
		}
		ImGui::PopFont();
		ImGui::PopStyleVar();
#endif

		ImGui::SetCursorPosX(curPos);
		// agh
#if defined(WIN32) || defined(_WIN32) || defined(__unix__)
		ImGui::InvisibleButton("titlebar_mover", ImVec2(viewport->WorkSize.x - curPos - ButtonTotalSize, basePos.y + 32));
#else
		ImGui::InvisibleButton("titlebar_mover", ImVec2(viewport->WorkSize.x - curPos, basePos.y + 32));
#endif
		if ((ImGui::IsMouseDown(ImGuiMouseButton_Left) && ImGui::IsItemActive()) || isDragging)
		{
			// check for drag and move window if so
			if (ImGui::IsMouseDragging(ImGuiMouseButton_Left))
			{
				isDragging = true;
				SDL_Window* curWin = SDL_GL_GetCurrentWindow();

				int winX, winY;
				SDL_GetWindowPosition(curWin, &winX, &winY);
				SDL_SetWindowPosition(curWin, winX + ImGui::GetIO().MouseDelta.x, winY + ImGui::GetIO().MouseDelta.y);
			}
			else
			{
				isDragging = false;
			}
		}

		ImGui::EndMainMenuBar();
	}
	ImGui::PopStyleVar();

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

		ImGui::DockBuilderDockWindow(GetPanel("lynx-tools-panel")->GetFullName().c_str(), dock_id_right);
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
