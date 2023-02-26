namespace AngbandOS.Core.PotionFlavours;

[Serializable]
internal class ClearPotionFlavour : PotionFlavour
{
    private ClearPotionFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '!';
    public override string Name => "Clear";
}
