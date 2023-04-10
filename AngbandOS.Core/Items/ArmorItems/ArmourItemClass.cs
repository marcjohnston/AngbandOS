namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    /// <summary>
    /// Represents armour items.  Boots, cloaks, crowns, dragon armour, gloves, hard armour, helm, shield and soft armour are all armour classes.
    /// </summary>
    internal abstract class ArmourItemClass : ItemFactory
    {
        public ArmourItemClass(SaveGame saveGame) : base(saveGame) { }
        public override bool HasQuality => true;

        public override int RandartActivationChance => base.RandartActivationChance * 2;

        /// <summary>
        /// Returns true, for all armour where the armour class (ToA) is greater than or equal to zero.
        /// </summary>
        public override bool KindIsGood => ToA >= 0;
    }
}
