namespace AngbandOS.Core.Vaults;

[Serializable]
internal class LVTurnaboutVault : Vault
{
    private LVTurnaboutVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '#';
    public override string Name => "LV (Turnabout)";
    public override int Category => 7;
    public override int Height => 14;
    public override int Rating => 10;
    public override string Text => "%%%%%%%%%%%%%%%%%%###############%%#.............#%%#.###########.#%%#.#9##,,,,###.#%%#.###^^##,,##.#%%#.##&^^&##,,#.#%%#.###^^^^#,,#.#%%#.#,##,,##,,#.#%%#.#9,##^#@@##.#%%#.#####^#####.#%%#.............#%%###############%%%%%%%%%%%%%%%%%%";
    public override int Width => 17;
}
