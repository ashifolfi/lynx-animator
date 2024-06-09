#pragma once

#include "ImGuiPanel.hpp"
#include <string>
#include <vector>
#include "../data/SwatchStructs.hpp"

namespace lynxanim
{

class SwatchPanel : public ImGuiPanel
{
public:
	SwatchPanel();

protected:
	void RenderContents() override;

private:
	std::vector<xfl::SolidSwatchItem> m_SwatchList;
};

}
