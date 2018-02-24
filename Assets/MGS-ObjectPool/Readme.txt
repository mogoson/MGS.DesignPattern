==========================================================================
  Copyright © 2018 Mogoson. All rights reserved.
  Name: MGS-ObjectPool
  Author: Mogoson   Version: 0.1.0   Date: 2/24/2018
==========================================================================
  [Summary]
    Unity object pool.
--------------------------------------------------------------------------
  [Environment]
    Unity 5.0 or above.
    .Net Framework 3.0 or above.
--------------------------------------------------------------------------
  [Achieve]
    ObjectPool : Generic object pool.

    GameObjectPoolType : Define types of gameobject pool.

    GameObjectPool : Recycling objects that need to be repeatedly
    created and destroyed.

    SingleMonoBehaviour : Provide an instance for global.

    GameObjectPoolManager : Manage gameobject pool and provide an
    instance for global. 
--------------------------------------------------------------------------
  [Usage]
    Modify the GameObjectPoolType to define your pool type.

    Create an empty gameobject and attach the GameObjectPoolManager to it.

	Add pool and config it's parameters in the Pools Settings of
	GameObjectPoolManager.

    Use the API GameObjectPoolManager.Instance.GetPool(GameObjectPoolType type)
    to get target pool by type.
--------------------------------------------------------------------------
  [Demo]
    Demos in the path "MGS-ObjectPool/Scenes" provide reference to you.
--------------------------------------------------------------------------
  [Resource]
    https://github.com/mogoson/MGS-ObjectPool.
--------------------------------------------------------------------------
  [Contact]
    If you have any questions, feel free to contact me at mogoson@qq.com.
--------------------------------------------------------------------------