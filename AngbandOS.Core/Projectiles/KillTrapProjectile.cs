// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projection;

[Serializable]
internal class KillTrapProjectile : Projectile
{
    private KillTrapProjectile(SaveGame saveGame) : base(saveGame) { }

    protected override Animation EffectAnimation => SaveGame.SingletonRepository.Animations.Get(nameof(RedSwirlAnimation));

    protected override bool AffectFloor(int y, int x)
    {
        GridTile cPtr = SaveGame.Grid[y][x];
        bool obvious = false;
        if (cPtr.FeatureType.IsUnidentifiedTrap || cPtr.FeatureType.IsTrap)
        {
            if (SaveGame.PlayerHasLosBold(y, x))
            {
                SaveGame.MsgPrint("There is a bright flash of light!");
                obvious = true;
            }
            cPtr.TileFlags.Clear(GridTile.PlayerMemorized);
            SaveGame.RevertTileToBackground(y, x);
        }
        else if (cPtr.FeatureType.IsSecretDoor || cPtr.FeatureType.IsClosedDoor)
        {
            SaveGame.CaveSetFeat(y, x, SaveGame.SingletonRepository.Tiles.Get(nameof(LockedDoor0Tile)));
            if (SaveGame.PlayerHasLosBold(y, x))
            {
                SaveGame.MsgPrint("Click!");
                obvious = true;
            }
        }
        return obvious;
    }

    protected override bool AffectItem(int who, int y, int x)
    {
        GridTile cPtr = SaveGame.Grid[y][x];
        bool obvious = false;
        foreach (Item oPtr in cPtr.Items)
        {
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