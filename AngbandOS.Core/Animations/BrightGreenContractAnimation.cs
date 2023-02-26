namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightGreenContractAnimation : Animation
{
    private BrightGreenContractAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightGreen;
    public override string Name => "BrightGreenContract";
    public override Colour AlternateColour => Colour.BrightGreen;
    public override string Sequence => @"Oo·";
}
