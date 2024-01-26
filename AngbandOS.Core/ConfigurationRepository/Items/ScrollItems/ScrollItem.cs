// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Items;

[Serializable]
internal abstract class ScrollItem : Item
{
    public ScrollItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
    protected override bool FactoryCanAbsorbItem(Item other)
    {
        return true;
    }
    public override int GetAdditionalMassProduceCount()
    {
        int cost = Value();
        if (cost <= 60)
        {
            return MassRoll(3, 5);
        }
        if (cost <= 240)
        {
            return MassRoll(1, 5);
        }
        return 0;
    }

    /// <summary>
    /// Returns the factory that this item was created by; casted as an IFlavour.
    /// </summary>
    public IFlavour FlavourFactory => (IFlavour)Factory;

    public override string GetDescription(bool includeCountPrefix)
    {
        string flavour = IdentStoreb ? "" : $" titled \"{FlavourFactory.Flavor.Name}\"";
        string ofName = IsFlavourAware() ? $" of {Factory.FriendlyName}" : "";
        string name = $"{Pluralize("Scroll", Count)}{flavour}{ofName}";
        return includeCountPrefix ? GetPrefixCount(true, name, Count, IsKnownArtifact) : name;
    }
}