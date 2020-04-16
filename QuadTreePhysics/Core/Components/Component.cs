using System;
using System.Collections.Generic;
using System.Text;


public abstract class Component 
{
    public GameObject parent;
    public abstract void Start();
    public abstract void Update();
}

