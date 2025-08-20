using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;



namespace miniRPG
{
    internal class YSortCamera
    {
        public Vector2 position;

        public YSortCamera(Vector2 pos)
        {
            this.position = pos;
        }

        public void Follow(Rectangle target, Vector2 screenSize)
        {
            position = new Vector2(
                -target.X + (screenSize.X / 2 - target.Width / 2),
                -target.Y + (screenSize.Y / 2 - target.Height / 2));
        }

        public void Draw(SpriteBatch spriteBatch, List<Sprite> spriteList)
        {
            List<Sprite> sortedSprites = spriteList.OrderBy(obj => obj.drect.Bottom).ToList();
            foreach (Sprite sprite in sortedSprites) sprite.Draw(spriteBatch, position);
        }
    }
}
