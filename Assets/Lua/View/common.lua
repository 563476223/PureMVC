--======================================================
-- Author: 付星
-- Purpose: common
--======================================================
local common = class('common',UIBase)

function common:init( ... )
    self.widget = 
    {
        bg = {'bg','bg'},
        left = {'left','left'},
        right = {'right','right'},
        leftBtn = {'left_button','left/left_button','Button','showLoginUI'},
        rightBtn = {'right_button','right/right_button','Button','showRightUI'},
    }
end

function common:onAwake( ... )
    self:Resize(ResolutionPolicy.LeftTop,self.left)
     self:Resize(ResolutionPolicy.RightTop,self.right)
     self:Resize(ResolutionPolicy.Middle,self.bg,true)
end

function common:showLoginUI( ... )
    UIManager:OpenUI(UIConfig.second_view)
end

function common:showRightUI( ... )
    UIManager:OpenUI(UIConfig.clanview)
end

return common