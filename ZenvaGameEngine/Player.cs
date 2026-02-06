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

        AnimatedSprite2D animator;
        Camera cam; 


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
            animator = new AnimatedSprite2D(1f, new Vector2(4, 4), "Player graphics");
            Animation2D run = new Animation2D("Assets/Run.png", new Vector2(16, 16), 4);
            Animation2D idle = new Animation2D("Assets/idle.png", new Vector2(16, 16), 1);
            animator.AddAnimation("Idle", idle);
            animator.AddAnimation("Run", run);
            AddChild(animator);
            cam = new Camera(true, "Player's Cam");
            AddChild(cam);
        }

        public override void OnUpdate()
        {
            if (Input.ActionPressed("Right"))
            {
                Position.x += 1;
                animator.FlipH = 1;
                animator.Play("Run");
            }
            else if (Input.ActionPressed("Left"))
            {
                Position.x -= 1;
                animator.FlipH = -1;
                animator.Play("Run");
            }
            else
            {
                animator.Play("Idle");
            }

        }
    }
}
