Events
===

Events is a replacement for `SendMessage` and `ExecuteEvents` that is simle, flexible and has zero memory allocations. It's based on a custom list pool that automatically re-pools 
its objects after `foreach` iteration finishes.
Events defines several extension methods for GameObject class.

**Enumeration**

The methods `EnumerateComponents`, `EnumerateComponentsInChildren` and `EnumerateComponentsInParent` are a replacement for `GetComponents` etc. They do not allocate any memory, (except for a first-time call), but can only be used in `foreach`. If you need to store components list somewhere, use `GetComponents`:

    foreach (var c in gameObject.EnumerateComponents<Collider>())
    {
        // do something with collider
    }

    collidersList = GetComponents<Collider>(); // use GetComponents for everything besides foreach

**Messages**

The methods `Send`, `SendToChildren` and `SendToParents` replace `SendMessage`, `BroadcastMessage` and `SendMessageUpwards`. They all work the same way: by caling a delegate for all eligible components. All these methods allocate no memory (except for a first-time call), are faster than using `SendMessage` and have complete type safety.

Example:

    gameObject.Send<Collider>(c => c.enabled=false); // disables all colliders

Sending works with interfaces too:

    gameObject.SendToChildren<IFrobbable>(f=>f.Frob()); // call Frob() on all Frobbable components in hierarchy

All methods have overloads with multiple parameters:

    void DoStuff(Transform t, Vector3 dir, float force)
    {
    	///...
    }

    gameObject.SendToParents<Transform>(DoStuff, Vector3.up, 12f);