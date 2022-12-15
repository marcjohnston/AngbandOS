// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core.MonsterSelectors;

namespace AngbandOS.Mutations.RandomMutations
{
    [Serializable]
    internal class MutationAttAnimal : Mutation
    {
        public override void Initialise()
        {
            Frequency = 1;
            GainMessage = "You start attracting animals.";
            HaveMessage = "You attract animals.";
            LoseMessage = "You stop attracting animals.";
        }

        public override void OnProcessWorld(SaveGame saveGame)
        {
            if (saveGame.Player.HasAntiMagic || Program.Rng.DieRoll(7000) != 1)
            {
                return;
            }
            bool aSummon;
            if (Program.Rng.DieRoll(3) == 1)
            {
                aSummon = saveGame.Level.Monsters.SummonSpecificFriendly(saveGame.Player.MapY, saveGame.Player.MapX, saveGame.Difficulty, new AnimalMonsterSelector(), true);
            }
            else
            {
                aSummon = saveGame.Level.Monsters.SummonSpecific(saveGame.Player.MapY, saveGame.Player.MapX, saveGame.Difficulty, new AnimalMonsterSelector());
            }
            if (!aSummon)
            {
                return;
            }
            saveGame.MsgPrint("You have attracted an animal!");
            saveGame.Disturb(false);
        }
    }
}