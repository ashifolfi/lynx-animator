#pragma once

#include "gui/ImGuiPanel.hpp"
#include "data/ProjectData.hpp"

#include <imgui.h>
#include <vector>
#include <string>

namespace lynxanim
{

class MainWindow
{
public:
	MainWindow();
	static MainWindow* Instance;

	void Update();

	void AddPanel(ImGuiPanel* panel);
	ImGuiPanel* GetPanel(std::string id);

	void AddProject(ProjectData project);
	ProjectData* GetCurrentProject();
private:
	void RenderStage();
	void StageControls();

	ImVec2 cameraPos = ImVec2(160, 100);
	float cameraZoom = 1.0f;
	std::vector<ImGuiPanel*> m_Panels;

	std::vector<ProjectData> m_Projects;
	ProjectData* m_CurrentProject = nullptr;
	int m_CurrentProjectIndex = 0; // because pointers suck
};

}
