namespace AngbandOS.Core;

[Serializable]
internal class TurquoiseFlashAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Turquoise;
    public override string Name => "TurquoiseFlash";
    public override Colour AlternateColour => Colour.BrightTurquoise;
    public override string Sequence => @"********";
}
