namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightPinkSwirlAnimation : Animation
{
    private BrightPinkSwirlAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightPink;
    public override string Name => "BrightPinkSwirl";
    public override Colour AlternateColour => Colour.BrightPink;
    public override string Sequence => @"|/-\|/-\|/-\|/-\";
}
