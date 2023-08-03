// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Vaults;

[Serializable]
internal class LesserVaulttempleAtAbydosVault : Vault
{
    private LesserVaulttempleAtAbydosVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<PoundSignSymbol>();
    public override string Name => "Lesser vault (temple at abydos)";
    public override int Category => 7;
    public override int Height => 21;
    public override int Rating => 10;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%^^^^^^^^^^^^^^^^^^^^^%%^#+#+#####+#####+#+#^%%^#,#,#^^^^^^^^^#,#,#^%%^#,#,#^#.#.#.#^#,#,#^%%^#,#,#^...&...^#,#,#^%%^#####^#.#.#.#^#####^%%^#*,,+^^^^^^^^^+,,*#^%%^#########+#########^%%^#*,,+^^^^^^^^^+,,*#^%%^#####^#.#.#.#^#####^%%^#*,,+^...&...^+,,*#^%%^#####^#.#.#.#^#####^%%^#*,,+^^^^^^^^^+,,*#^%%^##+###+##+##+###+##^%%^#,,,,#,#^^^#,#,,,,#^%%^#,##,#,#,#,#,#,##,#^%%^#,,,,#,#***#,#,,,,#^%%^###################^%%^^^^^^^^^^^^^^^^^^^^^%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 23;
}
