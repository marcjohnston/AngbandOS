namespace AngbandOS.Core.RingFlavours;

[Serializable]
internal class TortoiseShellRingFlavour : RingFlavour
{
    private TortoiseShellRingFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '=';
    public override Colour Colour => Colour.Yellow;
    public override string Name => "Tortoise Shell";
}
