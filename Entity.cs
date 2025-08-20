

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace miniRPG
{
    public class Entity : Sprite
    {
        public Vector2 velocity;

        public Entity(Texture2D texture, Vector2 position, Vector2 size) : base(texture, position, size)
        {
            this.velocity = new Vector2(0, 0);
        }

        public void moveAndCollide(List<Rectangle> rectList)
        {
            Rectangle nextRect = new Rectangle(this.rect.X + (int)this.velocity.X, this.rect.Y + (int)this.velocity.Y,
                                                this.rect.Width, this.rect.Height);
            bool collided = false;
            foreach (Rectangle oppRect in rectList)
            {
                if (oppRect.Intersects(nextRect)) collided = true;
            }

            if (!collided)
            {
                this.position.X += this.velocity.X;
                this.position.Y += this.velocity.Y;
            }
        }
    }

    public class Player : Entity
    {
        private int speed = 100;
        public Player(Texture2D texture, Vector2 position, Vector2 size) : base(texture, position, size) { }

        public void update(KeyboardState ks, GameTime gameTime, List<Rectangle> rectList)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Vector2 dir = new Vector2(0, 0);

            if (ks.IsKeyDown(Keys.W)) dir.Y -= 1;
            if (ks.IsKeyDown(Keys.S)) dir.Y += 1;
            if (ks.IsKeyDown(Keys.A)) dir.X -= 1;
            if (ks.IsKeyDown(Keys.D)) dir.X += 1;

            velocity = dir * speed * deltaTime;
            moveAndCollide(rectList);
        }
    }
}
