// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class QuaffScript : Script
{
    private QuaffScript(SaveGame saveGame) : base(saveGame) { }

    public override bool Execute()
    {
        if (!SaveGame.SelectItem(out Item? item, "Quaff which potion? ", true, true, true, new ItemCategoryItemFilter(ItemTypeEnum.Potion)))
        {
            SaveGame.MsgPrint("You have no potions to quaff.");
            return false;
        }
        if (item == null)
        {
            return false;
        }
        // Make sure the item is a potion
        if (!SaveGame.ItemMatchesFilter(item, new ItemCategoryItemFilter(ItemTypeEnum.Potion)))
        {
            SaveGame.MsgPrint("That is not a potion!");
            return false;
        }
        SaveGame.PlaySound(SoundEffectEnum.Quaff);
        // Drinking a potion costs a whole turn
        SaveGame.EnergyUse = 100;
        int itemLevel = item.Factory.Level;
        // Do the actual potion effect
        PotionItemFactory potion = (PotionItemFactory)item.Factory; // The item will be a potion.
        bool identified = potion.Quaff();

        // Skeletons are messy drinkers
        SaveGame.Race.Quaff(potion);
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(NoticeCombineAndReorderGroupSetFlaggedAction)).Set();
        // We may now know the potion's type
        item.ObjectTried();
        if (identified && !item.IsFlavourAware())
        {
            item.BecomeFlavourAware();
            SaveGame.GainExperience((itemLevel + (SaveGame.ExperienceLevel >> 1)) / SaveGame.ExperienceLevel);
        }
        // Most potions give us a bit of food too
        SaveGame.SetFood(SaveGame.Food + item.TypeSpecificValue);
        bool channeled = false;
        // If we're a channeler, we might be able to spend mana instead of using it up
        if (SaveGame.BaseCharacterClass.SpellCastingType.CanUseManaInsteadOfConsumingItem)
        {
            channeled = SaveGame.DoCmdChannel(item);
        }
        if (!channeled)
        {
            // We didn't channel it, so use up one potion from the stack
            item.ItemIncrease(-1);
            item.ItemDescribe();
            item.ItemOptimize();
        }
        return false;
    }
}
