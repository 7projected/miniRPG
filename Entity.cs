

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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
        private Vector2 lastDir;
        private int speed = 200;

        private int animCounter = 0;
        private int animStage = 0;
        private int animFrameDur = 10;
        Texture2D[] animDown = new Texture2D[3];
        Texture2D[] animUp = new Texture2D[3];

        public Player(Texture2D texture, Vector2 position, Vector2 size) : base(texture, position, size) { }
       

        public void loadAnimations(ContentManager content)
        {
            for (int i = 0; i < 3; i++)
            {
                animDown[i] = content.Load<Texture2D>($"spaceman_down{i}");
                animUp[i] = content.Load<Texture2D>($"spaceman_up{i}");
            }
        }

        public void update(KeyboardState ks, GameTime gameTime, List<Rectangle> rectList)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Vector2 dir = new Vector2(0, 0);

            if (ks.IsKeyDown(Keys.W)) dir.Y -= 1;
            if (ks.IsKeyDown(Keys.S)) dir.Y += 1;
            if (ks.IsKeyDown(Keys.A)) dir.X -= 1;
            if (ks.IsKeyDown(Keys.D)) dir.X += 1;

            updateAnimation(dir);
            animate();
            velocity = dir * speed * deltaTime;
            moveAndCollide(rectList);
        }

        private void updateAnimation(Vector2 dir)
        {
            if (dir.X != 0) lastDir.X = dir.X;
            if (dir.Y != 0) lastDir.Y = dir.Y;

            if (dir != Vector2.Zero)
            {
                if (animStage == 0) animStage = 1;

                animCounter++;
                if (animCounter >= animFrameDur)
                {
                    animCounter = 0;
                    animStage++;
                    if (animStage > animUp.Length - 1) animStage = 1;
                }
            }
            else
            {
                animStage = 0;
            }
        }

        private void animate()
        {
            if (lastDir.Y < 0) base.texture = animUp[animStage];
            else base.texture = animDown[animStage];
        }
    }
}
