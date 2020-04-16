using System;
using System.Collections.Generic;
using System.Text;
using SFML;
using SFML.Graphics;
using SFML.System;


class Pixel : GameObject
{
    Texture texture = new Texture(new Image(1, 1, Color.White), new IntRect(new Vector2i(0, 0), new Vector2i(1, 1)));
    
    Vector2f lastPosition;
    public Pixel(float _x, float _y) : base(_x, _y, 1, 1)
    {
        Position = new Vector2f(_x, _y);
        Texture = texture;
        AddComponent(new PhysicsComp());
    }
    public Pixel(Vector2f pos) : base(pos.X, pos.Y, 1, 1)
    {
        Position = pos;
        Texture = texture;
        AddComponent(new PhysicsComp());
    }

    public void Update()
    {
        PhysicsComp pc = (PhysicsComp)GetComponent();
        lastPosition = Position;
        if(Position.Y >= 150)
        {
            pc.velocity = new Vector2f(0, 0);
        }
        Position += pc.velocity;
    }
}

