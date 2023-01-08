// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Mutations.RandomMutations
{
    [Serializable]
    internal class MutationWeirdMind : Mutation
    {
        public override void Initialise()
        {
            Frequency = 2;
            GainMessage = "Your thoughts suddenly take off in strange directions.";
            HaveMessage = "Your mind randomly expands and contracts.";
            LoseMessage = "Your thoughts return to boring paths.";
        }

        public override void OnProcessWorld(SaveGame saveGame)
        {
            if (saveGame.Player.HasAntiMagic || Program.Rng.DieRoll(3000) != 1)
            {
                return;
            }
            if (saveGame.Player.TimedTelepathy.TimeRemaining > 0)
            {
                saveGame.MsgPrint("Your mind feels cloudy!");
                saveGame.Player.TimedTelepathy.SetTimer(0);
            }
            else
            {
                saveGame.MsgPrint("Your mind expands!");
                saveGame.Player.TimedTelepathy.SetTimer(saveGame.Player.Level);
            }
        }
    }
}