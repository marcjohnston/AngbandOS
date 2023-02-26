namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightRedSwirlAnimation : Animation
{
    private BrightRedSwirlAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightRed;
    public override string Name => "BrightRedSwirl";
    public override Colour AlternateColour => Colour.BrightRed;
    public override string Sequence => @"|/-\|/-\|/-\|/-\";
}
