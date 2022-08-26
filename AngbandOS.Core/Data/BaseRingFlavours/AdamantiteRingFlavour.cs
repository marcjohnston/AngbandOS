using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class AdamantiteRingFlavour : BaseRingFlavour
{
    public override char Character => '=';
    public override Colour Colour => Colour.Chartreuse;
    public override string Name => "Adamantite";
}
