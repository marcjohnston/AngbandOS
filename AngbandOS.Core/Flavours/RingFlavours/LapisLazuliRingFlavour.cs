namespace AngbandOS.Core.Flavours;

[Serializable]
internal class LapisLazuliRingFlavour : RingFlavour
{
    private LapisLazuliRingFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '=';
    public override Colour Colour => Colour.Turquoise;
    public override string Name => "Lapis Lazuli";
}
