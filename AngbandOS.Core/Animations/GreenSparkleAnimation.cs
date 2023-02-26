namespace AngbandOS.Core.Animations;

[Serializable]
internal class GreenSparkleAnimation : Animation
{
    private GreenSparkleAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Green;
    public override string Name => "GreenSparkle";
    public override Colour AlternateColour => Colour.Green;
    public override string Sequence => @"·+·x·+·";
}
