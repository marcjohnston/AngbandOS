namespace AngbandOS.Core.Vaults;

[Serializable]
internal class LesserVaultamenhotepIVault : Vault
{
    private LesserVaultamenhotepIVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '#';
    public override string Name => "Lesser vault (amenhotep I)";
    public override int Category => 7;
    public override int Height => 18;
    public override int Rating => 10;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%................................%%...............######...........%%...............#.&&.#...........%%.###############.##.#...........%%.#**#,,,+^^^^^^^^##.###.........%%.#**#,,,#^^^^^^^^^^...#########.%%.##+#####^^#######^&#.#.......#.%%.#,,,,,,+^^+,*,*,+^^^^^^^^^^^^+.%%.#,,,,,,+^^+*,*,*+^^^^^^^^^^^^+.%%.##+#####^^#######^&#.#.......#.%%.#**#,,,#^^^^^^^^^^...#########.%%.#**#,,,+^^^^^^^^##.###.........%%.###############.##.#...........%%...............#.&&.#...........%%...............######...........%%................................%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 34;
}
