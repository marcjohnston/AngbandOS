// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Vaults;

[Serializable]
internal class GreaterVaultNethackCastleAlmostVault : Vault
{
    private GreaterVaultNethackCastleAlmostVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(PoundSignSymbol));
    public override string Name => "Greater vault (nethack castle (almost))";
    public override int Category => 8;
    public override int Height => 19;
    public override int Rating => 35;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%............................................................%%.XXXXXXX............................................XXXXXXX.%%.X,,9,,XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX,,9,,X.%%.X,,,,,+.......^....*....^ ..........^.......*...^..+,,,,,X.%%.XXXXXXXXXXXXXXXXXXXXXXXXXXXXXX+XXXXXXXXXXXXXXXXXXXXXXXXXXX.%%......X,.,9,,,,X,,,,,,,,,+,.,.,.,.,.,X,.,.,.+^+,.,.,.X......%%......X,.9*9,.,X,,,,,,,,,X,.,..,..,.,X,.,.,.X^X,.,.,.X......%%....&.X.&*@*&,.XXXXXXXXXXX,.,.,9,.,.,XXXXXXXX+XXXXXXXX......%%......+9*@8@*9.+^^^^^^^^^+,.,,9@9,,.,+^^^^^^^^^^^^^^^+......%%....&.X.&*@*&,.XXXXXXXXXXX,.,.,9,.,.,XXXXXXXX+XXXXXXXX......%%......X,.9*9,.,X,,,,,,,,,X,.,.,,,.,.,X.,.,.,X^X.,.,.,X......%%......X,.,9,,,,X,,,,,,,,,+,.,.,.,.,.,X.,.,.,+^+.,.,.,X......%%.XXXXXXXXXXXXXXXXXXXXXXXXXXXXXX+XXXXXXXXXXXXXXXXXXXXXXXXXXX.%%.X,,,,,+.......^....*....^...........^.......*...^..+,,,,,X.%%.X,,9,,XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX,,9,,X.%%.XXXXXXX............................................XXXXXXX.%%............................................................%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 62;
}
