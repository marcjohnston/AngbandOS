namespace AngbandOS.Core.Animations;

[Serializable]
internal class SilverSwirlAnimation : Animation
{
    private SilverSwirlAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Silver;
    public override string Name => "SilverSwirl";
    public override Colour AlternateColour => Colour.Silver;
    public override string Sequence => @"|/-\|/-\|/-\|/-\";
}
