namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightYellowCloudAnimation : Animation
{
    private BrightYellowCloudAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightYellow;
    public override string Name => "BrightYellowCloud";
    public override Colour AlternateColour => Colour.BrightYellow;
    public override string Sequence => @"+*+*+*+";
}
