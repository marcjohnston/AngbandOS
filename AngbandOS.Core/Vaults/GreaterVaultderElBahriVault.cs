// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Vaults;

[Serializable]
internal class GreaterVaultDerElBahriVault : Vault
{
    private GreaterVaultDerElBahriVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<PoundSignSymbol>();
    public override string Name => "Greater vault (der el bahri)";
    public override int Category => 8;
    public override int Height => 28;
    public override int Rating => 35;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%.XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX.%%.X***X,,X^^^^^^^^X9988899X^^^^^^^^+******X.%%.X***X,,+^..,...^X9999999X^...,..^XXXX***X.%%.X***XXXX^......^XXXX+XXXX^......^X**XXXXX.%%.X^^^X,,X^..,...^^^^^^^^^^^...,..^X******X.%%.X@@@X,,X^.......................^X,,,,,,X.%%.X^^^X,,X^..,..,..,..,..,..,..,..^X,,,,,,X.%%.X^^^X++X^.......................^X,,,,,,X.%%.X^^^X^^X^..,..,..,..,..,..,..,..^X,,,,,,X.%%.X^^^^^^+^.......................^X,,,,,,X.%%.X^^^^^^X^..,..,..,..,..,..,..,..^X,,,,,,X.%%.XXX+XXXX^.......................^X,,,,,,X.%%.X***X**X^..,..,..,..,..,..,..,..^X,,,,,,X.%%.XXXXX**X^.......................^X,,,,,,X.%%.X,,,,,,+^.......................^+,,,,,,X.%%.X,,,,,,+^^^^^^^^^^^^^^^^^^^^^^^^^+,,,,,,X.%%.XXXXXXXXXXXXXXXXXXX+++XXXXXXXXXXXXXXXXXXX.%%.X.............^^^^^^^^^^^^..............X.%%.X................^^^^^^^................X.%%.XXXXXXXXXXXXXXXXXXX^^^XXXXXXXXXXXXXXXXXXX.%%.X.................X.^.X.................X.%%.X.X.X.X.X.X.X.X.X.X^^^X.X.X.X.X.X.X.X.X.X.%%.X.................X.^.X.................X.%%.X.X.X.X.X.X.X.X.X.X^^^X.X.X.X.X.X.X.X.X.X.%%.X.................X.^.X.................X.%%...........................................%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 45;
}
