using System;
using System.Collections.Generic;
using System.Text;
using SFML.System;

public static class CollisionSystem
{
    private static List<Collider> components = new List<Collider>();
    private static List<GameObject> collidables = new List<GameObject>();
    private static Clock clock = new Clock();
    private static Time time = new Time();
    private static float deltaTime = 0;

    public static void Start()
    {
        foreach(Collider c in components)
        {
            c.Start();
        }
    }

    public static void Update()
    {
        time = clock.Restart();
        deltaTime = time.AsSeconds() / 5f;
        foreach (Collider c in components)
        {
            c.Update();
        }
    }

    public static void AddComponent(Collider collider)
    {
        components.Add(collider);
    }
}
