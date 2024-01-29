// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class PowerRingItemFactory : RingItemFactory
{
    private PowerRingItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(EqualSignSymbol));
    public override ColorEnum Color => ColorEnum.Yellow;
    public override string Name => "Power";

    public override string GetDescription(Item item, bool includeCountPrefix)
    {
        if (item.FixedArtifact != null && item.IsFlavourAware())
        {
            return base.GetDescription(item, includeCountPrefix);
        }
        string flavour = item.IdentStoreb ? "" : $"{FlavourFactory.Flavor.Name} ";
        if (!item.IsFlavourAware())
        {
            flavour = "Plain Gold ";
        }
        string ofName = item.IsFlavourAware() ? $" of {FriendlyName}" : "";
        string name = $"{flavour}{Pluralize("Ring", item.Count)}{ofName}";
        return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
    }

    public override int Cost => 5000000;
    public override string FriendlyName => "Power";
    public override bool InstaArt => true;
    public override int Level => 110;
    public override int Weight => 2;
    public override Item CreateItem() => new Item(SaveGame, this);
}
