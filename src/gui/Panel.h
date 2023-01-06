#pragma once

#include <imgui.h>
#include <string.h>

namespace lynxanim {

class Panel {
    public:
        Panel(std::string name, ImVec2 size);

        void setVisible(bool v);
        bool getVisible();

    protected:
        bool visible = true;
        std::string name;
        ImVec2 size;
}

} // namespace lynxanim