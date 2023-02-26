namespace AngbandOS.Core.Animations;

[Serializable]
internal class CopperSparkleAnimation : Animation
{
    private CopperSparkleAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Copper;
    public override string Name => "CopperSparkle";
    public override Colour AlternateColour => Colour.Copper;
    public override string Sequence => @"·+·x·+·";
}
