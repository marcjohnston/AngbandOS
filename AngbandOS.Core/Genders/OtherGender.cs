namespace AngbandOS.Core.Genders
{
    [Serializable]
    internal class OtherGender : Gender
    {
        private OtherGender(SaveGame saveGame) : base(saveGame) { }
        public override string Title => "Other";
        public override string Winner => "Monarch";
        public override int Index => 2;

        /// <summary>
        /// Returns false, because the Other gender shouldn't be selected when a random character is chosen.
        /// </summary>
        public override bool CanBeRandomlySelected => false;
    }
}