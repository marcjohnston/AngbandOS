namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class StaffItemClass : ItemFactory
    {
        public StaffItemClass(SaveGame saveGame) : base(saveGame) { }
        /// <summary>
        /// Executes the staff action.  Returns true, if the usage identifies the staff.
        /// </summary>
        /// <param name="saveGame"></param>
        /// <returns></returns>
        public abstract void UseStaff(UseStaffEvent eventArgs);

        public override int PackSort => 15;
        public override bool HasFlavor => true;
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Staff;
        public override int BaseValue => 70;
        public override bool HatesFire => true;
        public override bool HatesAcid => true;

        //public override bool IsCharged => true;
        public override Colour Colour => Colour.Purple;
    }
}
