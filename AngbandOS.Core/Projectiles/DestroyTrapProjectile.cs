// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projection;

[Serializable]
internal class DestroyTrapProjectile : Projectile
{
    private DestroyTrapProjectile(Game game) : base(game) { }

    protected override Animation EffectAnimation => Game.SingletonRepository.Get<Animation>(nameof(RedSwirlAnimation));

    protected override bool AffectFloor(int y, int x)
    {
        GridTile cPtr = Game.Map.Grid[y][x];
        bool obvious = false;
        if (cPtr.FeatureType.IsUnidentifiedTrap || cPtr.FeatureType.IsTrap)
        {
            if (Game.PlayerHasLosBold(y, x))
            {
                Game.MsgPrint("There is a bright flash of light!");
                obvious = true;
            }
            cPtr.PlayerMemorized = false;
            Game.RevertTileToBackground(y, x);
        }
        else if (cPtr.FeatureType.IsSecretDoor || cPtr.FeatureType.IsClosedDoor)
        {
            Game.CaveSetFeat(y, x, Game.SingletonRepository.Get<Tile>(nameof(LockedDoor0Tile)));
            if (Game.PlayerHasLosBold(y, x))
            {
                Game.MsgPrint("Click!");
                obvious = true;
            }
        }
        return obvious;
    }

    protected override bool AffectItem(int who, int y, int x)
    {
        GridTile cPtr = Game.Map.Grid[y][x];
        bool obvious = false;
        foreach (Item oPtr in cPtr.Items)
        {
            if (oPtr.Factory.IsContainer)
            {
                if (!oPtr.ContainerIsOpen && oPtr.ContainerTraps != null)
                {
                    oPtr.ContainerTraps = null;
                    oPtr.BecomeKnown();
                    if (oPtr.Marked)
                    {
                        Game.MsgPrint("Click!");
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