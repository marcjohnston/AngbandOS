// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class QuaffScript : UniversalScript, IGetKey
{
    private QuaffScript(Game game) : base(game) { }

    /// <summary>
    /// Returns the entity serialized into a Json string.  Returns an empty string by default.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        return "";
    }

    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }

    /// <summary>
    /// Executes the quaff script.
    /// </summary>
    /// <returns></returns>
    public override void ExecuteScript()
    {
        if (!Game.SelectItem(out Item? item, "Quaff which potion? ", false, true, true, Game.SingletonRepository.Get<ItemFilter>(nameof(CanBeQuaffedItemFilter))))
        {
            Game.MsgPrint("You have no potions to quaff.");
            return;
        }
        if (item == null)
        {
            return;
        }

        // Make sure the item is a potion
        if (item.QuaffTuple == null)
        {
            Game.MsgPrint("That is not a potion!");
            return;
        }
        Game.PlaySound(SoundEffectEnum.Quaff);

        // Drinking a potion costs a whole turn
        Game.EnergyUse = 100;
        int itemLevel = item.LevelNormallyFound;

        // Do the actual potion effect
        IdentifiedResult identifiedResult = item.QuaffTuple.Value.QuaffScript.ExecuteEatOrQuaffScript();

        // Skeletons are messy drinkers
        Game.Race.Quaff(item);
        Game.SingletonRepository.Get<FlaggedAction>(nameof(NoticeCombineAndReorderGroupSetFlaggedAction)).Set();

        // We may now know the potion's type
        item.ObjectTried();
        if (identifiedResult.IsIdentified && !item.IsFlavorAware)
        {
            item.IsFlavorAware = true;
            Game.GainExperience((itemLevel + (Game.ExperienceLevel.IntValue >> 1)) / Game.ExperienceLevel.IntValue);
        }

        // Most potions give us a bit of food too
        Game.SetFood(Game.Food.IntValue + item.NutritionalValue);

        bool channeled = false;
        // If we're a channeler, we might be able to spend mana instead of using it up
        if (Game.BaseCharacterClass.CanUseManaInsteadOfConsumingItem)
        {
            channeled = Game.DoCmdChannel(item, item.QuaffTuple.Value.ManaEquivalent);
        }
        if (!channeled)
        {
            // We didn't channel it, so use up one potion from the stack
            item.ModifyStackCount(-1);
            item.ItemDescribe();
            item.ItemOptimize();
        }
    }
}
