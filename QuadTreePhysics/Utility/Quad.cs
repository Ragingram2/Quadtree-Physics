using System;
using System.Collections.Generic;
using System.Text;
using SFML.System;
using System.Drawing;
public class Quad
{
    int width, height;
    Vector2f position = new Vector2f();
    public List<GameObject> gameObjects = new List<GameObject>();
    public Quad(Vector2f _pos,Size _size)
    {
        width = _size.Width;
        height = _size.Height;
        position = _pos;
    }

    public bool Contains(GameObject go)
    {
        if(go.Position.X > position.X && go.Position.X < position.X+width/2 && go.Position.Y > position.Y && go.Position.Y< position.Y+height/2)
        {
            return true;
        }
        return false;
    }
}
