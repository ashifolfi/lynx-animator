#pragma once

#include "ImGuiPanel.hpp"

namespace lynxanim
{

class ToolsPanel : public ImGuiPanel
{
public:
	ToolsPanel();

protected:
	void RenderContents() override;

	float m_IconScale;
};

}