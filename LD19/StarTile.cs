using Microsoft.Xna.Framework;

namespace LD19
{
    public class StarTile : SpaceTile
    {    
        public StarTile(Vector2 worldLocation)
            : base(worldLocation)
        {
            Encounter = true;
            IsStar = true;
        }

        public override void LongRangeScan()
        {
            if (LongRangeScanned == false)
            {
                SoundManager.CivAlert.Play();

                LongRangeScanned = true;

                TextureNames textureName = (TextureNames)Random.Next((int)TextureNames.Star1, (int)TextureNames.Star7);
                TextureLink textureLink = TextureManager.Textures[textureName];

                BaseSprite = new Sprite(BaseSprite.WorldLocation,
                    textureLink.SpriteSheet,
                    textureLink.SourceRectangle,
                    Vector2.Zero);

                Color tint = new Color( Random.Next(1, 254), Random.Next(1,254), Random.Next(1,254));
                BaseSprite.TintColor = tint;

                BaseSprite.AnimateWhenStopped = true;
                BaseSprite.CollisionRadius = 1;
            }
        }
    }
}
