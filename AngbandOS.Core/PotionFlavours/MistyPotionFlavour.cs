using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class MistyPotionFlavour : PotionFlavour
{
    public override char Character => '!';
    public override string Name => "Misty";
}