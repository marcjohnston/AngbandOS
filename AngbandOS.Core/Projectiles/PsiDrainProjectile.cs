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
    private PsiDrainProjectile(Game game) : base(game) { }

    protected override ProjectileGraphic? BoltProjectileGraphic => Game.SingletonRepository.ProjectileGraphics.Get(nameof(BeigeBoltProjectileGraphic));

    protected override Animation EffectAnimation => Game.SingletonRepository.Get<Animation>(nameof(BeigeContractAnimation));

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
        else if (rPtr.Stupid || rPtr.WeirdMind || rPtr.Animal || rPtr.Level > Game.DieRoll(3 * dam))
        {
            dam /= 3;
            note = " resists.";
            if ((rPtr.Undead || rPtr.Demon) && rPtr.Level > Game.ExperienceLevel.IntValue / 2 && Game.DieRoll(2) == 1)
            {
                note = null;
                string s = seen ? "'s" : "s";
                Game.MsgPrint($"{mName}{s} corrupted mind backlashes your attack!");
                if (Game.RandomLessThan(100) < Game.SkillSavingThrow)
                {
                    Game.MsgPrint("You resist the effects!");
                }
                else
                {
                    string killer = mPtr.IndefiniteVisibleName;
                    Game.MsgPrint("Your psychic energy is drained!");
                    Game.Mana.IntValue = Math.Max(0, Game.Mana.IntValue - (Game.DiceRoll(5, dam) / 2));
                    Game.TakeHit(dam, killer);
                }
                dam = 0;
            }
        }
        else if (dam > 0)
        {
            int b = Game.DiceRoll(5, dam) / 4;
            string s = seen ? "'s" : "s";
            Game.MsgPrint($"You convert {mName}{s} pain into psychic energy!");
            b = Math.Min(Game.MaxMana.IntValue, Game.Mana.IntValue + b);
            Game.Mana.IntValue = b;
        }
        string noteDies = " collapses, a mindless husk.";
        ApplyProjectileDamageToMonster(who, mPtr, dam, note, noteDies);
        return obvious;
    }
}