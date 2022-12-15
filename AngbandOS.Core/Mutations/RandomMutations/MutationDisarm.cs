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
    internal class MutationDisarm : Mutation
    {
        public override void Initialise()
        {
            Frequency = 1;
            GainMessage = "Your feet grow to four times their former size.";
            HaveMessage = "You occasionally stumble and drop things.";
            LoseMessage = "Your feet shrink to their former size.";
        }

        public override void OnProcessWorld(SaveGame saveGame)
        {
            if (Program.Rng.DieRoll(10000) != 1)
            {
                return;
            }
            saveGame.Disturb(false);
            saveGame.MsgPrint("You trip over your own feet!");
            saveGame.Player.TakeHit(Program.Rng.DieRoll(saveGame.Player.Weight / 6), "tripping");
            saveGame.MsgPrint(null);
            Item oPtr = saveGame.Player.Inventory[InventorySlot.MeleeWeapon];
            if (oPtr.BaseItemCategory == null)
            {
                return;
            }
            saveGame.MsgPrint("You drop your weapon!");
            saveGame.Player.Inventory.InvenDrop(InventorySlot.MeleeWeapon, 1);
        }
    }
}