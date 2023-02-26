namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightBlueCloudAnimation : Animation
{
    private BrightBlueCloudAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightBlue;
    public override string Name => "BrightBlueCloud";
    public override Colour AlternateColour => Colour.BrightBlue;
    public override string Sequence => @"+*+*+*+";
}
