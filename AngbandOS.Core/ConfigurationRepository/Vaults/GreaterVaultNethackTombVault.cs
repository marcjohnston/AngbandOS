// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Vaults;

[Serializable]
internal class GreaterVaultNethackTombVault : Vault
{
    private GreaterVaultNethackTombVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(PoundSignSymbol));
    public override string Name => "Greater vault (nethack tomb)";
    public override int Category => 8;
    public override int Height => 13;
    public override int Rating => 25;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%.......................................................%%..........XXXXX.XXXXX.XXXXX.XXXXX.XXXXX................%%..........X,,,X.X,,,X.X,,,X.X,,,X.X,,,X................%%.XXXXXXXXXX,&,XXX,&,XXX,&,XXX,&,XXX,&,XXXXXXXXXXXXXXXX.%%.X&^&X....^...^...^...^...^...^...^..^..X,,,,,,,,X,,9X.%%.+^^^+..^...^...^...^...^...^...^...^.@.+,,,,,,,,+,98X.%%.X&^&X....^...^...^...^...^...^...^.....X,,,,,,,,X,,9X.%%.XXXXXXXXXX,&,XXX,.,XXX,.,XXX,&,XXX,&,XXXXXXXXXXXXXXXX.%%..........X,,,X.X,,,X.X,,,X.X,,,X.X,,,X................%%..........XXXXX.XXXXX.XXXXX.XXXXX.XXXXX................%%.......................................................%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 57;
}
