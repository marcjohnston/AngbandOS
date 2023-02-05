namespace AngbandOS.Core.VaultTypes;

[Serializable]
internal class GreaterVaultchambersVault : Vault
{
    public override char Character => '#';
    public override string Name => "Greater vault (chambers)";
    public override int Category => 8;
    public override int Height => 15;
    public override int Rating => 25;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%&+.^..^..^..^..^..^..^..^..^..^..^..+&%%+XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX+%%.X.&.^,X&^&^X****+^*^@^X.*.&..X..*.,X.%%^X.,.&^+^&^@X^^^^X@^*^*X....*^+.^...X^%%.X*..,.XXX+XXXX+XXXX+XXX.&.^..X..&,.X.%%^X..^.*X*..^&&@@*X,,,,,XXXX+XXX,....X^%%.XX+XXXXXXXXXXXXXX,*8*,X,,,,,,XXX+XXX.%%^X*&X.&,*.X,*&^*^X,,,,,X,,,,,,X....,X^%%.X&,+....*+,*&^*^XXXXXXXXXX+XXX.,...+.%%^X.,X.*.&.X,*&^*^+.,.&.^*.&^&^X.....X^%%.X^*X.,..,X,*&^*^X*.^*.,..&&&^X,..,.X.%%+XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX+%%&+..^..^..^..^..^..^..^..^..^..^..^.+&%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 40;
}
