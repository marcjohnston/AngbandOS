namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightBeigeContractAnimation : Animation
{
    private BrightBeigeContractAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightBeige;
    public override string Name => "BrightBeigeContract";
    public override Colour AlternateColour => Colour.BrightBeige;
    public override string Sequence => @"Oo·";
}
