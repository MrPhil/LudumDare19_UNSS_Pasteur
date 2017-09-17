using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace LD19
{
    public class EarthTile : SpaceTile
    {
        public SpaceTile tester;

        public EarthTile(Vector2 worldLocation)
        {
            TextureLink textureLink = TextureManager.Textures[TextureNames.Earth1];

            BaseSprite = new Sprite(worldLocation,
                textureLink.SpriteSheet,
                textureLink.SourceRectangle,
                Vector2.Zero);

            BaseSprite.AnimateWhenStopped = true;
            BaseSprite.CollisionRadius = EncounterRange;

            Encounter = false;
            LongRangeScanned = true;

            tester = new HelpfulScanners(worldLocation);
        }

        public override string GetEncounterText()
        {
            return tester.GetEncounterText();
        }

        public override void EncounterResult(bool action1Selected)
        {
            tester.EncounterResult(action1Selected);
        }
        public override string GetAction1Text()
        {
            return tester.GetAction1Text();
        }
        public override string GetAction2Text()
        {
            return tester.GetAction2Text();
        }
        public override bool IsAction2()
        {
            return tester.IsAction2();
        }
    }
}
