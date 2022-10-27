using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class RedBlackFlashAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Black;
    public override string Name => "RedBlackFlash";
    public override Colour AlternateColour => Colour.Red;
    public override string Sequence => @"********";
}
