// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class ReadScrollScript : UniversalScript, IGetKey
{
    private ReadScrollScript(Game game) : base(game) { }

    /// <summary>
    /// Returns the entity serialized into a Json string.  Returns an empty string by default.
    /// </summary>
    /// <returns></returns>

    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }

    /// <summary>
    /// Executes the read scroll script.
    /// </summary>
    /// <returns></returns>
    public override void ExecuteScript()
    {
        // Make sure we're in a situation where we can read
        if (Game.BlindnessTimer.Value != 0)
        {
            Game.MsgPrint("You can't see anything.");
            return;
        }
        if (Game.NoLight())
        {
            Game.MsgPrint("You have no light to read by.");
            return;
        }
        if (Game.ConfusionTimer.Value != 0)
        {
            Game.MsgPrint("You are too confused!");
            return;
        }
        if (!Game.SelectItem(out Item? item, "Read which scroll? ", false, true, true, Game.SingletonRepository.Get<ItemFilter>(nameof(CanBeReadItemFilter))))
        {
            Game.MsgPrint("You have no scrolls to read.");
            return;
        }
        if (item == null)
        {
            return;
        }
        // Make sure the item is actually a scroll
        if (item.ReadTuple == null)
        {
            Game.MsgPrint("That is not a scroll!");
            return;
        }
        // Scrolls use a full turn
        Game.EnergyUse = 100;
        //bool identified = false;
        //bool usedUp = true;

        IdentifiedAndUsedResult identifiedAndUsedResult = item.ReadTuple.Value.ActivationScript.ExecuteReadScrollOrUseStaffScript();

        Game.SingletonRepository.Get<FlaggedAction>(nameof(NoticeCombineAndReorderGroupSetFlaggedAction)).Set();
        // We might have just identified the scroll
        item.ObjectTried();
        if (identifiedAndUsedResult.IsIdentified && !item.IsFlavorAware)
        {
            item.IsFlavorAware = true;
            int itemLevel = item.LevelNormallyFound;
            Game.GainExperience((itemLevel + (Game.ExperienceLevel.IntValue >> 1)) / Game.ExperienceLevel.IntValue);
        }
        bool channeled = false;
        // Channelers can use mana instead of the scroll being used up
        if (Game.CharacterClass.CanUseManaInsteadOfConsumingItem)
        {
            channeled = Game.DoCmdChannel(item, item.ReadTuple.Value.ManaValue);
        }
        if (!channeled)
        {
            if (!identifiedAndUsedResult.IsUsed)
            {
                return;
            }
            // If it wasn't used up then decrease the amount in the stack
            item.ModifyStackCount(-1);
            item.ItemDescribe();
            item.ItemOptimize();
        }
    }
}
