namespace AngbandOS.Core.Animations;

[Serializable]
internal class OrangeSparkleAnimation : Animation
{
    private OrangeSparkleAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Orange;
    public override string Name => "OrangeSparkle";
    public override Colour AlternateColour => Colour.Orange;
    public override string Sequence => @"·+·x·+·";
}
