namespace AngbandOS.Core;

[Serializable]
internal class GreenPurpleFlashAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightPurple;
    public override string Name => "GreenPurpleFlash";
    public override Colour AlternateColour => Colour.BrightGreen;
    public override string Sequence => @"********";
}
