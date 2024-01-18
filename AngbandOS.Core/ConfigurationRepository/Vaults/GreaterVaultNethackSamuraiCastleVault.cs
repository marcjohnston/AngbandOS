// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Vaults;

[Serializable]
internal class GreaterVaultNethackSamuraiCastleVault : Vault
{
    private GreaterVaultNethackSamuraiCastleVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(PoundSignSymbol));
    public override string Name => "Greater vault (nethack samurai castle)";
    public override int Category => 8;
    public override int Height => 20;
    public override int Rating => 35;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%.........................................................%%.XXXXX.............................................XXXXX.%%.X***X.............................................X***X.%%.X***XXX.....XX+XXXXXXXXXXXXXXXXXXXXXXXXX+XX.....XXX***X.%%.XXX@,,X.....X^&^X,,,X***X,,,X***X^^^+8X^&^X.....X,,@XXX.%%...X,,,XXXXXXX^^^X,,,X^^^X,,,X^^^X@@^X8X^^^XXXXXXX,,,X...%%...XXX^^^^^^^^^XXXXX+XXX+X+XXXXX+X+XXXXXXX^^^^^^^^^XXX...%%.....X^^XXXXXXXX*X,,,,,,,,,,,,,,,,,,,,,X*XXXXXXXX^^X.....%%.....X^^+,,,,,,,,+,,,,,,,,,99,,,,,,,,,,+,,,,,,,,+^^X.....%%.....X^^+,,,,,,,,+,,,,,,,,,99,,,,,,,,,,+,,,,,,,,+^^X.....%%.....X^^XXXXXXXX*X,,,,,,,,,,,,,,,,,,,,,X*XXXXXXXX^^X.....%%...XXX^^^^^^^^^XXXXXXX+X+XXXXX+X+XXX+XXXXX^^^^^^^^^XXX...%%...X,,,XXXXXXX^^^X8X^@@X^^^X^^^X,,,X,,,X^^^XXXXXXX,,,X...%%.XXX@,,X.....X^&^X8+^^^X***X***X,,,X,,,X^&^X.....X,,@XXX.%%.X***XXX.....XX+XXXXXXXXXXXXXXXXXXXXXXXXX+XX.....XXX***X.%%.X***X.............................................X***X.%%.XXXXX.............................................XXXXX.%%.........................................................%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 59;
}
