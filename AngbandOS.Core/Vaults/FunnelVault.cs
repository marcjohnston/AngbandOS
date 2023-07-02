// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Vaults;

[Serializable]
internal class FunnelVault : Vault
{
    private FunnelVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<PoundSignSymbol>();
    public override string Name => "Funnel";
    public override int Category => 8;
    public override int Height => 21;
    public override int Rating => 15;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%XXXXXXXXXXXXXXXXXXXXX%%X&&&...........***X.#%%X&XXXXXXXXXXXXXXX*X.X%%X&X&&&.......***X*X.X%%X.X&XXXXXXXXXX.*X.X.X%%X.X&X8XX,,,,,XX*X.X.X%%X.X.XX*,,,,,,,X.X.X.X%%X.X.XX@@@@@@@@@.X.X.X%%X.X.X89,,,,,,,,.X.X.X%%X.X.X89,,,,,,,,.X.X.X%%X.X.X89,,,,,,,,.X.X.X%%X.X.XX@@@@@@@@@XX.X.X%%X.X.XX*,,,,,,,*XX.X.X%%X.X*X8XX,,,,,XX8X&X.X%%X.X*XXXXXXXXXXXXX&X.X%%X*X***.........&&&X&X%%X*XXXXXXXXXXXXXXXXX&X%%X***.............&&&X%%XXXXXXXXXXXXXXXXXXXXX%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 23;
}
