// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projection;

[Serializable]
internal class JamDoorProjectile : Projectile
{
    private JamDoorProjectile(Game game) : base(game) { }

    protected override Animation EffectAnimation => Game.SingletonRepository.Animations.Get(nameof(YellowSwirlAnimation));

    protected override bool AffectFloor(int y, int x)
    {
        GridTile cPtr = Game.Grid[y][x];
        bool obvious = false;
        if (cPtr.FeatureType.IsVisibleDoor)
        {
            Tile? jammedTile = cPtr.FeatureType.OnJammedTile;
            if (jammedTile == null)
            {
                throw new Exception("No jammed door specified.");
            }
            cPtr.SetFeature(jammedTile);
            if (Game.PlayerHasLosBold(y, x))
            {
                Game.MsgPrint("The door seems stuck.");
                obvious = true;
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