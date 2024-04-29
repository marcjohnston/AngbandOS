// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projection;

[Serializable]
internal class TeleportAwayAllProjectile : Projectile
{
    private TeleportAwayAllProjectile(Game game) : base(game) { }

    protected override ProjectileGraphic? BoltProjectileGraphic => Game.SingletonRepository.Get<ProjectileGraphic>(nameof(PinkBulletProjectileGraphic));

    protected override ProjectileGraphic? ImpactProjectileGraphic => Game.SingletonRepository.Get<ProjectileGraphic>(nameof(PinkBulletProjectileGraphic));

    protected override Animation EffectAnimation => Game.SingletonRepository.Get<Animation>(nameof(PinkSwirlAnimation));

    protected override bool ProjectileAngersMonster(Monster mPtr)
    {
        return false;
    }

    protected override bool AffectMonster(int who, Monster mPtr, int dam, int r)
    {
        MonsterRace rPtr = mPtr.Race;
        bool seen = mPtr.IsVisible;
        bool obvious = false;
        int doDist = 0;
        string? note = null;
        bool resistsTele = false;
        if (rPtr.ResistTeleport)
        {
            if (rPtr.Unique)
            {
                if (seen)
                {
                    rPtr.Knowledge.Characteristics.ResistTeleport = true;
                }
                note = " is unaffected!";
                resistsTele = true;
            }
            else if (rPtr.Level > Game.DieRoll(100))
            {
                if (seen)
                {
                    rPtr.Knowledge.Characteristics.ResistTeleport = true;
                }
                note = " resists!";
                resistsTele = true;
            }
        }
        if (!resistsTele)
        {
            if (seen)
            {
                obvious = true;
            }
            doDist = dam;
        }
        if (doDist != 0)
        {
            if (seen)
            {
                obvious = true;
            }
            note = " disappears!";
            mPtr.TeleportAway(doDist);
        }
        ApplyProjectileDamageToMonster(who, mPtr, 0, note);
        return obvious;
    }
}