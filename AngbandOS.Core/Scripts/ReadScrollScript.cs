// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts
{
    [Serializable]
    internal class ReadScrollScript : Script
    {
        private ReadScrollScript(SaveGame saveGame) : base(saveGame) { }

        public override bool Execute()
        {
            // Make sure we're in a situation where we can read
            if (SaveGame.Player.TimedBlindness.TurnsRemaining != 0)
            {
                SaveGame.MsgPrint("You can't see anything.");
                return false;
            }
            if (SaveGame.Level.NoLight())
            {
                SaveGame.MsgPrint("You have no light to read by.");
                return false;
            }
            if (SaveGame.Player.TimedConfusion.TurnsRemaining != 0)
            {
                SaveGame.MsgPrint("You are too confused!");
                return false;
            }
            if (!SaveGame.SelectItem(out Item? item, "Read which scroll? ", true, true, true, new ItemCategoryItemFilter(ItemTypeEnum.Scroll)))
            {
                SaveGame.MsgPrint("You have no scrolls to read.");
                return false;
            }
            if (item == null)
            {
                return false;
            }
            // Make sure the item is actually a scroll
            if (!SaveGame.Player.ItemMatchesFilter(item, new ItemCategoryItemFilter(ItemTypeEnum.Scroll)))
            {
                SaveGame.MsgPrint("That is not a scroll!");
                return false;
            }
            // Scrolls use a full turn
            SaveGame.EnergyUse = 100;
            //bool identified = false;
            //bool usedUp = true;

            ScrollItemClass scrollItem = (ScrollItemClass)item.Factory;
            ReadScrollEvent readScrollEventArgs = new ReadScrollEvent(SaveGame);
            scrollItem.Read(readScrollEventArgs);

            SaveGame.NoticeCombineAndReorderFlaggedAction.Set();
            // We might have just identified the scroll
            item.ObjectTried();
            if (readScrollEventArgs.Identified && !item.IsFlavourAware())
            {
                item.BecomeFlavourAware();
                int itemLevel = item.Factory.Level;
                SaveGame.Player.GainExperience((itemLevel + (SaveGame.Player.Level >> 1)) / SaveGame.Player.Level);
            }
            bool channeled = false;
            // Channelers can use mana instead of the scroll being used up
            if (SaveGame.Player.BaseCharacterClass.SpellCastingType.CanUseManaInsteadOfConsumingItem)
            {
                channeled = SaveGame.DoCmdChannel(item);
            }
            if (!channeled)
            {
                if (!readScrollEventArgs.UsedUp)
                {
                    return false;
                }
                // If it wasn't used up then decrease the amount in the stack
                item.ItemIncrease(-1);
                item.ItemDescribe();
                item.ItemOptimize();
            }
            return false;
        }
    }
}
