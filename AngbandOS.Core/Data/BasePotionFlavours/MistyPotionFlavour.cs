using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class MistyPotionFlavour : BasePotionFlavour
{
    public override char Character => '!';
    public override string Name => "Misty";
}
