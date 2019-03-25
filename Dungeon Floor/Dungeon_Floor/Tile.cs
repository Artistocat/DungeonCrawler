using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dungeon_Floor
{
    public class Tile
    {
        private Rectangle rect;
        private Texture2D texture;
        private Rectangle sourceRect;

        public Tile(int x, int y, Texture2D texture) : this(new Rectangle(x * 32, y * 32, 32, 32), texture)
        {

        }

        public Tile(Rectangle rect, Texture2D texture)
        {
            this.rect = rect;
            this.texture = texture;
            sourceRect = new Rectangle(0, 0, 32, 32);
        }

        public void Update(int timer)
        {
            if (texture.Width > 32 && timer % 4 == 0)
                sourceRect.X = (sourceRect.X + 32) % texture.Width;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rect, sourceRect, Color.White);
        }
    }
}
