// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Vaults;

[Serializable]
internal class GreaterVaultNethackHellLevel2Vault : Vault
{
    private GreaterVaultNethackHellLevel2Vault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<PoundSignSymbol>();
    public override string Name => "Greater vault (nethack hell level #2)";
    public override int Category => 8;
    public override int Height => 15;
    public override int Rating => 30;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%....................................................%%.XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX...%%.+^XX,+^^^^^X^^^^^^^^^^^^^^^^^^^^^X,,,X,@^X*^*+9X...%%.X^XX,X^XXX,X@XXXXXXXXXXXXXXXXXXX^X,X,X,X^X*X*X9X...%%.X^XX,X^^^X,X^^^^^^^^^^^^^^^^^^@X^X,X,X,X^X*X*X9X...%%.X^XXXXXX^X,XXXXXXXXXXXXXXXXXXX^X^X,X,X,X^X*X*X+XXX.%%.X^^^^^^X^X,X,,,,,,,,,,,,,,,,,X^X^X,X,X,X^X*X*X888X.%%.X+XXXX^X^X,X,XXXXXXXXXXXXXXX,X^X^X,X,X,X^X*X*X+XXX.%%.X,XX,X^X^X,X,X,,,,,,,,,,,,,,,X^X^X,X,X,X^X*X*X9X...%%.X,XX,X^X&X,X,X,XXXXXXXXXXXXXXX^X^X,X,X,X^X*X*X9X...%%.X,XX,+^^^X,,,X^^^^^^^^^^^^^^^^^X^@,X,,,X^@*X*+9X...%%.XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX...%%....................................................%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 54;
}
