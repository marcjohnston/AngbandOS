namespace AngbandOS.Core;

[Serializable]
internal class GreenFlashAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Green;
    public override string Name => "GreenFlash";
    public override Colour AlternateColour => Colour.BrightGreen;
    public override string Sequence => @"********";
}
