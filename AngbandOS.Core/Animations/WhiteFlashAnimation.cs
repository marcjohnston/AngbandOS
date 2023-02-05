namespace AngbandOS.Core.Animations;

[Serializable]
internal class WhiteFlashAnimation : Animation
{
    public override char Character => '*';
    public override string Name => "WhiteFlash";
    public override Colour AlternateColour => Colour.BrightWhite;
    public override string Sequence => @"********";
    public override Colour Colour => Colour.White;
}
