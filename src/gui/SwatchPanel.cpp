#include "SwatchPanel.hpp"
#include "../intl.h"

#include <iostream>
#include <fstream>
#include <streambuf>
#include <sstream>
#include <string>
#include <fmt/format.h>
#include <rapidxml/rapidxml.hpp>

using namespace lynxanim;

SwatchPanel::SwatchPanel()
	: ImGuiPanel(_("Swatches"))
{
	m_StrId = "lynx-swatch-panel";

	// load xml file and parse swatches into structs
	std::string xmlInfo;
	{
		std::ifstream file("testdata/swatchListTest.xml");
		std::stringstream strStream;
		strStream << file.rdbuf(); //read the file
		xmlInfo = strStream.str(); //str holds the content of the file
		file.close();
	}

	rapidxml::xml_document<> swatchListDoc;
	swatchListDoc.parse<0>(&xmlInfo[0]);

	rapidxml::xml_node<>* swatchNode = swatchListDoc.first_node("swatches")->first_node("SolidSwatchItem");
	while (swatchNode != nullptr)
	{
		// read out into a new swatch list element
		rapidxml::xml_attribute<>* colorAttr	= swatchNode->first_attribute("color");
		//rapidxml::xml_attribute<>* hueAttr		= swatchNode->first_attribute("hue");
		//rapidxml::xml_attribute<>* satAttr		= swatchNode->first_attribute("saturation");
		//rapidxml::xml_attribute<>* brightAttr	= swatchNode->first_attribute("brightness");
		
		xfl::SolidSwatchItem newSwatchItem;
		if (colorAttr != nullptr)
		{
			std::string colorHex = std::string(colorAttr->value());

			// WARNING: THIS IS DANGEROUS: int -> uint8_t conversion of a string form number!
			newSwatchItem.color[0] = stoi(colorHex.substr(1, 2), nullptr, 16);
			newSwatchItem.color[1] = stoi(colorHex.substr(3, 2), nullptr, 16);
			newSwatchItem.color[2] = stoi(colorHex.substr(5, 2), nullptr, 16);
		}
		else
		{
			newSwatchItem.color[0] = 0;
			newSwatchItem.color[1] = 0;
			newSwatchItem.color[2] = 0;
		}

		m_SwatchList.push_back(newSwatchItem);

		swatchNode = swatchNode->next_sibling();
	}
}

const int SWATCH_SIZE = 24;

void SwatchPanel::RenderContents()
{
	ImDrawList* winDraw = ImGui::GetWindowDrawList();

	int MAX_COLUMN = std::floor(
		(ImGui::GetWindowWidth() - (ImGui::GetStyle().WindowPadding.x * 2)) / (SWATCH_SIZE + (ImGui::GetStyle().ItemSpacing.x))
	);

	int curCol = 0;
	int curIdx = 0;
	for (const xfl::SolidSwatchItem swatch : m_SwatchList)
	{
		// create vec4 color
		ImVec4 color = ImVec4(
			(float)swatch.color[0] / 255,
			(float)swatch.color[1] / 255,
			(float)swatch.color[2] / 255,
			1.0f
		);

		winDraw->AddRectFilled(
			ImVec2(ImGui::GetCursorScreenPos().x, ImGui::GetCursorScreenPos().y),
			ImVec2(ImGui::GetCursorScreenPos().x + SWATCH_SIZE, ImGui::GetCursorScreenPos().y + SWATCH_SIZE),
			ImGui::GetColorU32(color)
		);
		if (ImGui::InvisibleButton(fmt::format("swatch_button_{}", curIdx).c_str(), ImVec2(SWATCH_SIZE, SWATCH_SIZE)))
		{
			printf("Pressed swatch button!");
		}
		
		if (curCol < MAX_COLUMN - 1)
		{
			ImGui::SameLine();
			curCol++;
		}
		else
		{
			curCol = 0;
		}
	}
}
