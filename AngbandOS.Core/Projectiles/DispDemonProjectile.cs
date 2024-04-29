// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projection;

[Serializable]
internal class DispDemonProjectile : Projectile
{
    private DispDemonProjectile(Game game) : base(game) { }

    protected override ProjectileGraphic? BoltProjectileGraphic => Game.SingletonRepository.Get<ProjectileGraphic>(nameof(BrightRedSplatProjectileGraphic));

    protected override Animation EffectAnimation => Game.SingletonRepository.Get<Animation>(nameof(BrightRedExpandAnimation));

    protected override bool ProjectileAngersMonster(Monster mPtr)
    {
        // Only demon friends are affected.
        MonsterRace rPtr = mPtr.Race;
        return rPtr.Demon;
    }

    protected override bool AffectMonster(int who, Monster mPtr, int dam, int r)
    {
        MonsterRace rPtr = mPtr.Race;
        bool seen = mPtr.IsVisible;
        bool obvious = false;
        string noteDies = " dissolves!";
        string? note = null;
        if (rPtr.Demon)
        {
            if (seen)
            {
                rPtr.Knowledge.Characteristics.Demon = true;
                obvious = true;
            }
            note = " shudders.";
        }
        else
        {
            return false;
        }
        ApplyProjectileDamageToMonster(who, mPtr, dam, note, noteDies);
        return obvious;
    }
}