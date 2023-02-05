namespace AngbandOS.Core.VaultTypes;

[Serializable]
internal class LesserVaultspiralVault : Vault
{
    public override char Character => '#';
    public override string Name => "Lesser vault (spiral)";
    public override int Category => 7;
    public override int Height => 19;
    public override int Rating => 5;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%...................%%.+################.%%.#^#*&..,.......*#.%%.#.#.###########.#.%%.#.#.#*.,.....*#.#.%%.#.#.#.#######.#.#.%%.#.#.#.#,...*#.#.#.%%.#.#.#.#,###.#.#.#.%%.#,#,#,#,,*#,#,#,#.%%.#.#.#.###,#.#.#.#.%%.#.#.#*.,.*#.#.#.#.%%.#.#.#######.#.#.#.%%.#.#*...,...*#.#.#.%%.#.###########.#.#.%%.#*.....,....&*#^#.%%.################+.%%...................%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 21;
}
