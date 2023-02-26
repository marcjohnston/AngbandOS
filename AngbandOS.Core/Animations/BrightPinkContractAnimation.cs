namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightPinkContractAnimation : Animation
{
    private BrightPinkContractAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightPink;
    public override string Name => "BrightPinkContract";
    public override Colour AlternateColour => Colour.BrightPink;
    public override string Sequence => @"Oo·";
}
