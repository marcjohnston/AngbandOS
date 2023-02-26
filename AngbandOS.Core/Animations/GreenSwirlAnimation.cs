namespace AngbandOS.Core.Animations;

[Serializable]
internal class GreenSwirlAnimation : Animation
{
    private GreenSwirlAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Green;
    public override string Name => "GreenSwirl";
    public override Colour AlternateColour => Colour.Green;
    public override string Sequence => @"|/-\|/-\|/-\|/-\";
}
