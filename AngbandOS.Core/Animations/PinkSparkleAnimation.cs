namespace AngbandOS.Core.Animations;

[Serializable]
internal class PinkSparkleAnimation : Animation
{
    private PinkSparkleAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Pink;
    public override string Name => "PinkSparkle";
    public override Colour AlternateColour => Colour.Pink;
    public override string Sequence => @"·+·x·+·";
}
