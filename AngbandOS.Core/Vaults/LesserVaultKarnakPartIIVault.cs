namespace AngbandOS.Core.Vaults;

[Serializable]
internal class LesserVaultKarnakPartIIVault : Vault
{
    private LesserVaultKarnakPartIIVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '#';
    public override string Name => "Lesser vault (Karnak, part II)";
    public override int Category => 7;
    public override int Height => 20;
    public override int Rating => 10;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%...........................%%.###+######################%%.#,+^#,,#,,#^+^+^#*#,#^+,#.%%.###.#,,#,,#^#^#^#*#,#^###.%%.#,+^#,,#,,#^#^#^#*#+#^+,#.%%.###.#++#++#^#^#^#+#.#^###.%%.#,+^#^^^^^+^#^#^+,,,#^+,#.%%.###.#^^^^^+^#^#+#+###^###.%%.#,+^#+#+#+#^#^#,#^+,#^+,#.%%.###.#,#,#,#^#^#######^###.%%.#,+^#######+#,,+,,,,,^+,#.%%.###^^^^^^#,^#,,+,,,,#^###.%%.#,+^#,#*^##+####,,,,,^+,#.%%.###^,,,*^#^^^^^#,,,,#^###.%%.#,+^#,#*^#,,,,^+,,,,,^+,#.%%.###^^^^^^#^^^^^#,,,,,^###.%%...##########+##########...%%...........................%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 29;
}
