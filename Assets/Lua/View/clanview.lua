-----------------------------
--Author : fu xing
--Des:   测试
-----------------------------
local clanview = class('clanview',UIBase)

function clanview:init( ... )
    self.widget = 
    {
        bg = {'bg','bg'},
        closebtn = {'changelayer','changelayer','Button','closeClanView'}
    }
end

function clanview:onAwake( ... )
    self:Resize(ResolutionPolicy.Middle,self.bg)
    print('-->>onAwake')
end

function clanview:onStart( ... )
    print('-->>onStart')
end

function clanview:closeClanView( ... )
    UIManager:DestroyUI(UIConfig.clanview)
end
return clanview