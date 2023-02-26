namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightPurpleSwirlAnimation : Animation
{
    private BrightPurpleSwirlAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightPurple;
    public override string Name => "BrightPurpleSwirl";
    public override Colour AlternateColour => Colour.BrightPurple;
    public override string Sequence => @"|/-\|/-\|/-\|/-\";
}
