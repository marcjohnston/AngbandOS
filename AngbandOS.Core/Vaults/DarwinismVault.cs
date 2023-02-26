namespace AngbandOS.Core.Vaults;

[Serializable]
internal class DarwinismVault : Vault
{
    private DarwinismVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '#';
    public override string Name => "Darwinism";
    public override int Category => 8;
    public override int Height => 16;
    public override int Rating => 25;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%...............................%%...............................%%.............######............%%..........####&&&&####.......#.%%.......####,,,,,,,,,,####...##.%%....####...,,@###..,,...##.###.%%.####8...#.,,@#89#.,,...8###9#.%%.####8.....,,@#89#.,,...8###9#.%%....####...,,@###..,,...##.###.%%.......####,,,,,,,,,,####...##.%%........#.####&&&&####.#.....#.%%........#....######....#.......%%.......##.............##.......%%...............................%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 33;
}
