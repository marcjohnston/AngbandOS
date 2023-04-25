namespace AngbandOS.Core.Flavours;

[Serializable]
internal class TungstenWandFlavour : WandFlavour
{
    private TungstenWandFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override Colour Colour => Colour.Grey;
    public override string Name => "Tungsten";
}
