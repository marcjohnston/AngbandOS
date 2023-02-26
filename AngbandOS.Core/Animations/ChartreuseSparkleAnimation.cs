namespace AngbandOS.Core.Animations;

[Serializable]
internal class ChartreuseSparkleAnimation : Animation
{
    private ChartreuseSparkleAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Chartreuse;
    public override string Name => "ChartreuseSparkle";
    public override Colour AlternateColour => Colour.Chartreuse;
    public override string Sequence => @"·+·x·+·";
}
