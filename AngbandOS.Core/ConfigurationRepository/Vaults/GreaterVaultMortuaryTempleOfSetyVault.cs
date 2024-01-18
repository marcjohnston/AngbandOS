// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Vaults;

[Serializable]
internal class GreaterVaultMortuaryTempleOfSetyVault : Vault
{
    private GreaterVaultMortuaryTempleOfSetyVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(PoundSignSymbol));
    public override string Name => "Greater vault (mortuary temple of sety)";
    public override int Category => 8;
    public override int Height => 25;
    public override int Rating => 35;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%................................%%.XXXXXXXXXXXXXXXXXXXXXXXXXXXXXX.%%.X^+,,***X,,+^^^^^+,,X*X,,X*X9X.%%.X^XXXXXXX,,X^X*X^X,,X,X,,X*X9X.%%.X^+,,***XXXX^*@*^X,,X^X,,X@X9X.%%.X^XXXXXXX,,X^X*X^XXXX^X,,X^X9X.%%.X^+,,***X,,+^^^^^+..X^X,,X^X^X.%%.X^XXXXXXXXXXXX+XXXXXX+X++X+X+X.%%.X^X*X*X*X**X,+.+,X**X^^^^+^^^X.%%.X+X,X,X,X,,XXX.XXX,,X^^^^+^^^X.%%.X^X^X^X^X,,X,X.X,X,,X^^XXXXXXX.%%.X^X+X+X+X^^X,X.X,X^^X^^X,,,,,X.%%.X^+^^^^^X++X+X+X+X++X^^X,X,X,X.%%.X^XXXXXXX^^^^^^^^^^^X^^X,,,,,X.%%.X^X*X*X*XXXX^...^XXXX^^X,X,X,X.%%.X^X,X,X,X,,+^X*X^+,,X^^X,,,,,X.%%.X^X^X^X^XXXX^.&.^XXXX^^X,X,X,X.%%.X^X+X+X+X,,+^X*X^+,,X^^X,,,,,X.%%.X^X^^^^^XXXX^...^XXXX^^X,X,X,X.%%.X^X*X,X*X,,X^X*X^X,,X^^X,,,,,X.%%.X^+^^^^^+^^+^^^^^+^^+^^X,,,,,X.%%.XXXXXXXXXXXXXX+XXXXXXXXXXX+XXX.%%................................%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 34;
}
