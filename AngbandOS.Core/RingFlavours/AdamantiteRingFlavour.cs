using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class AdamantiteRingFlavour : RingFlavour
{
    public override char Character => '=';
    public override Colour Colour => Colour.Chartreuse;
    public override string Name => "Adamantite";
}
