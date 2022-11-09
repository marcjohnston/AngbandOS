using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class TurquoiseControlAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Turquoise;
    public override string Name => "TurquoiseControl";
    public override Colour AlternateColour => Colour.BrightTurquoise;
    public override string Sequence => @"!!!!";
}
