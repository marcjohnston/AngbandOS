namespace AngbandOS.Core.Animations;

[Serializable]
internal class WhiteSwirlAnimation : Animation
{
    private WhiteSwirlAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override string Name => "WhiteSwirl";
    public override string Sequence => @"|/-\|/-\|/-\|/-\";
    public override Colour Colour => Colour.White;
    public override Colour AlternateColour => Colour.White;
}
