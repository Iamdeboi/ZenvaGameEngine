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
    internal class Player : KinematicBody
    {
        public override Vector2 Position { get; set; }
        public override Vector2 Origin { get; set; }
        public override Vector2 Scale { get; set; }
        public override string Tag { get; set; }
        public override List<GameObject> Children { get; set; }

        AnimatedSprite2D animator;
        Camera cam;
        int speed = 200;

        bool LookingRight = true;


        //Constructor
        public Player(Vector2 position, Vector2 scale, string tag) : base(position, scale, tag)
        {
            this.Position = position;
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

            base.OnLoad();
        }

        public override void OnUpdate()
        {
            velocity.x = Convert.ToInt32(Input.ActionPressed("Right")) - Convert.ToInt32(Input.ActionPressed("Left"));
            velocity.y = Convert.ToInt32(Input.ActionPressed("Down")) - Convert.ToInt32(Input.ActionPressed("Up"));

            velocity = velocity.Normalize() * new Vector2(speed, speed); // Always move in accordance to speed variable, after normalizing the input vector2

            Move();
            HandleAnimations();

            base.OnUpdate();
        }

        void HandleAnimations()
        {
            if(velocity.x == 0 && velocity.y == 0)
            {
                animator.Play("Idle");
            }
            else
            {
                animator.Play("Run");
            }

            if (velocity.x > 0 != LookingRight)
            {
                flip();
            }
            if(velocity.x < 0 && LookingRight)
            {
                flip();
            }
        }

        void flip()
        {
            animator.FlipH = -animator.FlipH;
            LookingRight = !LookingRight;
        }

    }
}
