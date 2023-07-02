// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Vaults;

[Serializable]
internal class CycloneVault : Vault
{
    private CycloneVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<PoundSignSymbol>();
    public override string Name => "Cyclone";
    public override int Category => 8;
    public override int Height => 23;
    public override int Rating => 40;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX%%XXXX^^^^^^^^^XXX^^^^^^^^^XXX^^^#XXX8.X.&.X.&.X..*X+^.^.^.^.^.^..XX*^.^.^.^.^.^.^.^.^.^#8X%%XX***XXX...XXX...XXX...XXX...XXX^^X*.X^X^X^X^X^X.*XXXXXXXXXXXXX..XX^^XXXXXXXXXXXXXXXXXX#X%%X88XXX...XXX...XXX...XXX...XXX^^^,X*.X^X^X^X^X^X..*XX8@,,,,,,@XX,.XX^^..........@&.,**X.X%%XXXX@&@XXX@@@XXX&&&XXX&@&XXX^^^,..X*.X^X^X^X^X^X...@X@........@X,..X...........@&..,**X.X%%XX...XXX...XXX...XXX...XXX^^^,....X*.X^X^X^X^X^X...@X*..*9*..@XX^^XXXX*.......@&@..,**X.X%%X*.XXX...XXX...XXX...XXX^^^^....,,X*.&.X.&.X.&.X..*XX*.....,XXX.XXX@@XXX*....@&..@.,**X.X%%X*XX...XXX...XXX...XXX^^^,.^...XX+XXXXXXXXXXXXXX.*XX*....,,XXX.XXXXXX&&XXX*.@&....@8**X.X%%X^^^^XXX^^^^^^^^^XXX^^^,..*^.&XX.*X&^^*****^^#X.*XX*....,XXX&&XXX@@X#X*..XX@&.....8@**X.X%%XXXXXXXXXXXXXXXXXX^^^,...**^.&X8.*X@XXXXXXXXXX^.XX&....XXX&&XXX*****XXX*..XXXXXXXXXXXXX.X%%#^^^^^^^^^^^^^9#^^^.....*99^.@X8.*#^^^*****8XXXXX8@..XX#@@XX#@@@....8XXX*.+^.^.^.^.^.^+.X%%XXXXXXXXXXXXXXXXXX^^^,...**^.&X8.*X@XXXXXXXXXX^.XX&....XXX&&XXX*****XXX*..XXXXXXXXXXXXX.X%%X^^^^XXX^^^^^^^^^XXX^^^,..*^.&XX.*X&^^*****^^#X.*XX*....,XXX&&XXX@@X#X*..XX@&.....8@**X.X%%X*XX...XXX...XXX...XXX^^^,.^...XX+XXXXXXXXXXXXXX.*XX*....,,XXX.XXXXXX&&XXX*.@&....@8**X.X%%X*.XXX...XXX...XXX...XXX^^^^....,,X*.&.X.&.X.&.X..*XX*.....,XXX.XXX@@XXX*....@&..@.,**X.X%%XX...XXX...XXX...XXX...XXX^^^,....X*.X^X^X^X^X^X...@X*..*9*..@XX^^XXXX*.......@&@..,**X.X%%XXXX@&@XXX@@@XXX&&&XXX&@&XXX^^^,..X*.X^X^X^X^X^X...@X@........@X,..X...........@&..,**X.X%%X88XXX...XXX...XXX...XXX...XXX^^^,X*.X^X^X^X^X^X..*XX8@,,,,,,@XX,.XX^^..........@&.,**X.X%%XX***XXX...XXX...XXX...XXX...XXX^^X*.X^X^X^X^X^X.*XXXXXXXXXXXXX..XX^^XXXXXXXXXXXXXXXXXX#X%%XXXX^^^^^^^^^XXX^^^^^^^^^XXX^^^#XXX8.X.&.X.&.X..*X+^.^.^.^.^.^..XX*^.^.^.^.^.^.^.^.^.^#8X%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 91;
}
