// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projection
{
    internal class KillTrapProjectile : Projectile
    {
        public KillTrapProjectile(SaveGame saveGame) : base(saveGame)
        {
        }

        protected override string BoltGraphic => "";

        protected override string EffectAnimation => "RedSwirl";

        protected override bool AffectFloor(int y, int x)
        {
            GridTile cPtr = SaveGame.Level.Grid[y][x];
            bool obvious = false;
            if (cPtr.FeatureType.Category == FloorTileTypeCategory.UnidentifiedTrap || cPtr.FeatureType.IsTrap)
            {
                if (SaveGame.Level.PlayerHasLosBold(y, x))
                {
                    SaveGame.MsgPrint("There is a bright flash of light!");
                    obvious = true;
                }
                cPtr.TileFlags.Clear(GridTile.PlayerMemorised);
                SaveGame.Level.RevertTileToBackground(y, x);
            }
            else if (cPtr.FeatureType.Category == FloorTileTypeCategory.SecretDoor ||
                     cPtr.FeatureType.Category == FloorTileTypeCategory.LockedDoor)
            {
                SaveGame.Level.CaveSetFeat(y, x, "LockedDoor0");
                if (SaveGame.Level.PlayerHasLosBold(y, x))
                {
                    SaveGame.MsgPrint("Click!");
                    obvious = true;
                }
            }
            return obvious;
        }

        protected override bool AffectItem(int who, int y, int x)
        {
            GridTile cPtr = SaveGame.Level.Grid[y][x];
            int nextOIdx;
            bool obvious = false;
            for (int thisOIdx = cPtr.ItemIndex; thisOIdx != 0; thisOIdx = nextOIdx)
            {
                Item? oPtr = SaveGame.GetLevelItem(thisOIdx);
                nextOIdx = (oPtr == null ? 0 : oPtr.NextInStack);
                if (oPtr != null)
                {
                    if (oPtr.Count > 1)
                    {
                    }
                    if (oPtr.IsFixedArtifact() || string.IsNullOrEmpty(oPtr.RandartName) == false)
                    {
                    }
                    if (oPtr.Category == ItemTypeEnum.Chest)
                    {
                        if (oPtr.TypeSpecificValue > 0)
                        {
                            oPtr.TypeSpecificValue = 0 - oPtr.TypeSpecificValue;
                            oPtr.BecomeKnown();
                            if (oPtr.Marked)
                            {
                                SaveGame.MsgPrint("Click!");
                                obvious = true;
                            }
                        }
                    }
                }
            }
            return obvious;
        }

        protected override bool ProjectileAngersMonster(Monster mPtr)
        {
            return false;
        }

        protected override bool AffectMonster(int who, Monster mPtr, int dam, int r)
        {
            string? note = null;
            ApplyProjectileDamageToMonster(who, mPtr, dam, note);
            return false;
        }
    }
}