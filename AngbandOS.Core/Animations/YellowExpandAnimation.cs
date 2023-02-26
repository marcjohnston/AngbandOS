namespace AngbandOS.Core.Animations;

[Serializable]
internal class YellowExpandAnimation : Animation
{
    private YellowExpandAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Yellow;
    public override string Name => "YellowExpand";
    public override Colour AlternateColour => Colour.Yellow;
    public override string Sequence => @"·oO";
}
