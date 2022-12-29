namespace AngbandOS.Core;

[Serializable]
internal class BlackWhiteFlashAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "BlackWhiteFlash";
    public override Colour AlternateColour => Colour.Black;
    public override string Sequence => @"********";
}
