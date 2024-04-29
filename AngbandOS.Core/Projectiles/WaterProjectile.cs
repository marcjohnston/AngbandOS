// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projection;

[Serializable]
internal class WaterProjectile : Projectile
{
    private WaterProjectile(Game game) : base(game) { }

    protected override ProjectileGraphic? BoltProjectileGraphic => Game.SingletonRepository.Get<ProjectileGraphic>(nameof(BlueSplatProjectileGraphic));

    protected override ProjectileGraphic? ImpactProjectileGraphic => Game.SingletonRepository.Get<ProjectileGraphic>(nameof(BlueSplatProjectileGraphic));

    protected override bool AffectMonster(int who, Monster mPtr, int dam, int r)
    {
        bool obvious = false;
        string? note = null;
        MonsterRace rPtr = mPtr.Race;
        string name = rPtr.FriendlyName;
        bool seen = mPtr.IsVisible;
        if (seen)
        {
            obvious = true;
        }
        if (rPtr.Symbol.Character == 'E' && (name.StartsWith("W") || rPtr.FriendlyName.Contains("Unmaker")))
        {
            note = " is immune.";
            dam = 0;
        }
        else if (rPtr.ResistWater)
        {
            note = " resists.";
            dam *= 3;
            dam /= Game.DieRoll(6) + 6;
            if (seen)
            {
                rPtr.Knowledge.Characteristics.ResistWater = true;
            }
        }
        ApplyProjectileDamageToMonster(who, mPtr, dam, note);
        return obvious;
    }

    protected override bool AffectPlayer(int who, int r, int y, int x, int dam, int aRad)
    {
        bool blind = Game.BlindnessTimer.Value != 0;
        if (dam > 1600)
        {
            dam = 1600;
        }
        dam = (dam + r) / (r + 1);
        Monster mPtr = Game.Monsters[who];
        string killer = mPtr.IndefiniteVisibleName;
        if (blind)
        {
            Game.MsgPrint("You are hit by something wet!");
        }
        if (!Game.HasSoundResistance)
        {
            Game.StunTimer.AddTimer(Game.DieRoll(40));
        }
        if (!Game.HasConfusionResistance)
        {
            Game.ConfusedTimer.AddTimer(Game.DieRoll(5) + 5);
        }
        if (Game.DieRoll(5) == 1)
        {
            Game.InvenDamage(Game.SetColdDestroy, 3);
        }
        Game.TakeHit(dam, killer);
        return true;
    }
}