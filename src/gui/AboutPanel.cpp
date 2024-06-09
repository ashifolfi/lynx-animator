#include "AboutPanel.hpp"

#include "WidgetHelpers.hpp"
#include "../intl.h"
#include <imgui.h>
#include <iostream>
#include <fstream>
#include <streambuf>
#include <sstream>

using namespace lynxanim;

AboutPanel::AboutPanel()
	: ImGuiPanel(_("About Lynx Animator"))
{
	m_StrId = "about-lynx-animator";
	m_Flags = ImGuiWindowFlags_Modal
		| ImGuiWindowFlags_NoSavedSettings
		| ImGuiWindowFlags_NoResize
		| ImGuiWindowFlags_NoCollapse
		| ImGuiWindowFlags_NoDocking;

	m_Size = ImVec2(450, 400);
	m_Pos = ImVec2(
		(ImGui::GetMainViewport()->WorkSize.x / 2) - (m_Size.x / 2),
		(ImGui::GetMainViewport()->WorkSize.y / 2) - (m_Size.y / 2)
	);

	// load the credits and license strings
	{
		std::ifstream credFile("credits.md");
		std::stringstream strStream;
		strStream << credFile.rdbuf(); //read the file
		creditsString = strStream.str(); //str holds the content of the file
	}

	{
		std::ifstream licFile("license.txt");
		std::stringstream strStream;
		strStream << licFile.rdbuf(); //read the file
		licenseString = strStream.str(); //str holds the content of the file
	}

	Visible = false;
}

void AboutPanel::RenderContents()
{
	ImGui::Text("Lynx Animator");

	if (ImGui::BeginTabBar("about-lynx-animator-tabbar"))
	{
		// this is certainly something
		float buttonHeight = (ImGui::GetStyle().FramePadding.y * 2 + ImGui::GetTextLineHeight());
		float windowPad = ImGui::GetStyle().WindowPadding.y;
		ImVec2 childSize = ImVec2(
			ImGui::GetWindowWidth() - (ImGui::GetStyle().WindowPadding.x * 2),
			ImGui::GetWindowHeight() - (windowPad + buttonHeight + ImGui::GetCursorPosY() + ImGui::GetStyle().ItemSpacing.y)
		);

		if (ImGui::BeginTabItem(_("Credits")))
		{
			if (ImGui::BeginChild("about-lynx-animator-credits", childSize))
			{
				LynxGui::Markdown(creditsString);

				ImGui::EndChild();
			}

			ImGui::EndTabItem();
		}

		if (ImGui::BeginTabItem(_("License")))
		{
			if (ImGui::BeginChild("about-lynx-animator-license", childSize))
			{
				ImGui::TextWrapped(licenseString.c_str());

				ImGui::EndChild();
			}

			ImGui::EndTabItem();
		}

		ImGui::EndTabBar();
	}

	// TODO: Write helpers for item positioning
	float buttonHeight = (ImGui::GetStyle().FramePadding.y * 2 + ImGui::GetTextLineHeight());
	float windowPad = ImGui::GetStyle().WindowPadding.y;
	ImGui::SetCursorPosY(ImGui::GetWindowHeight() - (windowPad + buttonHeight));
	if (ImGui::Button(_("Close")))
	{
		Visible = false;
	}
}
