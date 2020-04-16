using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using SFML.System;

public static class QuadTree
{
    public static List<GameObject> Init(int width, int height, List<GameObject> gameObjects)
    {
        Quad quad1 = new Quad(new Vector2f(0, 0), new Size(width / 2, height / 2));
        Quad quad2 = new Quad(new Vector2f(width / 2, 0), new Size(width / 2, height / 2));
        Quad quad3 = new Quad(new Vector2f(0, height / 2), new Size(width / 2, height / 2));
        Quad quad4 = new Quad(new Vector2f(width / 2, height / 2), new Size(width / 2, height / 2));
        foreach(GameObject go in gameObjects)
        {
            if(quad1.Contains(go))
            {
                quad1.gameObjects.Add(go);
                continue;
            }
            if (quad2.Contains(go))
            {
                quad2.gameObjects.Add(go);
                continue;
            }
            if (quad3.Contains(go))
            {
                quad3.gameObjects.Add(go);
                continue;
            }
            if (quad4.Contains(go))
            {
                quad4.gameObjects.Add(go);
                continue;
            }
        }
        return new List<GameObject>();
    }

    public static void Branch(Quad quad)
    {

    }
}

