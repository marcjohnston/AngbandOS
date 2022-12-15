// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Enumerations;
using AngbandOS.Projection;

namespace AngbandOS.Mutations.ActiveMutations
{
    [Serializable]
    internal class MutationColdTouch : Mutation
    {
        public override void Activate(SaveGame saveGame, Player player, Level level)
        {
            if (!saveGame.CheckIfRacialPowerWorks(2, 2, Ability.Constitution, 11))
            {
                return;
            }
            if (!saveGame.GetDirectionNoAim(out int dir))
            {
                return;
            }
            int y = player.MapY + level.KeypadDirectionYOffset[dir];
            int x = player.MapX + level.KeypadDirectionXOffset[dir];
            GridTile cPtr = level.Grid[y][x];
            if (cPtr.MonsterIndex == 0)
            {
                saveGame.MsgPrint("You wave your hands in the air.");
                return;
            }
            saveGame.FireBolt(new ProjectCold(saveGame), dir, 2 * player.Level);
        }

        public override string ActivationSummary(int lvl)
        {
            return lvl < 2 ? "cold touch       (unusable until level 2)" : "cold touch       (cost 2, CON based)";
        }

        public override void Initialise()
        {
            Frequency = 2;
            GainMessage = "Your hands get very cold.";
            HaveMessage = "You can freeze things with a touch.";
            LoseMessage = "Your hands warm up.";
        }
    }
}