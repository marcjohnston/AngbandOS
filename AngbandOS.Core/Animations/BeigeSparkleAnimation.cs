namespace AngbandOS.Core.Animations;

[Serializable]
internal class BeigeSparkleAnimation : Animation
{
    private BeigeSparkleAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Beige;
    public override string Name => "BeigeSparkle";
    public override Colour AlternateColour => Colour.Beige;
    public override string Sequence => @"·+·x·+·";
}
