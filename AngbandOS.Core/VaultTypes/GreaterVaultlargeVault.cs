namespace AngbandOS.Core.VaultTypes;

[Serializable]
internal class GreaterVaultlargeVault : Vault
{
    public override char Character => '#';
    public override string Name => "Greater vault (large)";
    public override int Category => 8;
    public override int Height => 18;
    public override int Rating => 35;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX%%X,#,#,#,#,#,#,#,#*@@*#,#,#,#,#,#,#,#,X%%X+XXXXXXXXXXXXXXXX##XXXXXXXXXXXXXXXX+X%%X.,..,.X&.&.,*XX******XX*,.&.&X.,...,#%%X..,.^^X....,XX***@@***XX,....X^^..,.#%%XXXXXX+X^&.&XX***@##@***XX&.&^X+XXXXXX%%X,.&.^^X+XXXX***@#XX#@***XXXX+X^^.,..X%%X..,&,.X^^^@X**@#X88X#@**#@^^^X.,..&,X%%X.,....X^^^@#**@#X88X#@**X@^^^X.&.,..X%%X...,^^X+XXXX***@#XX#@***XXXX+X^^..,.X%%XXXXXX+X^&.&XX***@##@***XX&.&^X+XXXXXX%%#.,..^^X.....XX***@@***XX,....X^^.,..X%%#...,..X&.&.,*XX******XX*,.&.&X..,..,X%%X+XXXXXXXXXXXXXXXX##XXXXXXXXXXXXXXXX+X%%X,#,#,#,#,#,#,#,#*@@*#,#,#,#,#,#,#,#,X%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 40;
}
