namespace AngbandOS.Core.Flavours;

[Serializable]
internal class UridiumRodFlavour : RodFlavour
{
    private UridiumRodFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override Colour Colour => Colour.Grey;
    public override string Name => "Uridium";
}