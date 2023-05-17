namespace AngbandOS.Core.Genders
{
    internal class MaleGender : Gender
    {
        private MaleGender(SaveGame saveGame) : base(saveGame) { }
        public override string Title => "Male";
        public override string Winner => "King";
    }
}