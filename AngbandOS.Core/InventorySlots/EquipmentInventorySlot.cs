// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.InventorySlots
{
    [Serializable]
    internal abstract class EquipmentInventorySlot : BaseInventorySlot
    {
        protected EquipmentInventorySlot(SaveGame saveGame) : base(saveGame) { }
        /// <summary>
        /// Returns true.
        /// </summary>
        public override bool IsEquipment => true;

        /// <summary>
        /// Allows wielded equipment items to process world.
        /// </summary>
        public override void ProcessWorld(ProcessWorldEventArgs processWorldEventArgs)
        {
            if (processWorldEventArgs.SaveGame.Player.Race.IsBurnedBySunlight)
            {
                foreach (int index in InventorySlots)
                {
                    Item oPtr = processWorldEventArgs.SaveGame.Player.Inventory[index];
                    if (oPtr.BaseItemCategory != null && oPtr.BaseItemCategory.ProvidesSunlight && !processWorldEventArgs.SaveGame.Player.HasLightResistance)
                    {
                        string oName = oPtr.Description(false, 0);
                        processWorldEventArgs.SaveGame.MsgPrint($"The {oName} scorches your undead flesh!");
                        processWorldEventArgs.DisableRegeneration = true;
                        oName = oPtr.Description(true, 0);
                        string ouch = $"wielding {oName}";
                        if (processWorldEventArgs.SaveGame.Player.TimedInvulnerability.TimeRemaining == 0)
                        {
                            processWorldEventArgs.SaveGame.Player.TakeHit(1, ouch);
                        }
                    }
                }
            }
        }
    }
}