using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class ObsidianAmuletFlavour : BaseAmuletFlavour
{
    public override char Character => '"';
    public override Colour Colour => Colour.Black;
    public override string Name => "Obsidian";
}
