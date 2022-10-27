using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class LVTurnaboutVaultType : BaseVaultType
{
    public override char Character => '#';
    public override string Name => "LV (Turnabout)";
    public override int Category => 7;
    public override int Height => 14;
    public override int Rating => 10;
    public override string Text => "%%%%%%%%%%%%%%%%%%###############%%#.............#%%#.###########.#%%#.#9##,,,,###.#%%#.###^^##,,##.#%%#.##&^^&##,,#.#%%#.###^^^^#,,#.#%%#.#,##,,##,,#.#%%#.#9,##^#@@##.#%%#.#####^#####.#%%#.............#%%###############%%%%%%%%%%%%%%%%%%";
    public override int Width => 17;
}
