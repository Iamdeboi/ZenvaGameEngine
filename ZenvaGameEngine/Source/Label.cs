using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenvaGameEngine.Source
{
    internal class Label : GameObject
    {
        public override Vector2 Position { get ; set; }
        public override Vector2 Origin { get; set; }
        public override Vector2 Scale { get; set; }
        public override string Tag { get; set; }
        public override List<GameObject> Children { get; set; }

        const string DEFAULTFONTPATH = "Assets/Default Font.ttf";
        public string Text = "";
        public string fontPath = ""; //for different fonts besides the default
        public Font font = null;
        public uint fontSize = 1;
        public bool centered;
        public Color color = Color.White;

        public Label(string text, uint fontSize, Vector2 Position, Color color, string tag, bool centered)
        {
            this.Text = text;
            this.fontSize = fontSize;
            this.Position = Position;
            this.color = color;
            this.Tag = tag;
            this.centered = centered;
            font = new Font(DEFAULTFONTPATH);
        }

        public override void OnFree()
        {
            
        }

        public override void OnLoad()
        {
            
        }

        public override void OnUpdate()
        {
            Text text = new Text(Text, font, fontSize);
            if (centered)
            {
                FloatRect textRect = text.GetLocalBounds(); //gets size/scale of label to assist in changing the origin of the text on the screen
                text.Origin = new Vector2(textRect.Left + textRect.Width * 0.5f, textRect.Top + textRect.Height * 0.5f);
            }
            text.Position = Position;
            text.Color = color;
            Engine.app.Draw(text);
        }
    }
}
