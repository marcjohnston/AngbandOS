using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class ObsidianAmuletFlavour : AmuletFlavour
{
    public override char Character => '"';
    public override Colour Colour => Colour.Black;
    public override string Name => "Obsidian";
}
