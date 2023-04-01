// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.RandomMutations
{
    [Serializable]
    internal class MutationAttDemon : Mutation
    {
        public override void Initialize()
        {
            Frequency = 2;
            GainMessage = "You start attracting demons.";
            HaveMessage = "You attract demons.";
            LoseMessage = "You stop attracting demons.";
        }

        public override void OnProcessWorld(SaveGame saveGame)
        {
            if (saveGame.Player.HasAntiMagic || Program.Rng.DieRoll(6666) != 666)
            {
                return;
            }
            bool dSummon;
            if (Program.Rng.DieRoll(6) == 1)
            {
                dSummon = saveGame.Level.SummonSpecificFriendly(saveGame.Player.MapY, saveGame.Player.MapX, saveGame.Difficulty, new DemonMonsterSelector(), true);
            }
            else
            {
                dSummon = saveGame.Level.SummonSpecific(saveGame.Player.MapY, saveGame.Player.MapX, saveGame.Difficulty, new DemonMonsterSelector());
            }
            if (!dSummon)
            {
                return;
            }
            saveGame.MsgPrint("You have attracted a demon!");
            saveGame.Disturb(false);
        }
    }
}