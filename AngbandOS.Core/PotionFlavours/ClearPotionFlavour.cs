namespace AngbandOS.Core;

[Serializable]
internal class ClearPotionFlavour : PotionFlavour
{
    public override char Character => '!';
    public override string Name => "Clear";
}
