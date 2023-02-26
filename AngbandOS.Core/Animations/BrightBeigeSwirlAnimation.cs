namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightBeigeSwirlAnimation : Animation
{
    private BrightBeigeSwirlAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightBeige;
    public override string Name => "BrightBeigeSwirl";
    public override Colour AlternateColour => Colour.BrightBeige;
    public override string Sequence => @"|/-\|/-\|/-\|/-\";
}
