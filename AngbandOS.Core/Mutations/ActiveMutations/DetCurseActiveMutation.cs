// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.ActiveMutations;

[Serializable]
internal class DetCurseActiveMutation : Mutation
{
    private DetCurseActiveMutation(SaveGame saveGame) : base(saveGame) { }
    public override void Activate(SaveGame saveGame)
    {
        if (!saveGame.CheckIfRacialPowerWorks(7, 14, Ability.Wisdom, 14))
        {
            return;
        }

        foreach (BaseInventorySlot inventorySlot in saveGame.SingletonRepository.InventorySlots)
        {
            foreach (int slot in inventorySlot.InventorySlots)
            {
                Item? oPtr = saveGame.GetInventoryItem(slot);
                if (oPtr != null && oPtr.IsCursed())
                {
                    oPtr.Inscription = "cursed";
                }
            }
        }
    }

    public override string ActivationSummary(int lvl)
    {
        return lvl < 7 ? "detect curses    (unusable until level 7)" : "detect curses    (cost 14, WIS based)";
    }

    public override int Frequency => 2;
    public override string GainMessage => "You can feel evil magics.";
    public override string HaveMessage => "You can feel the danger of evil magic.";
    public override string LoseMessage => "You can no longer feel evil magics.";
}