// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class ReadScrollScript : Script, IScript, IRepeatableScript
{
    private ReadScrollScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the read scroll script and returns false.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteRepeatableScript()
    {
        ExecuteScript();
        return false;
    }

    /// <summary>
    /// Executes the read scroll script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        // Make sure we're in a situation where we can read
        if (SaveGame.BlindnessTimer.Value != 0)
        {
            SaveGame.MsgPrint("You can't see anything.");
            return;
        }
        if (SaveGame.NoLight())
        {
            SaveGame.MsgPrint("You have no light to read by.");
            return;
        }
        if (SaveGame.ConfusedTimer.Value != 0)
        {
            SaveGame.MsgPrint("You are too confused!");
            return;
        }
        if (!SaveGame.SelectItem(out Item? item, "Read which scroll? ", false, true, true, SaveGame.SingletonRepository.ItemFilters.Get(nameof(CanBeReadItemFilter))))
        {
            SaveGame.MsgPrint("You have no scrolls to read.");
            return;
        }
        if (item == null)
        {
            return;
        }
        // Make sure the item is actually a scroll
        if (!SaveGame.ItemMatchesFilter(item, SaveGame.SingletonRepository.ItemFilters.Get(nameof(CanBeReadItemFilter))))
        {
            SaveGame.MsgPrint("That is not a scroll!");
            return;
        }
        // Scrolls use a full turn
        SaveGame.EnergyUse = 100;
        //bool identified = false;
        //bool usedUp = true;

        ScrollItemFactory scrollItem = (ScrollItemFactory)item.Factory;
        ReadScrollEvent readScrollEventArgs = new ReadScrollEvent();
        scrollItem.Read(readScrollEventArgs);

        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(NoticeCombineAndReorderGroupSetFlaggedAction)).Set();
        // We might have just identified the scroll
        item.ObjectTried();
        if (readScrollEventArgs.Identified && !item.IsFlavorAware())
        {
            item.BecomeFlavorAware();
            int itemLevel = item.Factory.LevelNormallyFound;
            SaveGame.GainExperience((itemLevel + (SaveGame.ExperienceLevel.Value >> 1)) / SaveGame.ExperienceLevel.Value);
        }
        bool channeled = false;
        // Channelers can use mana instead of the scroll being used up
        if (SaveGame.BaseCharacterClass.CanUseManaInsteadOfConsumingItem)
        {
            channeled = SaveGame.DoCmdChannel(item);
        }
        if (!channeled)
        {
            if (!readScrollEventArgs.UsedUp)
            {
                return;
            }
            // If it wasn't used up then decrease the amount in the stack
            item.ItemIncrease(-1);
            item.ItemDescribe();
            item.ItemOptimize();
        }
    }
}
