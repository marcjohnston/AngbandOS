// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Items;

[Serializable]
internal abstract class FoodItem : Item
{
    public FoodItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
    public override int PercentageBreakageChance => 100;
    protected override bool FactoryCanAbsorbItem(Item other)
    {
        return true;
    }

    public override FoodItemFactory Factory => (FoodItemFactory)base.Factory;

    public override int GetAdditionalMassProduceCount()
    {
        int cost = Value();
        if (cost <= 5)
        {
            return MassRoll(3, 5);
        }
        if (cost <= 20)
        {
            return MassRoll(3, 5);
        }
        return 0;
    }

    public override string GetDescription(bool includeCountPrefix)
    {
        return base.GetDescription(includeCountPrefix);
    }
}