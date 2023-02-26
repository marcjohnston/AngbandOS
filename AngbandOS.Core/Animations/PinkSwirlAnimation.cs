namespace AngbandOS.Core.Animations;

[Serializable]
internal class PinkSwirlAnimation : Animation
{
    private PinkSwirlAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Pink;
    public override string Name => "PinkSwirl";
    public override Colour AlternateColour => Colour.Pink;
    public override string Sequence => @"|/-\|/-\|/-\|/-\";
}
