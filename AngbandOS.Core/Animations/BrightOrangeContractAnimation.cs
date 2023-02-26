namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightOrangeContractAnimation : Animation
{
    private BrightOrangeContractAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightOrange;
    public override string Name => "BrightOrangeContract";
    public override Colour AlternateColour => Colour.BrightOrange;
    public override string Sequence => @"Oo·";
}
