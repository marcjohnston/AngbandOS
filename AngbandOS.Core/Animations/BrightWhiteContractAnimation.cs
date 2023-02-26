namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightWhiteContractAnimation : Animation
{
    private BrightWhiteContractAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "BrightWhiteContract";
    public override Colour AlternateColour => Colour.BrightWhite;
    public override string Sequence => @"Oo·";
}
