namespace AngbandOS.Core.Animations;

[Serializable]
internal class GreyExpandAnimation : Animation
{
    private GreyExpandAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Grey;
    public override string Name => "GreyExpand";
    public override Colour AlternateColour => Colour.Grey;
    public override string Sequence => @"·oO";
}
