namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightPurpleExpandAnimation : Animation
{
    private BrightPurpleExpandAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightPurple;
    public override string Name => "BrightPurpleExpand";
    public override Colour AlternateColour => Colour.BrightPurple;
    public override string Sequence => @"·oO";
}
