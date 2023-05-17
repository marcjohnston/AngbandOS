namespace AngbandOS.Core.Genders
{
    internal class OtherGender : Gender
    {
        private OtherGender(SaveGame saveGame) : base(saveGame) { }
        public override string Title => "Other";
        public override string Winner => "Monarch";
    }
}