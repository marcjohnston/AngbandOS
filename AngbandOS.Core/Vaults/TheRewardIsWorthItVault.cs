namespace AngbandOS.Core.Vaults;

[Serializable]
internal class TheRewardIsWorthItVault : Vault
{
    private TheRewardIsWorthItVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '#';
    public override string Name => "The Reward is Worth It";
    public override int Category => 8;
    public override int Height => 16;
    public override int Rating => 20;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%XXXXXXXXXXXXXXX##XXXXXXXXXXXXX#XXXXXXXXXXXXX##XXXXXXXXXXXXXXX%%X@@@@@@@@@@@.XX88XX.......,,,X^X,,,.......XX88XX.@@@@@@@@@@@X%%X@XXXXXXXXXX..XXXX...XXXX.,,,X^X,,,.XXXX...XXXX..XXXXXXXXXX@X%%X@X8888888XXX..XX...XXX@XX,,,X^X,,,XX@XXX...XX..XXX8888888X@X%%X@X88899999XXX.....XXX@@@X..&X^X&..X@@@XXX.....XXX99999888X@X%%X@X8899.....XXX...XXX@@@@@..&X^X&..@@@@@XXX...XXX.....9988X@X%%X@X899.......XXX...XXX......&X^X&......XXX...XXX.......998X@X%%X+XXX...XXX&&&XXX^^^XXX.....&X^X&.....XXX^^^XXX&&&XXX...XXX+X%%X@@XXX.XXXX&&&&XXX^^^XXX....&X^X&....XXX^^^XXX&&&&XXXX.XXX@@X%%X^^^^XXX88X^^^^^^XXX^^^XXX..&X^X&..XXX^^^XXX^^^^^^X88XXX^^^^X%%X&&&&&&&&XX^^^^^^^^XXX...XXX&X^X&XXX...XXX^^^^^^^^XX&&&&&&&&X%%X,,,,,,,XX,,,,,,,,,,,XXX&&&XXX^XXX&&&XXX,,,,,,,,,,,XX,,,,,,,X%%X,,,,,,X#@@@@@@@@@@@@@@XXX&&&&&&&&&XXX@@@@@@@@@@@@@@#X,,,,,,X%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 63;
}
