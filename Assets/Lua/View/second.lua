--======================================================
-- Author: 付星
-- Purpose: second
--======================================================
local second = class('second', UIBase)

function second:init(...)
	self.widget =
	{
		bg = {'bg', 'bg'},
		center = {'center', 'center'},
		close = {'close', 'center', 'Button', 'closeClanView'}
	}
end

function second:onAwake(...)
	self:Resize(ResolutionPolicy.Middle, self.bg, true)
	self:Resize(ResolutionPolicy.Middle, self.center)
end


function second:closeClanView(...)
	UIManager:DestroyUI(UIConfig.second_view)
end

function second:onDestroy( ... )
	print('--释放')
end
return second 