namespace AngbandOS.Core.Animations;

[Serializable]
internal class RedSparkleAnimation : Animation
{
    private RedSparkleAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Red;
    public override string Name => "RedSparkle";
    public override Colour AlternateColour => Colour.Red;
    public override string Sequence => @"·+·x·+·";
}
