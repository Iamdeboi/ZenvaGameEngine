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

        Player player;

        public override void OnLoad()
        {
            player = new Player(new Vector2(400, 400), new Vector2(), "player");
        }


        public override void OnUpdate()
        {
            Log.Info($"Player's Position: {player.Position.x} | {player.Position.y}");


            base.OnUpdate();
        }
    }
}
