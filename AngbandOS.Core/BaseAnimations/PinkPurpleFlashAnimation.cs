using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class PinkPurpleFlashAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Purple;
    public override string Name => "PinkPurpleFlash";
    public override Colour AlternateColour => Colour.Pink;
    public override string Sequence => @"********";
}
