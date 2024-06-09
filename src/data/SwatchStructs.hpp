#pragma once

#include <vector>

namespace xfl
{

struct SolidSwatchItem
{
	// hex code
	uint8_t color[3];
	int hue;
	int saturation;
	int brightness;
};

enum GradientType
{
	Linear,
	Radial
};

struct GradientEntry
{
	uint8_t color[3]; // hex code
	float ratio; // 0.0 - 1.0
};

struct GradientSwatchItem
{
	GradientType type;
	std::vector<GradientEntry> entries;
};

}
