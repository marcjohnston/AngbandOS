using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class PurpleControlAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Purple;
    public override string Name => "PurpleControl";
    public override Colour AlternateColour => Colour.BrightPurple;
    public override string Sequence => @"!!!!";
}
