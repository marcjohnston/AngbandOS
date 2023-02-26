namespace AngbandOS.Core.Animations;

[Serializable]
internal class BlackSwirlAnimation : Animation
{
    private BlackSwirlAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Black;
    public override string Name => "BlackSwirl";
    public override Colour AlternateColour => Colour.Black;
    public override string Sequence => @"|/-\|/-\|/-\|/-\";
}
