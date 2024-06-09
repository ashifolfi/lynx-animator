#include "StagePanel.hpp"

#include "../intl.h"
#include <imgui.h>
#include <algorithm>
#include <fmt/format.h>

using namespace lynxanim;

StagePanel::StagePanel()
	: ImGuiPanel(_("Stage"))
{
	m_StrId = "lynx-stage-panel";
	m_Size = ImVec2(500, 500);
	m_Flags = ImGuiWindowFlags_NoCollapse;
}

void StagePanel::RenderContents()
{
	// don't execute the controls if we aren't in focus
	ImGui::Text(fmt::format("Camera Zoom: {}", cameraZoom).c_str());
	if (ImGui::IsWindowFocused())
	{
		StageControls();
	}
	ImGui::SetCursorPos(ImGui::GetCursorStartPos());

	RenderStage();
}

void StagePanel::StageControls()
{
	if (ImGui::IsKeyDown(ImGuiKey_Space))
	{
		ImGui::SetNextFrameWantCaptureMouse(true);

		// pan the camera
		cameraPos.x -= ImGui::GetIO().MouseDelta.x;
		cameraPos.y -= ImGui::GetIO().MouseDelta.y;
	}
	else
	{
		ImGui::SetNextFrameWantCaptureMouse(false);
	}

	if (ImGui::GetIO().MouseWheel && ImGui::IsWindowHovered())
	{
		// change the zoom amount based on the direction
		if (ImGui::GetIO().MouseWheel > 0)
		{
			cameraZoom += 0.1f;
		}
		else if (ImGui::GetIO().MouseWheel < 0)
		{
			cameraZoom -= 0.1f;
		}
		cameraZoom = std::clamp(cameraZoom, 0.01f, 4.0f);
	}
}

#define VEC2OFF(value) ImVec2((basePos.x + (value.x * cameraZoom)) - cameraPos.x, (basePos.y + (value.y * cameraZoom)) - cameraPos.y)

void StagePanel::RenderStage()
{
	ImDrawList* winDraw = ImGui::GetWindowDrawList();

	ImVec2 canvasSize = ImVec2(320, 200);

	// base coords at center of the window, offset by camera position
	ImVec2 basePos = ImVec2(
		(ImGui::GetCursorScreenPos().x + (ImGui::GetWindowWidth() / 2)),
		(ImGui::GetCursorScreenPos().y + (ImGui::GetWindowHeight() / 2))
	);

	// draw our canvas
	winDraw->AddRectFilled(VEC2OFF(ImVec2(0,0)), VEC2OFF(canvasSize),
		ImGui::GetColorU32(ImVec4(1.0f, 1.0f, 1.0f, 1.0f))
	);
	winDraw->AddRect(VEC2OFF(ImVec2(0, 0)), VEC2OFF(canvasSize),
		ImGui::GetColorU32(ImVec4(0.0f, 0.0f, 0.0f, 1.0f))
	);
}