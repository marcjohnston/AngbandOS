using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class AdamantiteRodFlavour : BaseRodFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.Chartreuse;
    public override string Name => "Adamantite";
}
