==========================================================================
  Copyright © 2018-2019 Mogoson. All rights reserved.
  Name: MGS-ObjectPool
  Author: Mogoson   Version: 1.0.0   Date: 8/10/2019
==========================================================================
  [Summary]
    Unity object pool.
--------------------------------------------------------------------------
  [Environment]
    Unity 5.0 or above.
    .Net Framework 3.5 or above.
--------------------------------------------------------------------------
  [Achieve]
    GameObjectPool : Recycling objects that need to be repeatedly
    created and destroyed.

    GameObjectPoolManager : Manage gameobject pool and provide an
    instance for global. 
--------------------------------------------------------------------------
  [Usage]
    Create an empty gameobject and attach the GameObjectPoolManager to it.

    Add pool and config it's parameters in the Pools Settings of
    GameObjectPoolManager.

    Use the API GameObjectPoolManager.Instance.FindPool(string name)
    to get target pool by name.
--------------------------------------------------------------------------
  [Demo]
    Demos in the path "MGS-ObjectPool/Scenes" provide reference to you.
--------------------------------------------------------------------------
  [Resource]
    https://github.com/mogoson/MGS-ObjectPool.
--------------------------------------------------------------------------
  [Contact]
    If you have any questions, feel free to contact me at mogoson@outlook.com.
--------------------------------------------------------------------------