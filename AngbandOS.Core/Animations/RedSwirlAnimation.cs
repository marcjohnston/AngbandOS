namespace AngbandOS.Core.Animations;

[Serializable]
internal class RedSwirlAnimation : Animation
{
    private RedSwirlAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Red;
    public override string Name => "RedSwirl";
    public override Colour AlternateColour => Colour.Red;
    public override string Sequence => @"|/-\|/-\|/-\|/-\";
}
