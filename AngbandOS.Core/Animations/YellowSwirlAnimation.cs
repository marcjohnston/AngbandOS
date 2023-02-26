namespace AngbandOS.Core.Animations;

[Serializable]
internal class YellowSwirlAnimation : Animation
{
    private YellowSwirlAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Yellow;
    public override string Name => "YellowSwirl";
    public override Colour AlternateColour => Colour.Yellow;
    public override string Sequence => @"|/-\|/-\|/-\|/-\";
}
