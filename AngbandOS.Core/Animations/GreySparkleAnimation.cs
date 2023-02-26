namespace AngbandOS.Core.Animations;

[Serializable]
internal class GreySparkleAnimation : Animation
{
    private GreySparkleAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Grey;
    public override string Name => "GreySparkle";
    public override Colour AlternateColour => Colour.Grey;
    public override string Sequence => @"·+·x·+·";
}
