/*
* Standalone Stage Panel
* 
* Displays the current project's stage and provides visual control over
* the objects and elements present within the project.
*/
#pragma once

#include "ImGuiPanel.hpp"

namespace lynxanim
{

class StagePanel : public ImGuiPanel
{
public:
	StagePanel();

protected:
	void RenderContents() override;

private:
	void RenderStage();
	void StageControls();

	ImVec2 cameraPos = ImVec2(160, 100);
	float cameraZoom = 1.0f;
};

}
