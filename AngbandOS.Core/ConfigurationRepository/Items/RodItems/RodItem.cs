// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Items;

[Serializable]
internal abstract class RodItem : Item
{
    public RodItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
    protected override bool FactoryCanAbsorbItem(Item other)
    {
        if (TypeSpecificValue != other.TypeSpecificValue)
        {
            return false;
        }
        return true;
    }

    /// <summary>
    /// Returns the factory that this item was created by; casted as an IFlavour.
    /// </summary>
    public IFlavour FlavourFactory => (IFlavour)Factory;

    public override string GetDescription(bool includeCountPrefix)
    {
        string flavour = IdentStoreb ? "" : $"{FlavourFactory.Flavor.Name} ";
        string ofName = IsFlavourAware() ? $" of {Factory.FriendlyName}" : "";
        string name = $"{flavour}{Pluralize("Rod", Count)}{ofName}";
        return includeCountPrefix ? GetPrefixCount(true, name, Count, IsKnownArtifact) : name;
    }
    public override string GetVerboseDescription()
    {
        string s = "";
        if (IsKnown() && TypeSpecificValue != 0)
        {
            s += $" (charging)";
        }
        s += base.GetVerboseDescription();
        return s;
    }
}