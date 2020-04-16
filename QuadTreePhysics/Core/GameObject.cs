using System;
using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;

public class GameObject : Sprite
{
    Vector2f maxScale = new Vector2f();
    public List<Component> componentsList = new List<Component>();
    public GameObject(float _x,float _y,float _w,float _h)
    {
        maxScale = new Vector2f(_w, _h);
        Position = new Vector2f(_x, _y);
        Scale = new Vector2f(_w/maxScale.X, _h/maxScale.Y);
    }

    public void Update()
    {

    }

    public void SetScale(float _w,float _h)
    {
        Scale = new Vector2f(_w / maxScale.X, _h / maxScale.Y);
    }

    public GameObject AddComponent(Component comp)
    {
        switch(comp)
        {
            case PhysicsComp pc:
                pc.parent = this;
                componentsList.Add(pc);
                PhysicsSystem.AddComponent(pc);
                break;
        }
        return this;
    }
    public Component GetComponent()
    {
        foreach(Component comp in  componentsList)
        {
            if(comp is PhysicsComp)
            {
                return (PhysicsComp)comp;
            }
            if(comp is Collider)
            {
                return (Collider)comp;
            }
        }
        return null;
    }
}

