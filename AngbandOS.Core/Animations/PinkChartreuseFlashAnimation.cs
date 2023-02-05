namespace AngbandOS.Core.Animations;

[Serializable]
internal class PinkChartreuseFlashAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightChartreuse;
    public override string Name => "PinkChartreuseFlash";
    public override Colour AlternateColour => Colour.BrightPink;
    public override string Sequence => @"********";
}
