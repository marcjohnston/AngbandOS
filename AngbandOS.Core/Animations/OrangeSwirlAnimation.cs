namespace AngbandOS.Core.Animations;

[Serializable]
internal class OrangeSwirlAnimation : Animation
{
    private OrangeSwirlAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Orange;
    public override string Name => "OrangeSwirl";
    public override Colour AlternateColour => Colour.Orange;
    public override string Sequence => @"|/-\|/-\|/-\|/-\";
}
