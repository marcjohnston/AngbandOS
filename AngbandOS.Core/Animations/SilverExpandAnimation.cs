namespace AngbandOS.Core.Animations;

[Serializable]
internal class SilverExpandAnimation : Animation
{
    private SilverExpandAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Silver;
    public override string Name => "SilverExpand";
    public override Colour AlternateColour => Colour.Silver;
    public override string Sequence => @"·oO";
}
