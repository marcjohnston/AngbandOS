// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projection;

[Serializable]
internal class DispUndeadProjectile : Projectile
{
    private DispUndeadProjectile(Game game) : base(game) { }

    protected override ProjectileGraphic? BoltProjectileGraphic => Game.SingletonRepository.Get<ProjectileGraphic>(nameof(BlackSplatProjectileGraphic));

    protected override Animation EffectAnimation => Game.SingletonRepository.Get<Animation>(nameof(BlackExpandAnimation));

    protected override bool ProjectileAngersMonster(Monster mPtr)
    {
        // Only undead friends are affected.
        MonsterRace rPtr = mPtr.Race;
        return rPtr.Undead;
    }

    protected override bool AffectMonster(int who, Monster mPtr, int dam, int r)
    {
        MonsterRace rPtr = mPtr.Race;
        bool seen = mPtr.IsVisible;
        bool obvious = false;
        bool skipped = false;
        string? note = null;
        string? noteDies = null;
        if (rPtr.Undead)
        {
            if (seen)
            {
                rPtr.Knowledge.Characteristics.Undead = true;
            }
            if (seen)
            {
                obvious = true;
            }
            note = " shudders.";
            noteDies = " dissolves!";
        }
        else
        {
            skipped = true;
            dam = 0;
        }
        if (skipped)
        {
            return false;
        }
        ApplyProjectileDamageToMonster(who, mPtr, dam, note, noteDies);
        return obvious;
    }
}