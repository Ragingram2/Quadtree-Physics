using System;
using SFML;
using SFML.Graphics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;
using SFML.System;

namespace QuadTreePhysics
{
    class Program
    {
        public static List<GameObject> pixels = new List<GameObject>();
        static void Main(string[] args)
        {
            RenderWindow window = new RenderWindow(new VideoMode(200, 200), "test");
            window.Closed += new EventHandler(OnClose);
            window.MouseButtonPressed += new EventHandler<MouseButtonEventArgs>(Spawn);

            PhysicsSystem.Start();
            window.SetActive();
            while (window.IsOpen)
            {
                window.Clear();
                PhysicsSystem.Update();
                foreach (Pixel go in pixels)
                {
                    go.Update();
                    window.Draw(go);
                }
                window.DispatchEvents();
                window.Display();

            }
        }
        static void OnClose(object sender, EventArgs e)
        {
            // Close the window when OnClose event is received
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }
        static void Spawn(object sender, EventArgs e)
        {
            Vector2f randPos = new Vector2f(new Random().Next(0,200),10);
            pixels.Add(new Pixel(randPos));
            Console.WriteLine("Called");
        }
    }
}
