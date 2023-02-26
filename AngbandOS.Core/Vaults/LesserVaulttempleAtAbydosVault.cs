namespace AngbandOS.Core.Vaults;

[Serializable]
internal class LesserVaulttempleAtAbydosVault : Vault
{
    private LesserVaulttempleAtAbydosVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '#';
    public override string Name => "Lesser vault (temple at abydos)";
    public override int Category => 7;
    public override int Height => 21;
    public override int Rating => 10;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%^^^^^^^^^^^^^^^^^^^^^%%^#+#+#####+#####+#+#^%%^#,#,#^^^^^^^^^#,#,#^%%^#,#,#^#.#.#.#^#,#,#^%%^#,#,#^...&...^#,#,#^%%^#####^#.#.#.#^#####^%%^#*,,+^^^^^^^^^+,,*#^%%^#########+#########^%%^#*,,+^^^^^^^^^+,,*#^%%^#####^#.#.#.#^#####^%%^#*,,+^...&...^+,,*#^%%^#####^#.#.#.#^#####^%%^#*,,+^^^^^^^^^+,,*#^%%^##+###+##+##+###+##^%%^#,,,,#,#^^^#,#,,,,#^%%^#,##,#,#,#,#,#,##,#^%%^#,,,,#,#***#,#,,,,#^%%^###################^%%^^^^^^^^^^^^^^^^^^^^^%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 23;
}
