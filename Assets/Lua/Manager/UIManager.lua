-----------------------------
--Author : fu xing
--Des:   ui Manager
-----------------------------
local UIManager = {}

local cacheUI = {}

--打开UI
function UIManager:OpenUI(uiType, ...)
	local ui = self:GetUI(uiType)
	if not ui then
		print('打开ui ' .. uiType.classname .. '为空')
	else
		ui:Show(uiType, ...)
	end
end

--隐藏UI
function UIManager:CloseUI(uiType)
	local ui = self:GetUI(uiType)
	if not ui then
		print('关闭ui ' .. uiType.classname .. '为空')
	else
		ui:Close()
	end
end

--释放UI
function UIManager:DestroyUI(uiType)
	local ui = self:GetUI(uiType)
	if not ui then
		print('释放ui ' .. uiType.classname .. '为空')
	else
		ui:Destroy()
		if cacheUI[uiType.assetpath] then
			cacheUI[uiType.assetpath] = nil
		end
	end
end

--获取UI
function UIManager:GetUI(uiType)
	if not cacheUI[uiType.assetpath] then
		cacheUI[uiType.assetpath] = require('Assets.Lua.View.' .. uiType.classname).New()
	end
	return cacheUI[uiType.assetpath]
end

return UIManager 