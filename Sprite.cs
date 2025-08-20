using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace miniRPG
{
    public class Sprite
    {
        public Texture2D texture;
        public Vector2 position;
        public Vector2 size;
        public Rectangle rect
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);
            }
        }
        public Rectangle drect;

        public Sprite(Texture2D texture, Vector2 position, Vector2 size = default(Vector2))
        {
            this.texture = texture;
            this.position = position;
            if (size == default(Vector2)) this.size = new Vector2(this.texture.Width, this.texture.Height);
            else this.size = size;
            this.drect = rect;
        }
        
        public void Draw(SpriteBatch spriteBatch, Vector2 offset)
        {
            this.drect = new(
                this.rect.X + (int)offset.X,
                this.rect.Y + (int)offset.Y,
                this.rect.Width, this.rect.Height);
            
            spriteBatch.Draw(this.texture, drect, Color.White);
        }

        
    }
}
