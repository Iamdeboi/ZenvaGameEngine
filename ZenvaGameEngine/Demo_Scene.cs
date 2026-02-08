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
        int score = 0;
        Label scoreLabel;

        public Demo_Scene(string levelName) : base(levelName)
        {

        }

        public override void OnLoad()
        {
            player = new Player(new Vector2(400, 400), new Vector2(50, 50), "player");
            player.CollisionDebug(true);
            player.onCollisionEventHandlers.Add(Body_OnCollision);
            Shape2D box = new Shape2D(Shape2D.SHAPES.RECTANGLE, new Vector2(500, 500), new Vector2(50, 50), "box", Color.Transparent, Color.Red);
            Wall wall = new Wall(new Vector2(300, 400), new Vector2(50, 50), "wall");
            scoreLabel = new Label("Score: 0", 32, new Vector2(400,100), Color.White, "scoreLabel", true);
        }


        private bool Body_OnCollision(nkast.Aether.Physics2D.Dynamics.Fixture sender, nkast.Aether.Physics2D.Dynamics.Fixture other, nkast.Aether.Physics2D.Dynamics.Contacts.Contact contact)
        {
            Log.Info(LevelName + " Collides!");
            return true; 
        }

        public override void OnUpdate()
        {
            scoreLabel.Text = ($"score: {score}");
        }
    }
}
