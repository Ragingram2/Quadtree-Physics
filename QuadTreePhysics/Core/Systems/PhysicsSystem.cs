using System;
using System.Collections.Generic;
using System.Text;
using SFML.System;

public static class PhysicsSystem
{
    private static List<PhysicsComp> components = new List<PhysicsComp>();
    private static float mass;
    private static Vector2f velocity;
    private static Vector2f acceleration;
    private static Clock clock = new Clock();
    private static Time time = new Time();
    private static float deltaTime = 0;

    public static void Start()
    {
        acceleration = new Vector2f(0,9.8f);
        velocity = new Vector2f(0, 0);
    }

    public static void Update()
    {
         time = clock.Restart();
        deltaTime = time.AsSeconds()/5f;
        //do phys checks here
        foreach (PhysicsComp pc in components)
        {
            velocity += acceleration*deltaTime;
            pc.Update();
            pc.mass = mass;
            pc.velocity = velocity;
        }
    }

    public static void AddComponent(PhysicsComp pc)
    {
        components.Add(pc);
    }
}

