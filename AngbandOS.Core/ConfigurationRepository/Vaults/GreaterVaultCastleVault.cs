// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Vaults;

[Serializable]
internal class GreaterVaultCastleVault : Vault
{
    private GreaterVaultCastleVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string Name => "Greater vault (castle)";
    public override int Category => 8;
    public override int Height => 27;
    public override int Rating => 35;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%.........................%%..XXXXX..XXX+XXX..XXXXX..%%..X,,,X..X.,,,.X..X,,,X..%%..X,,*XXXX.&&&.XXXX*,,X..%%..XXXX+....&&&....+XXXX..%%.....X.....,,,.....X.....%%.....X..,XXX+XXX,..X.....%%.....X.XXX^^^^^XXX.X.....%%.&...X.X,,*****,,X.X..&..%%....XX.X,XXX+XXX,X.XX....%%....X..X,X@@@@@X,X..X....%%....X..X,X@999@X,X..X....%%....X..X,X@989@X,X..X....%%....X..X,X@999@X,X..X....%%....X..X,X@@@@@X,X..X....%%....XX.X,XXX+XXX,X.XX....%%.....X.X,,*****,,X.X.....%%.....X.XXX^^^^^XXX.X.....%%.....X..,XXX+XXX,..X.....%%.....X.....&&&.....X.....%%..XXXX+....&&&....+XXXX..%%..X,,*XXXX.&&&.XXXX*,,X..%%..X,,,X..X.,,,.X..X,,,X..%%..XXXXX..XX^^^XX..XXXXX..%%.........................%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 27;
}
