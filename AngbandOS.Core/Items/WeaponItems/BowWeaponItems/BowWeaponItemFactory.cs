namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal abstract class BowWeaponItemFactory : WeaponItemClass // TODO: Should be renamed to RangedWeaponItemClass
{
    public BowWeaponItemFactory(SaveGame saveGame) : base(saveGame) { }
    public override BaseInventorySlot BaseWieldSlot => SaveGame.SingletonRepository.InventorySlots.Get<RangedWeaponInventorySlot>();
    /// <summary>
    /// Returns a damage multiplier when the missile weapon is used.
    /// </summary>
    public virtual int MissileDamageMultiplier => 1;
    public override int? SubCategory => null; // The subcategory for all bows have been resolved.

    public override int PackSort => 32;
    public abstract ItemTypeEnum AmmunitionItemCategory { get; }

    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Bow;
    public override bool HatesFire => true;
    public override bool HatesAcid => true;
    public override Colour Colour => Colour.Brown;
}
