namespace AngbandOS.Core.Genders;

[Serializable]
internal class FemaleGender : Gender
{
    private FemaleGender(SaveGame saveGame) : base(saveGame) { }
    public override string Title => "Female";
    public override string Winner => "Queen";
    public override int Index => Constants.SexFemale;
}