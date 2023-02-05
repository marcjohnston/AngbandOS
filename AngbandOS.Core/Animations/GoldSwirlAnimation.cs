namespace AngbandOS.Core.Animations;

[Serializable]
internal class GoldSwirlAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Gold;
    public override string Name => "GoldSwirl";
    public override Colour AlternateColour => Colour.Gold;
    public override string Sequence => @"|/-\|/-\|/-\|/-\";
}
