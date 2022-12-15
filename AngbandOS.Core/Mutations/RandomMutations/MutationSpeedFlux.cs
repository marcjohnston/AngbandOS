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
    internal class MutationSpeedFlux : Mutation
    {
        public override void Initialise()
        {
            Frequency = 2;
            GainMessage = "You have become unstuck in time.";
            HaveMessage = "You move faster or slower randomly.";
            LoseMessage = "You are firmly anchored in time.";
        }

        public override void OnProcessWorld(SaveGame saveGame)
        {
            if (Program.Rng.DieRoll(6000) == 1)
            {
                saveGame.Disturb(false);
                if (Program.Rng.DieRoll(2) == 1)
                {
                    saveGame.MsgPrint("Everything around you speeds up.");
                    if (saveGame.Player.TimedHaste > 0)
                    {
                        saveGame.Player.SetTimedHaste(0);
                    }
                    else
                    {
                        saveGame.Player.SetTimedSlow(saveGame.Player.TimedSlow + Program.Rng.DieRoll(30) + 10);
                    }
                }
                else
                {
                    saveGame.MsgPrint("Everything around you slows down.");
                    if (saveGame.Player.TimedSlow > 0)
                    {
                        saveGame.Player.SetTimedSlow(0);
                    }
                    else
                    {
                        saveGame.Player.SetTimedHaste(saveGame.Player.TimedHaste + Program.Rng.DieRoll(30) + 10);
                    }
                }
                saveGame.MsgPrint(null);
            }
        }
    }
}