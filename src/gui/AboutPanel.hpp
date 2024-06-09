#pragma once

#include "ImGuiPanel.hpp"
#include <string>

namespace lynxanim
{

class AboutPanel : public ImGuiPanel
{
public:
	AboutPanel();

protected:
	void RenderContents() override;

private:
	std::string licenseString;
	std::string creditsString;
};

}
