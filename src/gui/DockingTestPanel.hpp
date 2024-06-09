#pragma once

#include "ImGuiPanel.hpp"

namespace lynxanim
{

class DockingTestPanel : public ImGuiPanel
{
public:
	DockingTestPanel();

protected:
	void RenderContents() override;
};

}
