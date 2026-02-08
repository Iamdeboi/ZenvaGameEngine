using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using ZenvaGameEngine.Source;

namespace ZenvaGameEngine
{
    internal class Wall : StaticBody
    {
        public Wall(Vector2 position, Vector2 scale, string tag) : base(position, scale, tag)
        {
            this.Position = position;
            this.Scale = scale;
            this.Tag = tag;
        }

        public override void OnLoad()
        {
            AddChild(new Shape2D(Shape2D.SHAPES.RECTANGLE, new Vector2(), Scale, Tag, Color.White, Color.White));
            
            base.OnLoad();
        }
    }
}
