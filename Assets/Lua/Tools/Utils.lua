-----------------------------
--Author : fu xing
--Des:   
-----------------------------
local Utils = {}

--实例化预制件
function Utils:AddChild(parent, prefab)
	local go = UnityEngine.GameObject.Instantiate(prefab)
	if go and parent then
		local tr = go.transform
		tr:SetParent(parent)
		tr.localPosition = UnityEngine.Vector3.one
		tr.localScale	= UnityEngine.Vector3.one
		tr.localRotation = Quaternion.identity
	end
	go.gameObject:SetActive(true)
	return go.transform
end


return Utils
