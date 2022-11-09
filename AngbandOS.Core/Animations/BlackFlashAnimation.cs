using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BlackFlashAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Black;
    public override string Name => "BlackFlash";
    public override Colour AlternateColour => Colour.Grey;
    public override string Sequence => @"********";
}
