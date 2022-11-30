[TOC]

# MGS.DesignPattern

## Summary
- Design pattern code for C# project develop.
- Design pattern code for Unity project develop.

## Environment
- Unity 5.0 or above.
- .Net Framework 3.5 or above.

## Version

- 1.3.0

## Platform
- Windows.

## Demand
- Provide a single instance of the specified type T.
- Generic object pool.

## Usage

### Object Pool

- ObjectPoolPro

```C#
//Implement custom object.
public class CustomObject : IResettable
{
    public void Reset()
    {
        //TODO: Reset the object.
    }

    public void Dispose()
    {
        //TODO: Dispose the object.
    }
}

//Use ObjectPoolPro in your class.
public class TestCase
{
    public TestCase()
    {
        //Create pool for CustomObject.
        var pool = new ObjectPoolPro<CustomObject>();

        //Take a instance of CustomObject from pool.
        var obj = pool.Take();

        //Recycle object to pool if we do not need it.
        pool.Recycle(obj);
    }
}
```

- GameObjectPool

  - Create game object pool.

  ```C#
  //The prefab as template of reusable game object.
  var pool = GameObjectPoolManager.Instance.CreatePool(poolName, prefab);
  ```

  - Use pool to Take, Recycle game object.

  ```C#
  //Use pool name to find the instance of pool from manager if we do not hold it.
  var pool = GameObjectPoolManager.Instance.FindPool(poolName);
  
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

- Singleton

```C#
//Custom classs with a single instance.
public sealed class TestSingleton : Singleton<TestSingleton>
{
    public string testField = "Test Field";

    //Private parameterless constructor to ensure singleton.
    private TestSingleton() { }
}

//Use Instance to accessing fields, properties and methods. 
var testInfo = TestSingleton.Instance.testField;


//Custom classs with a single instance and thread cruise.
public sealed class TestSingleCruiser : SingleCruiser<TestSingleCruiser>
{
    //Private parameterless constructor to ensure singleton.
    private TestSingleUpdater() { }
    
    protected override void Cruise()
    {
        //TODO: do something.
    }
}
```

- Single Component

```C#
//Provide a auto create, lazy and thread safety single instance of component T;
//Specified component T should with the sealed access modifier to ensure singleton.
//Do not add the component T to any gameobject by yourself.
public sealed class UIManager : SingleComponent<UIManager>
{
    public RectTransfrom FindUI(string name)
    {
        //TODO:
    }
}

//Use Instance to accessing fields, properties and methods. 
var helpUI = UIManager.Instance.FindUI("UI_Help");
```

- Single Behaviour

```C#
//Use the properties and methods inherit from MonoBehaviour.
SingleBehaviour.Instance.StartCoroutine(coroutine);

//Use the extended events.
SingleBehaviour.Instance.OnApplicationQuitEvent += () =>
{
    //TODO:
};
```

## Demo
- Demos in the path "MGS.Packages/DesignPattern/Demo/" provide reference to you.

## Source
- https://github.com/mogoson/MGS.DesignPattern.

------

Copyright © 2021 Mogoson.	mogoson@outlook.com