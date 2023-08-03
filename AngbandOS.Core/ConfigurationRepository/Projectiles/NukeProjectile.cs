// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projection;

[Serializable]
internal class NukeProjectile : Projectile
{
    private NukeProjectile(SaveGame saveGame) : base(saveGame) { }

    protected override ProjectileGraphic? BoltProjectileGraphic => SaveGame.SingletonRepository.ProjectileGraphics.Get<BrightChartreuseSplatProjectileGraphic>();

    protected override Animation EffectAnimation => SaveGame.SingletonRepository.Animations.Get<ChartreuseFlashAnimation>();

    protected override bool AffectMonster(int who, Monster mPtr, int dam, int r)
    {
        GridTile cPtr = SaveGame.Grid[mPtr.MapY][mPtr.MapX];
        MonsterRace rPtr = mPtr.Race;
        bool seen = mPtr.IsVisible;
        bool obvious = false;
        bool doPoly = false;
        string? note = null;
        if (seen)
        {
            obvious = true;
        }
        if (rPtr.ImmunePoison)
        {
            note = " resists.";
            dam *= 3;
            dam /= SaveGame.Rng.DieRoll(6) + 6;
            if (seen)
            {
                rPtr.Knowledge.Characteristics.ImmunePoison = true;
            }
        }
        else if (SaveGame.Rng.DieRoll(3) == 1)
        {
            doPoly = true;
        }
        if (rPtr.Unique)
        {
            doPoly = false;
        }
        if (rPtr.Guardian)
        {
            doPoly = false;
        }
        if (doPoly && SaveGame.Rng.DieRoll(90) > rPtr.Level)
        {
            note = " is unaffected!";
            bool charm = mPtr.SmFriendly;
            int tmp = SaveGame.PolymorphMonster(mPtr.Race);
            if (tmp != mPtr.Race.Index)
            {
                note = " changes!";
                dam = 0;
                SaveGame.DeleteMonsterByIndex(cPtr.MonsterIndex, true);
                MonsterRace race = SaveGame.SingletonRepository.MonsterRaces[tmp];
                SaveGame.PlaceMonsterAux(mPtr.MapY, mPtr.MapX, race, false, false, charm);
                mPtr = SaveGame.Monsters[cPtr.MonsterIndex];
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
            SaveGame.MsgPrint("You are hit by radiation!");
        }
        if (SaveGame.HasPoisonResistance)
        {
            dam = ((2 * dam) + 2) / 5;
        }
        if (SaveGame.TimedPoisonResistance.TurnsRemaining != 0)
        {
            dam = ((2 * dam) + 2) / 5;
        }
        SaveGame.TakeHit(dam, killer);
        if (!(SaveGame.HasPoisonResistance || SaveGame.TimedPoisonResistance.TurnsRemaining != 0))
        {
            SaveGame.TimedPoison.AddTimer(SaveGame.Rng.RandomLessThan(dam) + 10);
            if (SaveGame.Rng.DieRoll(5) == 1)
            {
                SaveGame.MsgPrint("You undergo a freakish metamorphosis!");
                if (SaveGame.Rng.DieRoll(4) == 1)
                {
                    SaveGame.PolymorphSelf(SaveGame);
                }
                else
                {
                    SaveGame.ShuffleAbilityScores();
                }
            }
            if (SaveGame.Rng.DieRoll(6) == 1)
            {
                SaveGame.InvenDamage(SaveGame.SetAcidDestroy, 2);
            }
        }
        return true;
    }
}