namespace AngbandOS.Core.WandFlavours;

[Serializable]
internal class RunedWandFlavour : WandFlavour
{
    private RunedWandFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override Colour Colour => Colour.Purple;
    public override string Name => "Runed";
}
