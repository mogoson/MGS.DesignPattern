[TOC]

﻿# MGS.UDesignPattern.dll

## Summary

- Design pattern code for Unity project develop.

## Environment

- Unity 5.0 or above.
- .Net Framework 3.5 or above.

## Dependence

- System.dll
- UnityEngine.dll
- MGS.Logger.dll
- MGS.DesignPattern.dll

## Demand

- Provide a single instance of the specified MonoBehaviour.
- Generic game object pool.

## Implemented

### ObjectPool

```C#
/// <summary>
/// Pool of gameobject.
/// </summary>
public class GOPool : ObjectPool<GameObject>{}

/// <summary>
/// Manager of gameobject pool.
/// </summary>
public sealed class GOPoolManager : Singleton<GOPoolManager>
```

### Singleton

```C#
/// <summary>
/// Generic base class for single Component.
/// Inheritance class should with the sealed access modifier to ensure distinct singleton.
/// </summary>
[DisallowMultipleComponent]
public abstract class SingleComponent<T> : MonoBehaviour where T : Component{}

/// <summary>
/// Generic single behaviour.
/// Auto create the generic instance, do not add this component to any GameObject by yourself.
/// </summary>
public sealed class SingleBehaviour : SingleComponent<SingleBehaviour>{}
```

## Usage

### ObjectPool
1. Create game object pool.

   ```c#
   //The prefab as template of reusable game object.
   var pool = GOPoolManager.Instance.CreatePool(poolName, prefab);
   ```

1. Use pool to Take, Recycle game object.

   ```C#
   //Use pool name to find the instance of pool from manager if we do not hold it.
   var pool = GOPoolManager.Instance.FindPool(poolName);
   
   //Take a game object same as prefab.
   var go = pool.Take();
   
   //Recycle the game object to pool if we do not need it.
   pool.Recycle(go);
   
   //Take a game object and get or add component.
   var cpnt = pool.Take<Bullet>();
   
   //Recycle the game object of component to pool if we do not need it.
   pool.Recycle(cpnt);
   ```

### Singleton

- SingleComponent

  ```C#
  //Derived custom single component.
  //Inheritance class should with the sealed access modifier to ensure distinct singleton.
  public sealed class UIManager : SingleComponent<UIManager>
  {
      private void Start()
      {
          //TODO:
      }
  
      public RectTransfrom FindUI(string name)
      {
          //TODO:
      }
  }
  
  //Use Instance to accessing fields, properties and methods. 
  var ui = UIManager.Instance.FindUI("UI_Help");
  ```

- SingleBehaviour

  ```C#
  //Use the properties and methods inherit from MonoBehaviour.
  SingleBehaviour.Instance.StartCoroutine(routine);
  
  //Use the extended events.
  SingleBehaviour.Instance.OnApplicationQuitEvent += () =>
  {
      //TODO:
  };
  ```

------

[Previous](../../README.md)

------

Copyright © 2021 Mogoson.	mogoson@outlook.com