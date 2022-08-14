// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using Cthangband.Projection;
using System;

namespace Cthangband.Mutations.RandomMutations
{
    [Serializable]
    internal class MutationProdMana : Mutation
    {
        public override void Initialise()
        {
            Frequency = 1;
            GainMessage = "You start producing magical energy uncontrollably.";
            HaveMessage = "You are producing magical energy uncontrollably.";
            LoseMessage = "You stop producing magical energy uncontrollably.";
        }

        public override void OnProcessWorld(SaveGame saveGame)
        {
            if (saveGame.Player.HasAntiMagic || Program.Rng.DieRoll(9000) != 1)
            {
                return;
            }
            TargetEngine targetEngine = new TargetEngine(saveGame);
            saveGame.Disturb(false);
            saveGame.MsgPrint("Magical energy flows through you! You must release it!");
            saveGame.MsgPrint(null);
            targetEngine.GetDirectionNoAutoAim(out int dire);
            saveGame.FireBall(new ProjectMana(saveGame), dire, saveGame.Player.Level * 2, 3);
        }
    }
}