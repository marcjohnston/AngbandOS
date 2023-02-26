namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrownSparkleAnimation : Animation
{
    private BrownSparkleAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Brown;
    public override string Name => "BrownSparkle";
    public override Colour AlternateColour => Colour.Brown;
    public override string Sequence => @"·+·x·+·";
}
