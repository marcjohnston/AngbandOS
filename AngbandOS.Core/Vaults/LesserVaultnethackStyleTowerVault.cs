namespace AngbandOS.Core.Vaults;

[Serializable]
internal class LesserVaultnethackStyleTowerVault : Vault
{
    private LesserVaultnethackStyleTowerVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '#';
    public override string Name => "Lesser vault (nethack-style tower)";
    public override int Category => 7;
    public override int Height => 15;
    public override int Rating => 5;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%.................%%...###.###.###...%%...#&#.#&#.#&#...%%.###+###+###+###.%%.#.,.,.,.+.+,,,#.%%.###+#####.#####.%%...+*&*&*#.+,#...%%.###+#####.#####.%%.#.,.,.,.+.+,,,#.%%.###+###+###+###.%%...#&#.#&#.#&#...%%...###.###.###...%%.................%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 19;
}
