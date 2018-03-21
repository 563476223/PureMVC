
local AppEntry = {}

function AppEntry:ImportGlobal(...)
	require('Assets.Lua.Framework.Functions')
	Event = require("Assets.Lua.Framework.Event")
	EventLib = require("Assets.Lua.Framework.EventLib")
	UIConfig = require("Assets.Lua.ConfigData.UIConfig")
	Utils = require("Assets.Lua.Tools.Utils")
	UIBase = require("Assets.Lua.View.UIBase")
	UIManager = require("Assets.Lua.Manager.UIManager")
	
end

function AppEntry:initLayerValue(...)
	MiddleLayer = UnityEngine.GameObject.Find("UI/Middle").transform
	BottomLayer = UnityEngine.GameObject.Find("UI/Bottom").transform
	TopLayer = UnityEngine.GameObject.Find("UI/Top").transform
end

function AppEntry:Start()
	self:ImportGlobal()
    self:initLayerValue()
	UIManager:OpenUI(UIConfig.common_view)
end

return AppEntry 