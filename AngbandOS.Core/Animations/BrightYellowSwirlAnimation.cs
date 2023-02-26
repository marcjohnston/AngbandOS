namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightYellowSwirlAnimation : Animation
{
    private BrightYellowSwirlAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightYellow;
    public override string Name => "BrightYellowSwirl";
    public override Colour AlternateColour => Colour.BrightYellow;
    public override string Sequence => @"|/-\|/-\|/-\|/-\";
}
