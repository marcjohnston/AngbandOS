namespace AngbandOS.Core.Vaults;

[Serializable]
internal class GreaterVaultcastleVault : Vault
{
    private GreaterVaultcastleVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '#';
    public override string Name => "Greater vault (castle)";
    public override int Category => 8;
    public override int Height => 27;
    public override int Rating => 35;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%.........................%%..XXXXX..XXX+XXX..XXXXX..%%..X,,,X..X.,,,.X..X,,,X..%%..X,,*XXXX.&&&.XXXX*,,X..%%..XXXX+....&&&....+XXXX..%%.....X.....,,,.....X.....%%.....X..,XXX+XXX,..X.....%%.....X.XXX^^^^^XXX.X.....%%.&...X.X,,*****,,X.X..&..%%....XX.X,XXX+XXX,X.XX....%%....X..X,X@@@@@X,X..X....%%....X..X,X@999@X,X..X....%%....X..X,X@989@X,X..X....%%....X..X,X@999@X,X..X....%%....X..X,X@@@@@X,X..X....%%....XX.X,XXX+XXX,X.XX....%%.....X.X,,*****,,X.X.....%%.....X.XXX^^^^^XXX.X.....%%.....X..,XXX+XXX,..X.....%%.....X.....&&&.....X.....%%..XXXX+....&&&....+XXXX..%%..X,,*XXXX.&&&.XXXX*,,X..%%..X,,,X..X.,,,.X..X,,,X..%%..XXXXX..XX^^^XX..XXXXX..%%.........................%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 27;
}
