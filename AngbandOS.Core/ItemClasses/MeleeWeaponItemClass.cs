namespace AngbandOS.Core.ItemClasses
{
    /// <summary>
    /// Represents common characteristics for melee weapons.  Hafted, polearm and swords are all melee weapons.
    /// </summary>
    [Serializable]
    internal abstract class MeleeWeaponItemClass : WeaponItemClass
    {
        public MeleeWeaponItemClass(SaveGame saveGame) : base(saveGame) { }
        public override BaseInventorySlot BaseWieldSlot => SaveGame.SingletonRepository.InventorySlots.Get<MeleeWeaponInventorySlot>();
    }
}
