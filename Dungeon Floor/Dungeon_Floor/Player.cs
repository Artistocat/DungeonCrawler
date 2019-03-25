using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dungeon_Floor
{
    public class Player
    {
        Rectangle rect;
        Texture2D texture;
        public Player(Texture2D texture)
        {
            this.texture = texture;
            rect = new Rectangle(0, 0, 32, 32);
        }



    }
}
