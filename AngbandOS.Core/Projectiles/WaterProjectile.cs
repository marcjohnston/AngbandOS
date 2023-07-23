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
    private WaterProjectile(SaveGame saveGame) : base(saveGame) { }

    protected override ProjectileGraphic? BoltProjectileGraphic => SaveGame.SingletonRepository.ProjectileGraphics.Get<BlueSplatProjectileGraphic>();

    protected override ProjectileGraphic? ImpactProjectileGraphic => SaveGame.SingletonRepository.ProjectileGraphics.Get<BlueSplatProjectileGraphic>();

    protected override bool AffectMonster(int who, Monster mPtr, int dam, int r)
    {
        bool obvious = false;
        string? note = null;
        MonsterRace rPtr = mPtr.Race;
        string name = rPtr.Name;
        bool seen = mPtr.IsVisible;
        if (seen)
        {
            obvious = true;
        }
        if (rPtr.Symbol.Character == 'E' && (name.StartsWith("W") || rPtr.Name.Contains("Unmaker")))
        {
            note = " is immune.";
            dam = 0;
        }
        else if (rPtr.ResistWater)
        {
            note = " resists.";
            dam *= 3;
            dam /= Program.Rng.DieRoll(6) + 6;
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
        bool blind = SaveGame.TimedBlindness.TurnsRemaining != 0;
        if (dam > 1600)
        {
            dam = 1600;
        }
        dam = (dam + r) / (r + 1);
        Monster mPtr = SaveGame.Monsters[who];
        string killer = mPtr.IndefiniteVisibleName;
        if (blind)
        {
            SaveGame.MsgPrint("You are hit by something wet!");
        }
        if (!SaveGame.HasSoundResistance)
        {
            SaveGame.TimedStun.AddTimer(Program.Rng.DieRoll(40));
        }
        if (!SaveGame.HasConfusionResistance)
        {
            SaveGame.TimedConfusion.AddTimer(Program.Rng.DieRoll(5) + 5);
        }
        if (Program.Rng.DieRoll(5) == 1)
        {
            SaveGame.InvenDamage(SaveGame.SetColdDestroy, 3);
        }
        SaveGame.TakeHit(dam, killer);
        return true;
    }
}