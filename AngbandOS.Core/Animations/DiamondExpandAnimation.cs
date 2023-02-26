namespace AngbandOS.Core.Animations;

[Serializable]
internal class DiamondExpandAnimation : Animation
{
    private DiamondExpandAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Diamond;
    public override string Name => "DiamondExpand";
    public override Colour AlternateColour => Colour.Diamond;
    public override string Sequence => @"·oO";
}
