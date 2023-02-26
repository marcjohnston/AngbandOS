namespace AngbandOS.Core.Animations;

[Serializable]
internal class BlackSparkleAnimation : Animation
{
    private BlackSparkleAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Black;
    public override string Name => "BlackSparkle";
    public override Colour AlternateColour => Colour.Black;
    public override string Sequence => @"·+·x·+·";
}
