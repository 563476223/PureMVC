-----------------------------
--Author : fu xing
--Des:   ui 基类
-----------------------------
local UIBase = class('UIBase')

ResolutionPolicy =
{
	LeftTop = 1,
	MiddleTop = 2,
	RightTop = 3,
	LeftMiddle = 4,
	Middle = 5,
	RightMiddle = 6,
	LeftBottom = 7,
	MiddleBottom = 8,
	RightBottom = 9
}

function UIBase:Ctor(data)
	self.widget = {}
	self.gameObject = nil
	self.transform = nil
	self.displaying = false     --UI是否加载完成
	self.isCreateing = false    --是否正在加载UI
	self:init(data)
end

function UIBase:Show(uiType, data)
	if not self.isCreateing then
		self.isCreateing = true
		self:loadUI(uiType, data)
	else
		self:Start(data)
	end
end

function UIBase:loadUI(uiType, data)
	local assetpath = "Assets/Resources/" .. uiType.assetpath .. '.prefab'
	AssetsFactory.Instance:LoadAssetAsync(assetpath, function(prefab)
		AssetsFactory.Instance:UnLoadAsset(assetpath, false)
		self.displaying = true
		self.transform = Utils:AddChild(self:getLayer(uiType.layer or 'middle'), prefab)
		self.gameObject = self.transform.gameObject
		self:getWidget()
		self:Awake()
		self:Start(data)
	end)
end

--根据self.widget获取组件,注册必须在init里面完成
--FindChild {xx = {'查找的组件名','路径'}}
--GetComponent {xx = {'查找的组件名','路径','组件类型'}}
--注册事件 {xx = {'查找的组件名','路径','组件类型','方法名'}}
function UIBase:getWidget(...)
	for k, v in pairs(self.widget) do
		if #v == 2 then
			self[k] = self:FindChild(v[1], v[2])
		elseif #v == 3 then
			self[k] = self:GetComponent(v[3], v[2], v[1])
		elseif #v == 4 then
			local tr = self:FindChild(v[1], v[2])
			if v[3] == 'Button' then  --根据类型自行添加事件
				self:AddButtonEvent(tr, Handler(self, self[v[4]]))
			end
		end
	end
end

-------外部接口
--构造，此时UI未加载,注册UI刷新事件
function UIBase:init(...)
	
end

function UIBase:Awake( ... )
	self:onAwake()
end

--此时UI创建只是调用一次
function UIBase:onAwake( ... )
	
end

function UIBase:onDestroy(...)
	
end

--隐藏
function UIBase:onClose(...)
	
end

--此时UI，已经加载完成，每次显示UI都会调用
function UIBase:onStart(data)
	
end

function UIBase:Start(data)
	self.gameObject:SetActive(true)
	self:onStart(data)
end

--释放UI的同时，删除该模块的图集,不能继承，只能通过管理类调用
function UIBase:Destroy(...)
	if self.displaying then
		self:onDestroy()
		TransformUtils.UnloadUIAtlas(self.transform)
		UnityEngine.Object.Destroy(self.gameObject);
	end
end

function UIBase:Close(...)
	if self.displaying then
		self:onClose()
		self.gameObject:SetActive(false)
	end
end

--适配策略
function UIBase:Resize(resolutionPolicy, rectTransform, isFull)
	TransformUtils.ResizeRectTransform(resolutionPolicy, rectTransform, isFull)
end

--获取组件
--规则  找到该路径的节点，然后获取该节点上面的component
--component 组件类型
--path 路径
--父节点
function UIBase:GetComponent(component, path, parent)
	if parent == nil then
		parent = self.transform
	elseif type(parent) == 'string' then
		parent = self:FindChild(parent)
	end
	return TransformUtils.GetComponent(parent, component, path);
end

--获取组件
--1.如果childName如果为路径必须为全路径
--2.parent如果为string，必须唯一
function UIBase:FindChild(childName, parent)
	if parent == nil then
		parent = self.transform
	elseif type(parent) == 'string' then
		parent = self:FindChild(parent)
	end
	return TransformUtils.FindChild(parent, childName)
end

--事件的监听
function UIBase:AddButtonEvent(btn, func)
	UIEvent.AddButtonEvent(btn,func)
end

function UIBase:AddToggleEvent(toggle, func)
	UIEvent.AddToggleEvent(toggle, func)
end

function UIBase:AddToggleGroup(toggle, group)
	UIEvent.AddToggleGroup(toggle, group)
end

--设置输入框的值改变事件
function UIBase:AddInputValueChangeEvent(input, func)
	UIEvent.AddInputValueChangeEvent(input, func)
end

--设置输入框失去焦点调用
function UIBase:AddInputEndEditEvent(input, func)
	UIEvent.AddInputEndEditEvent(input, func)
end

--设置滑动块值改变事件
function UIBase:AddSliderValueChangeEvent(slider, func)
	UIEvent.AddSliderValueChangeEvent(slider, func)
end

function UIBase:RemoveButtonEvent(target)
	UIEvent.RemoveButtonEvent(target);
end

function UIBase:RemoveToggleEvent(target)
	UIEvent.RemoveToggleEvent(target);
end

--层级获取
function UIBase:getLayer( layerName )
	if layerName == 'middle' then
		return MiddleLayer
	elseif layerName == 'bottom' then
		return BottomLayer
	elseif layerName == 'top' then
		return TopLayer
	end
end

return UIBase 