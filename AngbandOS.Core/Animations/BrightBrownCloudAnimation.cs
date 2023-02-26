namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightBrownCloudAnimation : Animation
{
    private BrightBrownCloudAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "BrightBrownCloud";
    public override Colour AlternateColour => Colour.BrightBrown;
    public override string Sequence => @"+*+*+*+";
}
