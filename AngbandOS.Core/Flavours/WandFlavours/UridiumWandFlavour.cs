namespace AngbandOS.Core.Flavours;

[Serializable]
internal class UridiumWandFlavour : WandFlavour
{
    private UridiumWandFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override string Name => "Uridium";
}
