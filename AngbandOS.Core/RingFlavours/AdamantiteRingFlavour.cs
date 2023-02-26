namespace AngbandOS.Core.RingFlavours;

[Serializable]
internal class AdamantiteRingFlavour : RingFlavour
{
    private AdamantiteRingFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '=';
    public override Colour Colour => Colour.Chartreuse;
    public override string Name => "Adamantite";
}
