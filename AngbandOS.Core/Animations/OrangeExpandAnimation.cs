namespace AngbandOS.Core.Animations;

[Serializable]
internal class OrangeExpandAnimation : Animation
{
    private OrangeExpandAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Orange;
    public override string Name => "OrangeExpand";
    public override Colour AlternateColour => Colour.Orange;
    public override string Sequence => @"·oO";
}
