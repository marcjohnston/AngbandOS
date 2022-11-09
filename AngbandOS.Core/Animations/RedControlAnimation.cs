using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class RedControlAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Red;
    public override string Name => "RedControl";
    public override Colour AlternateColour => Colour.BrightRed;
    public override string Sequence => @"!!!!";
}
