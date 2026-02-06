using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenvaGameEngine.Source;
using SFML.Graphics;

namespace ZenvaGameEngine
{
    internal class Demo_Scene : Level
    {
        public override string LevelName { get; set; }
        public override bool Init { get; set; }

        Player player;

        public Demo_Scene(string levelName) : base(levelName)
        {

        }

        public override void OnLoad()
        {
            player = new Player(new Vector2(400, 400), new Vector2(), "player");
            Shape2D box = new Shape2D(Shape2D.SHAPES.RECTANGLE, new Vector2(500, 500), new Vector2(50, 50), "box", Color.Transparent, Color.Red);

        }

        public override void OnUpdate()
        {
            
        }
    }
}
