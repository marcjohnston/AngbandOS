namespace AngbandOS.Core.RodFlavours;

[Serializable]
internal class RunedRodFlavour : RodFlavour
{
    private RunedRodFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override Colour Colour => Colour.Red;
    public override string Name => "Runed";
}
