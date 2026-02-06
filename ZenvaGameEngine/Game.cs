using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenvaGameEngine.Source;

namespace ZenvaGameEngine
{
    internal class Game : Engine
    {
        public Game() : base((uint)800, (uint)800, "Engine Test", Color.Black) { }



        public override void OnLoad()
        {
            Demo_Scene level1 = new Demo_Scene("level1");
            Demo_Scene_2 level2 = new Demo_Scene_2("level2");
            LevelManager.ChangeLevel("level1");

        }

        public override void OnUpdate()
        {
            if (Input.ActionJustPressed("Up"))
            {
                LevelManager.ChangeLevel("level2");
            }
            if (Input.ActionJustPressed("Down"))
            {
                LevelManager.ChangeLevel("level1");
            }

            base.OnUpdate();
        }
    }
}

