namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightOrangeSwirlAnimation : Animation
{
    private BrightOrangeSwirlAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightOrange;
    public override string Name => "BrightOrangeSwirl";
    public override Colour AlternateColour => Colour.BrightOrange;
    public override string Sequence => @"|/-\|/-\|/-\|/-\";
}
