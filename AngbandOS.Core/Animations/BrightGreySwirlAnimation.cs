namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightGreySwirlAnimation : Animation
{
    private BrightGreySwirlAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightGrey;
    public override string Name => "BrightGreySwirl";
    public override Colour AlternateColour => Colour.BrightGrey;
    public override string Sequence => @"|/-\|/-\|/-\|/-\";
}
