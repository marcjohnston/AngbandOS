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
    private KillDoorProjectile(Game game) : base(game) { }

    protected override Animation EffectAnimation => Game.SingletonRepository.Get<Animation>(nameof(BrightYellowSwirlAnimation));

    protected override bool AffectFloor(int y, int x)
    {
        GridTile cPtr = Game.Map.Grid[y][x];
        bool obvious = false;
        if (cPtr.FeatureType.IsVisibleDoor || cPtr.FeatureType.IsOpenDoor || cPtr.FeatureType.IsUnidentifiedTrap || cPtr.FeatureType.IsTrap)
        {
            if (Game.PlayerHasLosBold(y, x))
            {
                Game.MsgPrint("There is a bright flash of light!");
                obvious = true;
                if (cPtr.FeatureType.IsVisibleDoor)
                {
                    Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateMonstersFlaggedAction)).Set();
                    Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateLightFlaggedAction)).Set();
                    Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateViewFlaggedAction)).Set();
                }
            }
            cPtr.PlayerMemorized = false;
            Game.RevertTileToBackground(y, x);
        }
        return obvious;
    }

    protected override bool AffectItem(int who, int y, int x)
    {
        GridTile cPtr = Game.Map.Grid[y][x];
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