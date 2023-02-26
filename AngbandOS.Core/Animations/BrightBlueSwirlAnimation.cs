namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightBlueSwirlAnimation : Animation
{
    private BrightBlueSwirlAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightBlue;
    public override string Name => "BrightBlueSwirl";
    public override Colour AlternateColour => Colour.BrightBlue;
    public override string Sequence => @"|/-\|/-\|/-\|/-\";
}
