// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Vaults;

[Serializable]
internal class GreaterVaultKarnakPartIVault : Vault
{
    private GreaterVaultKarnakPartIVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(PoundSignSymbol));
    public override string Name => "Greater vault (Karnak, part I)";
    public override int Category => 8;
    public override int Height => 24;
    public override int Rating => 35;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%.XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX.%%.X*****+^+^^^^+^^^X,,,X***X***X***X,****X.%%.XXXXXXXXX^XX^X,,,X,X,X,X,X,X,X*X*X,X*X*X.%%.X,X,X,X,X^..^X,,,X,,,X^^^X^^^X**@+^,,,,X.%%.X^^^^^^^+^@.^X,,,XX+XX+XXXXX+XXXXX+XXXXX.%%.X,X^^^X,X^XX^X***X^^^+^^^^^^^+,,*X^^^^^X.%%.XXXX+XXXX^^^^X,,,XXXXX^X.X.X^XXXXX^X^X^X.%%.X^^^^^^^XXXXXX,,,X,,,X^..@..^+,,*X^^^^&X.%%.X^X,X,X^X,,,,X,,,X,X,X^X.X.X^XXXXX^XXXXX.%%.X^^^^^^^X,,,,X^^^X,,,X^^^^^^^+,,*X^+,,*X.%%.XXXX+XXXXX++XXX+XXX+XXXXX+XXXXXXXX^XXXXX.%%.X*,+^^^^^^^^^^^^^^^^^^^^^^^^^+,,*X^+,,*X.%%.XXXX^X.X.X.X.X.X.X.X.X.X.X.X^XXXXX^XXXXX.%%.X*,+^.........&.....&.......^X,,*X^+,,*X.%%.XXXX^X.X.X.X.X.X.X.X.X.X.X.X^+,X*X^XXXXX.%%.X**X^.......................^X,,*X^+,,*X.%%.X,,+^X.X.X.X.X.X.X.X.X.X.X.X^XXXXX^XXXXX.%%.XXXX^.........&.....&.......^+^^^^^+,,*X.%%.X,,+^X.X.X.X.X.X.X.X.X.X.X.X^X,X,X^XXXXX.%%.X**X^^^^^^^^^^^^^^^^^^^^^^^^^X.*.X^+,,*X.%%.XXXXXXXXXXXXXXXX+XXXXXXXXXXXXXXXXXXXXXXX.%%..........................................%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 44;
}
