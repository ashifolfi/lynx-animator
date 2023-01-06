#include "Panel.h"

using namespace lynxanim;

Panel::Panel(std::string name, ImVec2 size) {
    this.name = name;
    this.size = size;
}

void Panel::setVisible(bool v) {
    this.visible = v;
}

bool Panel::getVisible() {
    return this.visible;
}