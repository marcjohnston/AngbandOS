namespace AngbandOS.Core.Vaults;

[Serializable]
internal class LesserVaultnethackCityVault : Vault
{
    private LesserVaultnethackCityVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '#';
    public override string Name => "Lesser vault (nethack city)";
    public override int Category => 7;
    public override int Height => 17;
    public override int Rating => 9;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%...............................%%.############.....############.%%.#,,,#,,,#,,#.....#**#,,,#***#.%%.#,,,#,,,#,,#.....+**#,,,#***#.%%.#,,,#,,,#,,#.....#**#,,,#&&&#.%%.#^,,#,,,#+##.....####+###+###.%%.#+####+##.....................%%...............................%%.#+###+###....###+##...........%%.#^,,#^,,####.#,,,,#.######+##.%%.#,,,#,,,#**#.#,&&,#.+^^#,,,,#.%%.#,,,#,,,#*^+.#,&@,#.#^^#,,,,#.%%.#,,,#,,,#**#.#,,,,#.#**#,,,,#.%%.############.######.#########.%%...............................%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 33;
}
