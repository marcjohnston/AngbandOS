namespace AngbandOS.Core.Genders;

[Serializable]
internal class MaleGender : Gender
{
    private MaleGender(SaveGame saveGame) : base(saveGame) { }
    public override string Title => "Male";
    public override string Winner => "King";
    public override int Index => Constants.SexMale;
}