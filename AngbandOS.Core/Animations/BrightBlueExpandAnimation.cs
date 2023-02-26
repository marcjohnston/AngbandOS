namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightBlueExpandAnimation : Animation
{
    private BrightBlueExpandAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightBlue;
    public override string Name => "BrightBlueExpand";
    public override Colour AlternateColour => Colour.BrightBlue;
    public override string Sequence => @"·oO";
}
