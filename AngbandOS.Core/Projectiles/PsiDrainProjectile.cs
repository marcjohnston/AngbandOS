// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projection
{
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
            else if (rPtr.Stupid || rPtr.WeirdMind || rPtr.Animal || rPtr.Level > Program.Rng.DieRoll(3 * dam))
            {
                dam /= 3;
                note = " resists.";
                if ((rPtr.Undead || rPtr.Demon) && rPtr.Level > SaveGame.Player.Level / 2 && Program.Rng.DieRoll(2) == 1)
                {
                    note = null;
                    string s = seen ? "'s" : "s";
                    SaveGame.MsgPrint($"{mName}{s} corrupted mind backlashes your attack!");
                    if (Program.Rng.RandomLessThan(100) < SaveGame.Player.SkillSavingThrow)
                    {
                        SaveGame.MsgPrint("You resist the effects!");
                    }
                    else
                    {
                        string killer = mPtr.IndefiniteVisibleName;
                        SaveGame.MsgPrint("Your psychic energy is drained!");
                        SaveGame.Player.Mana = Math.Max(0, SaveGame.Player.Mana - (Program.Rng.DiceRoll(5, dam) / 2));
                        SaveGame.RedrawManaFlaggedAction.Set();
                        SaveGame.Player.TakeHit(dam, killer);
                    }
                    dam = 0;
                }
            }
            else if (dam > 0)
            {
                int b = Program.Rng.DiceRoll(5, dam) / 4;
                string s = seen ? "'s" : "s";
                SaveGame.MsgPrint($"You convert {mName}{s} pain into psychic energy!");
                b = Math.Min(SaveGame.Player.MaxMana, SaveGame.Player.Mana + b);
                SaveGame.Player.Mana = b;
                SaveGame.RedrawManaFlaggedAction.Set();
            }
            string noteDies = " collapses, a mindless husk.";
            ApplyProjectileDamageToMonster(who, mPtr, dam, note, noteDies);
            return obvious;
        }
    }
}