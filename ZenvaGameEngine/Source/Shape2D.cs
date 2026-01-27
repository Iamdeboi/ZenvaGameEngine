using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenvaGameEngine.Source
{
    internal class Shape2D : GameObject
    {
        public override Vector2 Position { get; set; }
        public override Vector2 Origin { get; set; }
        public override Vector2 Scale { get; set; }
        public override string Tag { get; set; }
        public override List<GameObject> Children { get; set; }

        public enum SHAPES
        {
            RECTANGLE,
            CIRCLE
        }

        public SHAPES shape;

        public SFML.Graphics.Color color = SFML.Graphics.Color.White;
        public SFML.Graphics.Color outLineColor = SFML.Graphics.Color.White;
        public float OutLineThickness = 1.0f;


        public Shape2D(SHAPES shapes, Vector2 position, Vector2 scale, string tag, SFML.Graphics.Color color, SFML.Graphics.Color outlinecolor)
        {
            this.shape = shapes;
            this.Position = position;
            this.Scale = scale;
            this.Tag = tag;
            this.color = color;
            this.outLineColor = outlinecolor;

            Log.Info($"SHAPE2D {tag} has been registered!");
        }

        public override void OnFree()
        {
            
        }

        public override void OnLoad()
        {
            
        }

        public override void OnUpdate()
        {
            if(shape == SHAPES.RECTANGLE)
            {
                RectangleShape graphics = new RectangleShape(Scale);
                graphics.Origin = Scale * new Vector2(0.5f, 0.5f);
                graphics.Position = Position;
                graphics.FillColor = color;
                graphics.OutlineColor = outLineColor;
                graphics.OutlineThickness = OutLineThickness;
                Engine.app.Draw(graphics);
            }

            else
            {
                CircleShape graphics = new CircleShape(Scale.x);
                graphics.Origin = Scale * new Vector2(0.5f, 0.5f);
                graphics.Position = Position;
                graphics.FillColor = color;
                graphics.OutlineColor = outLineColor;
                graphics.OutlineThickness = OutLineThickness;
                Engine.app.Draw(graphics);
            }
        }
    }
}
