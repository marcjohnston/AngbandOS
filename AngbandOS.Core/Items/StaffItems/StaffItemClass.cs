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
        public override string GetDescription(Item item, bool includeCountPrefix)
        {
            string flavour = item.IdentStoreb ? "" : $"{item.SaveGame.SingletonRepository.StaffFlavours[item.ItemSubCategory].Name} ";
            string ofName = item.IsFlavourAware() ? $" of {item.Factory.FriendlyName}" : "";
            string name = $"{flavour}{Pluralize("Staff", item.Count)}{ofName}";
            return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
        }


        public override int BaseValue => 70;
        public override bool HatesFire => true;
        public override bool HatesAcid => true;

        //public override bool IsCharged => true;
        public override Colour Colour => Colour.Purple;
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
    }
}
