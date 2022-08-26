using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class ChromiumWandFlavour : BaseWandFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "Chromium";
}
