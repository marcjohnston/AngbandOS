// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class StaffItemFactory : ItemFactory, IFlavorFactory
{
    public StaffItemFactory(SaveGame saveGame) : base(saveGame) { }
    public override ItemClass ItemClass => SaveGame.SingletonRepository.ItemClasses.Get(nameof(StaffsItemClass));

    /// <summary>
    /// Returns the factory that this item was created by; casted as an IFlavor.
    /// </summary>
    public IFlavorFactory FlavorFactory => (IFlavorFactory)this;

    public override string GetVerboseDescription(Item item)
    {
        string s = "";
        if (item.IsKnown())
        {
            s += $" ({item.TypeSpecificValue} {SaveGame.CountPluralize("charge", item.TypeSpecificValue)})";
        }
        s += base.GetVerboseDescription(item);
        return s;
    }

    public override string GetDescription(Item item, bool includeCountPrefix, bool isFlavorAware)
    {
        string flavor = item.IdentityIsStoreBought ? "" : $"{FlavorFactory.Flavor.Name} ";
        string ofName = isFlavorAware ? $" of {FriendlyName}" : "";
        string name = $"{flavor}{SaveGame.CountPluralize("Staff", item.Count)}{ofName}";
        return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
    }

    public override int? GetBonusRealValue(Item item, int value)
    {
        return value / 20 * item.TypeSpecificValue;
    }

    /// <summary>
    /// Returns the staff flavors repository because staves have flavors that need to be identified.
    /// </summary>
    public IEnumerable<Flavor>? GetFlavorRepository() => SaveGame.SingletonRepository.StaffReadableFlavors;

    public override bool CanBeUsed => true;

    /// <inheritdoc/>
    public Flavor Flavor { get; set; }
    public override bool IsRechargable => true;

    /// <summary>
    /// Executes the staff action.  Returns true, if the usage identifies the staff.
    /// </summary>
    /// <param name="saveGame"></param>
    /// <returns></returns>
    public abstract void UseStaff(UseStaffEvent eventArgs);

    public override int PackSort => 15;
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Staff;
    public override int BaseValue => 70;
    public override bool HatesFire => true;
    public override bool HatesAcid => true;

    //public override bool IsCharged => true;
    public override ColorEnum Color => ColorEnum.Purple;
}
