// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.ActiveMutations
{
    [Serializable]
    internal class MutationDetCurse : Mutation
    {
        public override void Activate(SaveGame saveGame)
        {
            if (!saveGame.CheckIfRacialPowerWorks(7, 14, Ability.Wisdom, 14))
            {
                return;
            }
            for (int i = 0; i < InventorySlot.Total; i++)
            {
                Item? oPtr = saveGame.GetInventoryItem(i);
                if (oPtr != null && oPtr.IsCursed())
                {
                    oPtr.Inscription = "cursed";
                }
            }
        }

        public override string ActivationSummary(int lvl)
        {
            return lvl < 7 ? "detect curses    (unusable until level 7)" : "detect curses    (cost 14, WIS based)";
        }

        public override void Initialize()
        {
            Frequency = 2;
            GainMessage = "You can feel evil magics.";
            HaveMessage = "You can feel the danger of evil magic.";
            LoseMessage = "You can no longer feel evil magics.";
        }
    }
}