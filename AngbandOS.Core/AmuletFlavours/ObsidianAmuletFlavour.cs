namespace AngbandOS.Core.AmuletFlavours;

[Serializable]
internal class ObsidianAmuletFlavour : AmuletFlavour
{
    public override char Character => '"';
    public override Colour Colour => Colour.Black;
    public override string Name => "Obsidian";
}
