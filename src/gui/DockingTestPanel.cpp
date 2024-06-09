#include "DockingTestPanel.hpp"

#include <imgui.h>
#include "../intl.h"

using namespace lynxanim;

DockingTestPanel::DockingTestPanel()
	: ImGuiPanel("Docking testing")
{
	m_StrId = "docking-test-panel";
}

void DockingTestPanel::RenderContents()
{
	ImGui::Text("This is a panel to test autodocking");
}
