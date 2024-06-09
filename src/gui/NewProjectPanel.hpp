#pragma once

#include "ImGuiPanel.hpp"
#include <string>
#include "../data/ProjectData.hpp"

namespace lynxanim
{

class NewProjectPanel : public ImGuiPanel
{
public:
	NewProjectPanel();

protected:
	void RenderContents() override;

private:
	ProjectData m_newProjectData{};
};

}
