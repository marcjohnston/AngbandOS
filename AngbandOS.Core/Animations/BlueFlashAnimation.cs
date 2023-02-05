namespace AngbandOS.Core.Animations;

[Serializable]
internal class BlueFlashAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Blue;
    public override string Name => "BlueFlash";
    public override Colour AlternateColour => Colour.BrightBlue;
    public override string Sequence => @"********";
}
