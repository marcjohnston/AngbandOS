// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projectiles;

[Serializable]
internal class DispEvilProjectile : Projectile
{
    private DispEvilProjectile(Game game) : base(game) { }

    protected override ProjectileGraphic? BoltProjectileGraphic => Game.SingletonRepository.Get<ProjectileGraphic>(nameof(RedSplatProjectileGraphic));

    protected override Animation EffectAnimation => Game.SingletonRepository.Get<Animation>(nameof(RedExpandAnimation));

    protected override bool ProjectileAngersMonster(Monster mPtr)
    {
        // Only evil friends are affected.
        MonsterRace rPtr = mPtr.Race;
        return rPtr.Evil;
    }

    protected override bool AffectMonster(int who, Monster mPtr, int dam, int r)
    {
        MonsterRace rPtr = mPtr.Race;
        bool seen = mPtr.IsVisible;
        string? note = null;
        string? noteDies = " dissolves!";
        bool obvious = false;
        if (rPtr.Evil)
        {
            if (seen)
            {
                rPtr.Knowledge.Characteristics.Evil = true;
            }
            if (seen)
            {
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