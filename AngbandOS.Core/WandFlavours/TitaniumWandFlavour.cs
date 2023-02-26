namespace AngbandOS.Core.WandFlavours;

[Serializable]
internal class TitaniumWandFlavour : WandFlavour
{
    private TitaniumWandFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override string Name => "Titanium";
}
