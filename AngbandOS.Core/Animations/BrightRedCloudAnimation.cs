namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightRedCloudAnimation : Animation
{
    private BrightRedCloudAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightRed;
    public override string Name => "BrightRedCloud";
    public override Colour AlternateColour => Colour.BrightRed;
    public override string Sequence => @"+*+*+*+";
}
