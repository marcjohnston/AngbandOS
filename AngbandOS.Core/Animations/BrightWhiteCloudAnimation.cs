namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightWhiteCloudAnimation : Animation
{
    private BrightWhiteCloudAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "BrightWhiteCloud";
    public override Colour AlternateColour => Colour.BrightWhite;
    public override string Sequence => @"+*+*+*+";
}
