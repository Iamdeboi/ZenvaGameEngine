using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenvaGameEngine.Source
{
    abstract class Engine
    {
        //Height and width
        public uint height = 500;
        public uint width = 500;

        //Window title
        public string title = "Zenva Game Engine 0.0.1";

        //Window color
        public SFML.Graphics.Color windowColor = SFML.Graphics.Color.Black;

        //Window Renderer
        public static RenderWindow app;

        //Camera
        public static View camera;
        public static List<Camera> AllCameras = new List<Camera>();

        //Gameobjects
        public static List<GameObject> GameObjects = new List<GameObject>();
        public static List<GameObject> GameObjectsToAdd = new List<GameObject>();
        public static List<GameObject> GameObjectsToRemove = new List<GameObject>();


        public Engine(uint WIDTH, uint HEIGHT, string TITLE, SFML.Graphics.Color WINDOWCOLOR)
        {
            this.width = WIDTH; 
            this.height = HEIGHT;
            this.title = TITLE;
            this.windowColor = WINDOWCOLOR;
             
            app = new RenderWindow(new VideoMode(width, height), title, style: Styles.Resize | Styles.Close);
            app.KeyPressed += App_KeyPressed;
            app.KeyReleased += App_KeyReleased;
            app.Closed += App_Closed;
            app.Resized += App_Resized;
            app.SetFramerateLimit(144);
            camera = app.GetView();
            app.SetView(camera);

            GameLoop();
        }

        private void App_Resized(object? sender, SizeEventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;

            FloatRect visibleArea = new FloatRect(0, 0, e.Width, e.Height);
            window.SetView(new View(visibleArea));
        }

        private void App_Closed(object? sender, EventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }

        private void App_KeyReleased(object? sender, KeyEventArgs e)
        {
            Input.GetKeyUp(e);
        }

        private void App_KeyPressed(object? sender, KeyEventArgs e)
        {
            Input.GetKeyDown(e);
        }

        public static void RegisterGameObject(GameObject gameObject)
        {
            GameObjectsToAdd.Add(gameObject);
        }

        public static void UnRegisterGameObject(GameObject gameObject)
        {
            GameObjectsToRemove.Add(gameObject);
        }


        void GameLoop()
        {
            LoadObjects();
            OnLoad();
            while (app.IsOpen)
            {
                app.DispatchEvents();
                app.Clear(windowColor);

                UpdateObjects();
                OnUpdate();

                app.Display();
            }
        }

        public void LoadObjects()
        {
            foreach(var gameObject in GameObjects)
            {
                gameObject.OnLoad();
            }
        }
        //Add and Remove Objects via this function
        public void UpdateObjects()
        {
            Time.UpdateTime();
            

            if(GameObjects == null)
            {
                return;
            }

            for(int i = 0; i < GameObjects.Count; i++)
            {
                GameObjects[i].OnUpdate();
                GameObjects[i].UpdateChildren();
            }

            if(GameObjectsToAdd.Count > 0)
            { //For instead of "foreach" to prevent crashing when adding new items in the list while this function is still running
                for(int i = 0; i < GameObjectsToAdd.Count; i++)
                {
                    GameObjectsToAdd[i].OnLoad();
                    GameObjects.Add(GameObjectsToAdd[i]);
                }
                GameObjectsToAdd.Clear();
            }

            if(GameObjectsToRemove.Count > 0)
            {
                for (int i = 0; GameObjectsToRemove.Count > i; i++)
                {
                    GameObjectsToRemove[i].OnFree();
                    GameObjects.Remove(GameObjectsToRemove[i]);
                }
                GameObjectsToRemove.Clear();
            }

        }

        public abstract void OnLoad();

        public virtual void OnUpdate()
        {
            LevelManager.UpdateLevel();

        }
    }
}
