namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class AmmunitionItemClass : WeaponItemClass
    {
        public AmmunitionItemClass(SaveGame saveGame) : base(saveGame) { }
        public override int? GetTypeSpecificRealValue(Item item, int value)
        {
            return ComputeTypeSpecificRealValue(item, value);
        }

    }
}
