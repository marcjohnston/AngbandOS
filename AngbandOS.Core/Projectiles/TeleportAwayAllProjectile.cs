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
    private TeleportAwayAllProjectile(SaveGame saveGame) : base(saveGame) { }

    protected override ProjectileGraphic? BoltProjectileGraphic => SaveGame.SingletonRepository.ProjectileGraphics.Get<PinkBulletProjectileGraphic>();

    protected override ProjectileGraphic? ImpactProjectileGraphic => SaveGame.SingletonRepository.ProjectileGraphics.Get<PinkBulletProjectileGraphic>();

    protected override Animation EffectAnimation => SaveGame.SingletonRepository.Animations.Get<PinkSwirlAnimation>();

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
            else if (rPtr.Level > Program.Rng.DieRoll(100))
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
            mPtr.TeleportAway(SaveGame, doDist);
        }
        ApplyProjectileDamageToMonster(who, mPtr, 0, note);
        return obvious;
    }
}