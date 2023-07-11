// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projection;

[Serializable]
internal class KillDoorProjectile : Projectile
{
    private KillDoorProjectile(SaveGame saveGame) : base(saveGame) { }

    protected override Animation EffectAnimation => SaveGame.SingletonRepository.Animations.Get<BrightYellowSwirlAnimation>();

    protected override bool AffectFloor(int y, int x)
    {
        GridTile cPtr = SaveGame.Level.Grid[y][x];
        bool obvious = false;
        if (cPtr.FeatureType.IsClosedDoor || cPtr.FeatureType.IsOpenDoor || cPtr.FeatureType.Category.CategoryEnum == FloorTileTypeCategory.UnidentifiedTrap || cPtr.FeatureType.IsTrap)
        {
            if (SaveGame.Level.PlayerHasLosBold(y, x))
            {
                SaveGame.MsgPrint("There is a bright flash of light!");
                obvious = true;
                if (cPtr.FeatureType.IsClosedDoor)
                {
                    SaveGame.UpdateMonstersFlaggedAction.Set();
                    SaveGame.UpdateLightFlaggedAction.Set();
                    SaveGame.UpdateViewFlaggedAction.Set();
                }
            }
            cPtr.TileFlags.Clear(GridTile.PlayerMemorized);
            SaveGame.Level.RevertTileToBackground(y, x);
        }
        return obvious;
    }

    protected override bool AffectItem(int who, int y, int x)
    {
        GridTile cPtr = SaveGame.Level.Grid[y][x];
        int nextOIdx;
        bool obvious = false;
        foreach (Item oPtr in cPtr.Items)
        {
            if (oPtr.Count > 1)
            {
            }
            if (oPtr.FixedArtifact != null || string.IsNullOrEmpty(oPtr.RandartName) == false)
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