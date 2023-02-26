namespace AngbandOS.Core.Animations;

[Serializable]
internal class BeigeSwirlAnimation : Animation
{
    private BeigeSwirlAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Beige;
    public override string Name => "BeigeSwirl";
    public override Colour AlternateColour => Colour.Beige;
    public override string Sequence => @"|/-\|/-\|/-\|/-\";
}
