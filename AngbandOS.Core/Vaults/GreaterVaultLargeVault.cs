// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Vaults;

[Serializable]
internal class GreaterVaultLargeVault : Vault
{
    private GreaterVaultLargeVault(Game game) : base(game) { } // This object is a singleton.
    public override string Name => "Greater vault (large)";
    public override int Category => 8;
    public override int Height => 18;
    public override int Rating => 35;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX%%X,#,#,#,#,#,#,#,#*@@*#,#,#,#,#,#,#,#,X%%X+XXXXXXXXXXXXXXXX##XXXXXXXXXXXXXXXX+X%%X.,..,.X&.&.,*XX******XX*,.&.&X.,...,#%%X..,.^^X....,XX***@@***XX,....X^^..,.#%%XXXXXX+X^&.&XX***@##@***XX&.&^X+XXXXXX%%X,.&.^^X+XXXX***@#XX#@***XXXX+X^^.,..X%%X..,&,.X^^^@X**@#X88X#@**#@^^^X.,..&,X%%X.,....X^^^@#**@#X88X#@**X@^^^X.&.,..X%%X...,^^X+XXXX***@#XX#@***XXXX+X^^..,.X%%XXXXXX+X^&.&XX***@##@***XX&.&^X+XXXXXX%%#.,..^^X.....XX***@@***XX,....X^^.,..X%%#...,..X&.&.,*XX******XX*,.&.&X..,..,X%%X+XXXXXXXXXXXXXXXX##XXXXXXXXXXXXXXXX+X%%X,#,#,#,#,#,#,#,#*@@*#,#,#,#,#,#,#,#,X%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 40;
}
