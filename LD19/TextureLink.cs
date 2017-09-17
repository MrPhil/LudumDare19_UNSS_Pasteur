using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LD19
{
    public class TextureLink
    {
        public TextureLink(Texture2D spriteSheet, Rectangle sourceRectangle)
        {
            SpriteSheet = spriteSheet;
            SourceRectangle = sourceRectangle;
        }

        public TextureLink(Texture2D spriteSheet, int x, int y, int width, int height)
        {
            SpriteSheet = spriteSheet;
            SourceRectangle = new Rectangle(x, y, width, height);
        }

        public Texture2D SpriteSheet
        {
            get;
            set;
        }
        public Rectangle SourceRectangle
        {
            get;
            set;
        }
    }
}
