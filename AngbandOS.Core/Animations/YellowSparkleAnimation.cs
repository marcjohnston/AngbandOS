namespace AngbandOS.Core.Animations;

[Serializable]
internal class YellowSparkleAnimation : Animation
{
    private YellowSparkleAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Yellow;
    public override string Name => "YellowSparkle";
    public override Colour AlternateColour => Colour.Yellow;
    public override string Sequence => @"·+·x·+·";
}
