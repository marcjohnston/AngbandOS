namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightPinkExpandAnimation : Animation
{
    private BrightPinkExpandAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightPink;
    public override string Name => "BrightPinkExpand";
    public override Colour AlternateColour => Colour.BrightPink;
    public override string Sequence => @"·oO";
}
