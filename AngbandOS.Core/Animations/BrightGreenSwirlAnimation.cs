namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightGreenSwirlAnimation : Animation
{
    private BrightGreenSwirlAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightGreen;
    public override string Name => "BrightGreenSwirl";
    public override Colour AlternateColour => Colour.BrightGreen;
    public override string Sequence => @"|/-\|/-\|/-\|/-\";
}
