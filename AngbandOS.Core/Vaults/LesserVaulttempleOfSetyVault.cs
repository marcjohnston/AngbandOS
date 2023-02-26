namespace AngbandOS.Core.Vaults;

[Serializable]
internal class LesserVaulttempleOfSetyVault : Vault
{
    private LesserVaulttempleOfSetyVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '#';
    public override string Name => "Lesser vault (temple of sety)";
    public override int Category => 7;
    public override int Height => 22;
    public override int Rating => 10;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%.##########+##########.%%.#,,,,,,,#^^^#,,,,,,,#.%%.#,,,,,,,+^^^+,,,,,,,#.%%.#########^^^#########.%%.#,,,,,,,#^^^#,,,,,,,#.%%.#,,,,,,,+^^^+,,,,,,,#.%%.#########+###########.%%.#^^^+^^^+^^^^^#,.,.,#.%%.#.#^#^#.#^#.#.#.#.#.#.%%.#.&^#^.&#^.&..#,.,.,#.%%.#.#^+^#.#^#.#.#.#.#.#.%%.#^^^#^^^#^^^^^#,.,.,#.%%.#+#+###+###+###.#.#.#.%%.#,#^^^^^^^^^^^#,.,.,#.%%.#,#.#.#.#.#.#.#+###^#.%%.#,#...........#,**#^#.%%.#*#.#.#.#.#.#.#####+#.%%.#*#^^^^^^^^^^^+&^^^&#.%%.#######+#############.%%.......................%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 25;
}
