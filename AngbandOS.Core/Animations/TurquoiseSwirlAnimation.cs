namespace AngbandOS.Core.Animations;

[Serializable]
internal class TurquoiseSwirlAnimation : Animation
{
    private TurquoiseSwirlAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Turquoise;
    public override string Name => "TurquoiseSwirl";
    public override Colour AlternateColour => Colour.Turquoise;
    public override string Sequence => @"|/-\|/-\|/-\|/-\";
}
