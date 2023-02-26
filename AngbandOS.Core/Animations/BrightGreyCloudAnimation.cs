namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightGreyCloudAnimation : Animation
{
    private BrightGreyCloudAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightGrey;
    public override string Name => "BrightGreyCloud";
    public override Colour AlternateColour => Colour.BrightGrey;
    public override string Sequence => @"+*+*+*+";
}
