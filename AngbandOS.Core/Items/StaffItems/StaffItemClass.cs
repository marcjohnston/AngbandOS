namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal abstract class StaffItemClass : ItemFactory, IFlavour
{
    public StaffItemClass(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Returns the staff flavours repository because staves have flavours that need to be identified.
    /// </summary>
    public IEnumerable<Flavour>? GetFlavourRepository() => SaveGame.SingletonRepository.StaffFlavours;

    /// <inheritdoc/>
    public Flavour Flavour { get; set; }

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
    public override Colour Colour => Colour.Purple;
}
