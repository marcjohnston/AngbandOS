// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class StaffItemFactory : ItemFactory, IFlavour
{
    public StaffItemFactory(SaveGame saveGame) : base(saveGame) { }
    public override ItemClass ItemClass => SaveGame.SingletonRepository.ItemClasses.Get(nameof(StaffsItemClass));

    /// <summary>
    /// Returns the factory that this item was created by; casted as an IFlavour.
    /// </summary>
    public IFlavour FlavourFactory => (IFlavour)this;

    public override string GetVerboseDescription(Item item)
    {
        string s = "";
        if (item.IsKnown())
        {
            s += $" ({item.TypeSpecificValue} {Pluralize("charge", item.TypeSpecificValue)})";
        }
        s += base.GetVerboseDescription(item);
        return s;
    }

    public override string GetDescription(Item item, bool includeCountPrefix)
    {
        string flavour = item.IdentStoreb ? "" : $"{FlavourFactory.Flavor.Name} ";
        string ofName = item.IsFlavourAware() ? $" of {FriendlyName}" : "";
        string name = $"{flavour}{Pluralize("Staff", item.Count)}{ofName}";
        return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
    }

    public override int? GetBonusRealValue(Item item, int value)
    {
        return value / 20 * item.TypeSpecificValue;
    }

    public override bool ItemsCanBeMerged(Item a, Item b)
    {
        if (!base.ItemsCanBeMerged(a, b))
        {
            return false;
        }
        if (a.TypeSpecificValue != b.TypeSpecificValue)
        {
            return false;
        }
        return true;
    }

    /// <summary>
    /// Returns the staff flavours repository because staves have flavours that need to be identified.
    /// </summary>
    public IEnumerable<Flavour>? GetFlavorRepository() => SaveGame.SingletonRepository.StaffFlavours;

    public override bool CanBeUsed => true;

    /// <inheritdoc/>
    public Flavour Flavor { get; set; }
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
