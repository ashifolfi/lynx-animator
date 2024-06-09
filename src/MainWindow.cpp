#include "MainWindow.hpp"

#include "gui/AboutPanel.hpp"
#include "gui/ToolsPanel.hpp"
#include "gui/NewProjectPanel.hpp"
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
	AddPanel(new NewProjectPanel());
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
			if (LynxGui::MenuIconItem(ICON_FA_FILE, _("New Project"), "Ctrl+N"))
			{
				GetPanel("new-lynx-project-dialog")->Visible = true;
			}
			LynxGui::MenuIconItem(ICON_FA_FOLDER, _("Open Project"), "Ctrl+O");
			ImGui::Separator();
			LynxGui::MenuIconItem(ICON_FA_FLOPPY_DISK, _("Save Project"), "Ctrl+S");
			LynxGui::MenuIconItem(ICON_FA_FLOPPY_DISK, _("Save Project As"), "Ctrl+Shift+S");
			ImGui::Separator();
			LynxGui::MenuIconItem(ICON_FA_XMARK, _("Close Project"), "Ctrl+W");
			LynxGui::MenuIconItem(ICON_FA_XMARK, _("Close All Projects"));
			ImGui::Separator();
			if (LynxGui::MenuIconItem(ICON_FA_XMARK, _("Quit"), "Ctrl+Q"))
			{
				SDL_Event ev;
				ev.type = SDL_QUIT;
				SDL_PushEvent(&ev);
			}
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
		std::string titlebarText = fmt::format("{} - Lynx Animator", m_CurrentProject == nullptr ? "No Document" : m_CurrentProject->Title);
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
			// FIXME: this doesn't actually work apparently (oops)
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
		ImGui::DockBuilderDockWindow("Documents##lynx-stage-doc-view", dockspace_id);

		ImGui::DockBuilderFinish(dockspace_id);
	}

	ImGui::End();
#pragma endregion

	if (ImGui::Begin("Documents##lynx-stage-doc-view", nullptr, ImGuiWindowFlags_NoDecoration))
	{
		if (ImGui::BeginTabBar("lynx-projects-tab-bar"))
		{
			for (int i = 0; i < m_Projects.size(); i++)
			{
				if (ImGui::BeginTabItem(fmt::format("{}##tab_index_{}", m_Projects[i].Title, i).c_str()))
				{
					m_CurrentProject = &m_Projects[i];
					m_CurrentProjectIndex = i;
					ImGui::EndTabItem();
				}
			}

			ImGui::EndTabBar();
		}

		if (m_CurrentProject == nullptr)
		{
			// return early if no project is loaded
			ImGui::Text(_("No project loaded"));
		}
		else
		{
			if (ImGui::IsWindowFocused())
			{
				StageControls();
			}

			RenderStage();
		}

		ImGui::End();
	}

	// temp.
	ImGui::ShowDemoWindow();

	// DO NOT DOCK ANYTHING TO THESE PANELS, FOR SOME REASON 
	// IT CRASHES THE ENTIRE PROGRAM AND I HAVE NO IDEA WHY.
	for (ImGuiPanel* panel : m_Panels)
	{
		panel->Update();
	}
}

void MainWindow::StageControls()
{
	if (ImGui::IsKeyDown(ImGuiKey_Space))
	{
		ImGui::SetNextFrameWantCaptureMouse(true);

		// pan the camera
		cameraPos.x -= ImGui::GetIO().MouseDelta.x;
		cameraPos.y -= ImGui::GetIO().MouseDelta.y;
	}
	else
	{
		ImGui::SetNextFrameWantCaptureMouse(false);
	}

	if (ImGui::GetIO().MouseWheel && ImGui::IsWindowHovered())
	{
		// change the zoom amount based on the direction
		if (ImGui::GetIO().MouseWheel > 0)
		{
			cameraZoom += 0.1f;
		}
		else if (ImGui::GetIO().MouseWheel < 0)
		{
			cameraZoom -= 0.1f;
		}
		cameraZoom = std::clamp(cameraZoom, 0.01f, 4.0f);
	}
}

#define VEC2OFF(value) ImVec2((basePos.x + (value.x * cameraZoom)) - cameraPos.x, (basePos.y + (value.y * cameraZoom)) - cameraPos.y)

void MainWindow::RenderStage()
{
	ImDrawList* winDraw = ImGui::GetWindowDrawList();

	ImVec2 canvasSize = ImVec2(m_CurrentProject->stageWidth, m_CurrentProject->stageHeight);

	// base coords at center of the window, offset by camera position
	ImVec2 basePos = ImVec2(
		(ImGui::GetCursorScreenPos().x + (ImGui::GetWindowWidth() / 2)),
		(ImGui::GetCursorScreenPos().y + (ImGui::GetWindowHeight() / 2))
	);

	// draw our canvas
	winDraw->AddRectFilled(VEC2OFF(ImVec2(0, 0)), VEC2OFF(canvasSize),
		ImGui::GetColorU32(ImVec4(1.0f, 1.0f, 1.0f, 1.0f))
	);
	winDraw->AddRect(VEC2OFF(ImVec2(0, 0)), VEC2OFF(canvasSize),
		ImGui::GetColorU32(ImVec4(0.0f, 0.0f, 0.0f, 1.0f))
	);
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

void lynxanim::MainWindow::AddProject(ProjectData project)
{
	m_Projects.push_back(project);
	m_CurrentProject = &m_Projects.back();
}

ProjectData* lynxanim::MainWindow::GetCurrentProject()
{
	return m_CurrentProject;
}
