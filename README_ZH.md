# MGS-ObjectPool
- [English Manual](./README.md)

## 概述
- Unity对象池。

## 环境
- Unity 5.0 或更高版本。
- .Net Framework 3.0 或更高版本。

## 实现
- ObjectPool：泛型对象池。
- GameObjectPool：游戏对象池，回收利用需要反复创建和销毁的游戏对象。
- SingleMonoBehaviour：单例行为组件，提供一个全局访问的实例。
- GameObjectPoolManager：单例游戏对象管理器，统一管理游戏对象池并提供一个全局访问的实例。

## 案例
- “MGS-ObjectPool/Scenes”目录下存有上述功能的演示案例，供读者参考。

## 预览
- Bullet Pool

![BulletPool](./Attachments/README_Image/BulletPool.gif)

## 联系
- 如果你有任何问题或者建议，欢迎通过mogoson@qq.com联系我。