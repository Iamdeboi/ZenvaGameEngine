using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using ZenvaGameEngine.Source;

namespace ZenvaGameEngine
{
    internal class Player : GameObject
    {
        public override Vector2 Position { get; set; }
        public override Vector2 Origin { get; set; }
        public override Vector2 Scale { get; set; }
        public override string Tag { get; set; }
        public override List<GameObject> Children { get; set; }

        //Constructor
        public Player(Vector2 position, Vector2 scale, string tag)
        {
            this.Position = position;
            this.Origin = position;
            this.Scale = scale;
            this.Tag = tag;
        }

        //Inherited Functions from GameObject
        public override void OnFree()
        {
            
        }

        public override void OnLoad()
        { 
            Shape2D shape = new Shape2D(Shape2D.SHAPES.RECTANGLE , new Vector2(), new Vector2(50, 50), "IamDeShape!", Color.Transparent, Color.White);
            AddChild(shape);
        }

        public override void OnUpdate()
        {
            if (Input.ActionPressed("Right"))
            {
                Position.x += 1;
            }
            if (Input.ActionPressed("Left"))
            {
                Position.x -= 1;
            }
        }
    }
}
