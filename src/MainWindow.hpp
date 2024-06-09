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

	ProjectData* GetCurrentProject();
private:
	std::vector<ImGuiPanel*> m_Panels;

	std::vector<ProjectData> m_Projects;
	ProjectData* m_CurrentProject = nullptr;
};

}
