// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Vaults;

[Serializable]
internal class GreaterVaultChambersVault : Vault
{
    private GreaterVaultChambersVault(Game game) : base(game) { } // This object is a singleton.
    public override string Name => "Greater vault (chambers)";
    public override int Category => 8;
    public override int Height => 15;
    public override int Rating => 25;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%&+.^..^..^..^..^..^..^..^..^..^..^..+&%%+XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX+%%.X.&.^,X&^&^X****+^*^@^X.*.&..X..*.,X.%%^X.,.&^+^&^@X^^^^X@^*^*X....*^+.^...X^%%.X*..,.XXX+XXXX+XXXX+XXX.&.^..X..&,.X.%%^X..^.*X*..^&&@@*X,,,,,XXXX+XXX,....X^%%.XX+XXXXXXXXXXXXXX,*8*,X,,,,,,XXX+XXX.%%^X*&X.&,*.X,*&^*^X,,,,,X,,,,,,X....,X^%%.X&,+....*+,*&^*^XXXXXXXXXX+XXX.,...+.%%^X.,X.*.&.X,*&^*^+.,.&.^*.&^&^X.....X^%%.X^*X.,..,X,*&^*^X*.^*.,..&&&^X,..,.X.%%+XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX+%%&+..^..^..^..^..^..^..^..^..^..^..^.+&%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 40;
}
