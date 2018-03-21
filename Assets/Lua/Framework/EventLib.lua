-----------------------------
--Author : fu xing
--Des:   
-----------------------------
local EventLib = class('EventLib')
function EventLib:Ctor( eventName)
    self.handlers = {}
    self.eventName = eventName
end

function EventLib:connect( handler ,eventID)
    if not handler or type(handler) ~= 'function' then
        print('handl Invalid Handle')
    end
    table.insert( self.handlers,{handler,eventID} )
end

function EventLib:remove( eventID )
    if not eventID or type(eventID) ~= 'number' then
        print('remove invalid eventID' )
    end

    for k,v in ipairs(self.handlers) do
        if v[2] == eventID then
            table.remove( self.handlers,k)
            break
        end
    end
end

function EventLib:trigger( ... )
    local args = {...}
    for i,v in ipairs(self.handlers) do
        v[1](...)
    end
end

return EventLib



