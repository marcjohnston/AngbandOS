namespace AngbandOS.Core.Animations;

[Serializable]
internal class GoldSparkleAnimation : Animation
{
    private GoldSparkleAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Gold;
    public override string Name => "GoldSparkle";
    public override Colour AlternateColour => Colour.Gold;
    public override string Sequence => @"·+·x·+·";
}
