namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightBeigeExpandAnimation : Animation
{
    private BrightBeigeExpandAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightBeige;
    public override string Name => "BrightBeigeExpand";
    public override Colour AlternateColour => Colour.BrightBeige;
    public override string Sequence => @"·oO";
}
