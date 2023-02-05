namespace AngbandOS.Core.Animations;

[Serializable]
internal class RedTurquoiseFlashAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightTurquoise;
    public override string Name => "RedTurquoiseFlash";
    public override Colour AlternateColour => Colour.BrightRed;
    public override string Sequence => @"********";
}
