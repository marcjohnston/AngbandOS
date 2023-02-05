namespace AngbandOS.Core.Animations;

[Serializable]
internal class ChartreuseFlashAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Chartreuse;
    public override string Name => "ChartreuseFlash";
    public override Colour AlternateColour => Colour.BrightChartreuse;
    public override string Sequence => @"********";
}
