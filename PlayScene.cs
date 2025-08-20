using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;

namespace miniRPG
{
    internal class PlayScene : IScene
    {

        private ContentManager contentManager;
        private YSortCamera camera;
        private List<Sprite> spriteList = new();
        private List<Rectangle> rectList = new();

        Player player;

        public PlayScene(ContentManager contentManager)
        {
            this.contentManager = contentManager;
        }

        public void Load()
        {
            Texture2D coinTexture = contentManager.Load<Texture2D>("coin");

            player = new Player(contentManager.Load<Texture2D>("sprite_spaceman0"), Vector2.Zero, new Vector2(64, 64));
            camera = new(Vector2.Zero);

            spriteList.Add(player);
            spriteList.Add(new Sprite(coinTexture, new Vector2(100, 100), new Vector2(64, 64)));
            spriteList.Add(new Sprite(coinTexture, new Vector2(200, 100), new Vector2(64, 64)));
        }

        public void Update(GameTime gameTime, KeyboardState ks)
        {
            player.update(ks, gameTime, rectList);
            camera.Follow(player.rect, new Vector2(1280, 720));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            camera.Draw(spriteBatch, spriteList);
        }
    }
}
