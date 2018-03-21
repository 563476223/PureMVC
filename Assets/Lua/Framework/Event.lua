
-----------------------------
--Author : fu xing
--Des:   事件
-----------------------------
local Event = {}

local events = {}
local eventID = 0
function Event:AddListener(event, handler)
	if not event or type(event) ~= 'string' then
		print('event parameter is not string')
	end
	
	if not handler or type(handler) ~= 'function' then
		print('handler parameter is not function')
	end
	
	if not events[event] then
		events[event] = EventLib.New(event)
	end
	eventID = eventID + 1
	events[event]:connect(handler,eventID)
	return eventID
end

function Event:Trigger(event, ...)
	if not events[event] then
		print('Trriger ' .. event .. ' has no event')
	else
        events[event]:trigger(...)
	end
end

function Event:RemoveListener(event, eventID)
	if not events[event] then
		print('remove ' .. event .. 'has no event')
	else
		events[event]:remove(eventID)
	end
end

return Event 