namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightBrownContractAnimation : Animation
{
    private BrightBrownContractAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "BrightBrownContract";
    public override Colour AlternateColour => Colour.BrightBrown;
    public override string Sequence => @"Oo·";
}
