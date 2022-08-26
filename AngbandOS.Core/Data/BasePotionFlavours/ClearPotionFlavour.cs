using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class ClearPotionFlavour : BasePotionFlavour
{
    public override char Character => '!';
    public override string Name => "Clear";
}
