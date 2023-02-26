namespace AngbandOS.Core.Animations;

[Serializable]
internal class SilverSparkleAnimation : Animation
{
    private SilverSparkleAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Silver;
    public override string Name => "SilverSparkle";
    public override Colour AlternateColour => Colour.Silver;
    public override string Sequence => @"·+·x·+·";
}
