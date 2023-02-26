namespace AngbandOS.Core.Animations;

[Serializable]
internal class PinkContractAnimation : Animation
{
    private PinkContractAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Pink;
    public override string Name => "PinkContract";
    public override Colour AlternateColour => Colour.Pink;
    public override string Sequence => @"Oo·";
}
