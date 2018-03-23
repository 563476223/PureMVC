# PureMVC
### PureMVC的结构 
> PureMVC目标很明确，将程序分为低耦合的三层：Model、View、Controller。
 在PureMVC实现的mvc元设计模式中，这三部分由三个单例管理，称为core核心层，还有另外一个单例Facade，Facade提供了与核心层通信的唯一接口
 
### Model与Proxy
Model保存Proxy的引用。Proxy 负责操作数据模型，与远程服务通信存取数据。

### View与Mediator
View保存Mediator的引用。Mediator 操作具体的视图组件。

### Controller和Commond
Controller保存了Commond的引用。Commond可以获取Proxy对象并与之交互，可以发送Notification执行其他的Commond，其业务逻辑可以在这里实现。

### Facade和Core
Facade 整个app的单例，职责初始化Core。使用者无需关心Core的创建，Facade提供Public方法方便Core之间的相互通信。

## 具体介绍
### Facade
设计为抽象类，外部注册具体的commond、proxy、mediator类型，应用继承Facade即可创建整个PureMVC，开发者无需关心Core层，提供部分API给外部使用。

### Commond
可用于实现一些复杂行为，可以持有多个Mediator和多个Proxy进行两者交互逻辑。

### Proxy
接受服务器数据，可以持有本地配置数据，当状态改变是进行消息分发，注意：只分发消息，不监听，减少外部对她的耦合性。

### Mediator
视图组件，可持有多个Proxy对象，当外部状态更新时，通知视图组件更新即可，监听外部消息

### Event
为了降低Core之间的耦合，提供事件机制。
