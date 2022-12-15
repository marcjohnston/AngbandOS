// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Enumerations;

namespace AngbandOS.Mutations.RandomMutations
{
    [Serializable]
    internal class MutationWasting : Mutation
    {
        public override void Initialise()
        {
            Frequency = 1;
            GainMessage = "You suddenly contract a horrible wasting disease.";
            HaveMessage = "You have a horrible wasting disease.";
            LoseMessage = "You are cured of the horrible wasting disease!";
        }

        public override void OnProcessWorld(SaveGame saveGame)
        {
            if (Program.Rng.DieRoll(3000) != 13)
            {
                return;
            }
            int whichStat = Program.Rng.RandomLessThan(6);
            bool sustained = false;
            switch (whichStat)
            {
                case Ability.Strength:
                    if (saveGame.Player.HasSustainStrength)
                    {
                        sustained = true;
                    }
                    break;

                case Ability.Intelligence:
                    if (saveGame.Player.HasSustainIntelligence)
                    {
                        sustained = true;
                    }
                    break;

                case Ability.Wisdom:
                    if (saveGame.Player.HasSustainWisdom)
                    {
                        sustained = true;
                    }
                    break;

                case Ability.Dexterity:
                    if (saveGame.Player.HasSustainDexterity)
                    {
                        sustained = true;
                    }
                    break;

                case Ability.Constitution:
                    if (saveGame.Player.HasSustainConstitution)
                    {
                        sustained = true;
                    }
                    break;

                case Ability.Charisma:
                    if (saveGame.Player.HasSustainCharisma)
                    {
                        sustained = true;
                    }
                    break;

                default:
                    saveGame.MsgPrint("Invalid stat chosen!");
                    sustained = true;
                    break;
            }
            if (sustained)
            {
                return;
            }
            saveGame.Disturb(false);
            if (Program.Rng.DieRoll(10) <= saveGame.Player.Religion.GetNamedDeity(Pantheon.GodName.Lobon).AdjustedFavour)
            {
                saveGame.MsgPrint("Lobon's favour protects you from wasting away!");
                saveGame.MsgPrint(null);
                return;
            }
            saveGame.MsgPrint("You can feel yourself wasting away!");
            saveGame.MsgPrint(null);
            saveGame.Player.DecreaseAbilityScore(whichStat, Program.Rng.DieRoll(6) + 6, Program.Rng.DieRoll(3) == 1);
        }
    }
}