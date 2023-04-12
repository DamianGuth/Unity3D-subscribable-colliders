# Simple Unity3D subscribable colliders

This class allows you to subscribe to collision events of other objects.<br>
By default Unity3D does not allow you to handle collisions of other GameObjects, sadly they also prohibited any extions of the collider classes.

You can find a simple example project here
-- todo

## How to use

### Initialize and create new collider
```csharp
    GameObject objectToWatch = null;

    SubscribableCollider sc = objectToWatch.AddComponent<SubscribableCollider>();

    // Initialize and create new collider.
    sc.Initialize(typeof(SphereCollider));
```
### Initialize without creating a new collider
```csharp
    GameObject objectToWatch = null;
    BoxCollider existingCollider = GameObject.FindWithTag("test").GetComponent<BoxCollider>();

    SubscribableCollider sc = objectToWatch.AddComponent<SubscribableCollider>();

    // Initialize without creating a new collider.
    sc.Initialize(existingCollider);
```

### Modify tracked collider
```csharp
    ((SphereCollider)sc.GetTrackedCollider()).radius = 2;
```

### Subscribe to events
```csharp
    // Demo collision.
    sc.OnPhysicsCollisionEnter += CollisionEnter;
    sc.OnPhysicsCollisionExit += CollisionExited;
    sc.OnPhysicsCollisionStay += CollisionStay;

    // Demo triggers.
    sc.OnPhysicsTriggerEnter += TriggerEnter;
    sc.OnPhysicsTriggerExit += TriggerExited;
    sc.OnPhysicsTriggerStay += TriggerStay;

    public void CollisionEnter(Collision collision)
    {
        Debug.Log("COLLISION ENTER");
    }

    public void CollisionExited(Collision collision)
    {
        Debug.Log("COLLISION EXIT");
    }

    public void CollisionStay(Collision collision)
    {
        Debug.Log("COLLISION STAY");
    }

    public void TriggerEnter(Collider collider)
    {
        Debug.Log("TRIGGER ENTER");
    }

    public void TriggerExited(Collider collider)
    {
        Debug.Log("TRIGGER EXIT");
    }

    public void TriggerStay(Collider collider)
    {
        Debug.Log("TRIGGER STAY");
    }
```