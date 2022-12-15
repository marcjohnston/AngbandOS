namespace AngbandOS.Core;

[Serializable]
internal class FunnelVault : Vault
{
    public override char Character => '#';
    public override string Name => "Funnel";
    public override int Category => 8;
    public override int Height => 21;
    public override int Rating => 15;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%XXXXXXXXXXXXXXXXXXXXX%%X&&&...........***X.#%%X&XXXXXXXXXXXXXXX*X.X%%X&X&&&.......***X*X.X%%X.X&XXXXXXXXXX.*X.X.X%%X.X&X8XX,,,,,XX*X.X.X%%X.X.XX*,,,,,,,X.X.X.X%%X.X.XX@@@@@@@@@.X.X.X%%X.X.X89,,,,,,,,.X.X.X%%X.X.X89,,,,,,,,.X.X.X%%X.X.X89,,,,,,,,.X.X.X%%X.X.XX@@@@@@@@@XX.X.X%%X.X.XX*,,,,,,,*XX.X.X%%X.X*X8XX,,,,,XX8X&X.X%%X.X*XXXXXXXXXXXXX&X.X%%X*X***.........&&&X&X%%X*XXXXXXXXXXXXXXXXX&X%%X***.............&&&X%%XXXXXXXXXXXXXXXXXXXXX%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 23;
}
