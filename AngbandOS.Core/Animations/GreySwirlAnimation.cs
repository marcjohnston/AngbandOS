namespace AngbandOS.Core.Animations;

[Serializable]
internal class GreySwirlAnimation : Animation
{
    private GreySwirlAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Grey;
    public override string Name => "GreySwirl";
    public override Colour AlternateColour => Colour.Grey;
    public override string Sequence => @"|/-\|/-\|/-\|/-\";
}
