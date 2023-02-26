namespace AngbandOS.Core.PotionFlavours;

[Serializable]
internal class MistyPotionFlavour : PotionFlavour
{
    private MistyPotionFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '!';
    public override string Name => "Misty";
}
