namespace AngbandOS.Core.Animations;

[Serializable]
internal class WhiteExpandAnimation : Animation
{
    private WhiteExpandAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override string Name => "WhiteExpand";
    public override string Sequence => @"·oO";
    public override Colour Colour => Colour.White;
    public override Colour AlternateColour => Colour.White;
}
