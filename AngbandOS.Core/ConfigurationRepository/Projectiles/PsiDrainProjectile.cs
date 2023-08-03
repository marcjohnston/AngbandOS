// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projection;

[Serializable]
internal class PsiDrainProjectile : Projectile
{
    private PsiDrainProjectile(SaveGame saveGame) : base(saveGame) { }

    protected override ProjectileGraphic? BoltProjectileGraphic => SaveGame.SingletonRepository.ProjectileGraphics.Get<BeigeBoltProjectileGraphic>();

    protected override Animation EffectAnimation => SaveGame.SingletonRepository.Animations.Get<BeigeContractAnimation>();

    protected override bool ProjectileAngersMonster(Monster mPtr)
    {
        // Only stupid friends are affected.
        MonsterRace rPtr = mPtr.Race;
        return rPtr.EmptyMind;
    }

    protected override bool AffectMonster(int who, Monster mPtr, int dam, int r)
    {
        MonsterRace rPtr = mPtr.Race;
        bool seen = mPtr.IsVisible;
        bool obvious = false;
        string? note = null;
        string mName = mPtr.Name;
        if (seen)
        {
            obvious = true;
        }
        if (rPtr.EmptyMind)
        {
            dam = 0;
            note = " is immune!";
        }
        else if (rPtr.Stupid || rPtr.WeirdMind || rPtr.Animal || rPtr.Level > SaveGame.Rng.DieRoll(3 * dam))
        {
            dam /= 3;
            note = " resists.";
            if ((rPtr.Undead || rPtr.Demon) && rPtr.Level > SaveGame.ExperienceLevel / 2 && SaveGame.Rng.DieRoll(2) == 1)
            {
                note = null;
                string s = seen ? "'s" : "s";
                SaveGame.MsgPrint($"{mName}{s} corrupted mind backlashes your attack!");
                if (SaveGame.Rng.RandomLessThan(100) < SaveGame.SkillSavingThrow)
                {
                    SaveGame.MsgPrint("You resist the effects!");
                }
                else
                {
                    string killer = mPtr.IndefiniteVisibleName;
                    SaveGame.MsgPrint("Your psychic energy is drained!");
                    SaveGame.Mana = Math.Max(0, SaveGame.Mana - (SaveGame.Rng.DiceRoll(5, dam) / 2));
                    SaveGame.RedrawManaFlaggedAction.Set();
                    SaveGame.TakeHit(dam, killer);
                }
                dam = 0;
            }
        }
        else if (dam > 0)
        {
            int b = SaveGame.Rng.DiceRoll(5, dam) / 4;
            string s = seen ? "'s" : "s";
            SaveGame.MsgPrint($"You convert {mName}{s} pain into psychic energy!");
            b = Math.Min(SaveGame.MaxMana, SaveGame.Mana + b);
            SaveGame.Mana = b;
            SaveGame.RedrawManaFlaggedAction.Set();
        }
        string noteDies = " collapses, a mindless husk.";
        ApplyProjectileDamageToMonster(who, mPtr, dam, note, noteDies);
        return obvious;
    }
}