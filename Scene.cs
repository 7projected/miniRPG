using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace miniRPG;

public interface IScene
{
    public void Load();
    public void Update(GameTime gameTime, KeyboardState ks);
    public void Draw(SpriteBatch spriteBatch);
}