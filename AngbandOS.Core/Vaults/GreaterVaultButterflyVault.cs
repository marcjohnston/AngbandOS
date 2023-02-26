namespace AngbandOS.Core.Vaults;

[Serializable]
internal class GreaterVaultButterflyVault : Vault
{
    private GreaterVaultButterflyVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '#';
    public override string Name => "Greater vault (butterfly)";
    public override int Category => 8;
    public override int Height => 18;
    public override int Rating => 25;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX%%X*9..&XX***++^^^^^^^^^^^^++***XX&..*9X%%X9..&XX,,,,,XX^^^^^^^^^^XX,,,,,#X&..*X%%X..&#X.....,.XX^^^^^^^^XX..&....XX&..X%%X.&XX..,.&....XX^^^^^^XX..,...&..XX&.X%%X&XX..*...&.^..XX^^^^XX..*....,..,XX&X%%XXXX+XXXXXXXXXXXXX++XXXXXXXXXXXXX+XXXX%%+....,.,.X&&&&***+99+***&&&&X,.,.,...+%%+...,.,.,X&&&&***+99+***&&&&X.,.,....+%%XXXX+XXXXXXXXXXXXX++XXXXXXXXXXXXX+XXXX%%X&XX..*....&...XX^^^^XX...*...&,..#X&X%%X.&XX..&.^....XX^^^^^^XX....&....XX&.X%%X..&XX....&..XX^^^^^^^^XX..,..*.XX&..X%%X*..&#X,,,,,XX^^^^^^^^^^XX,,,,,XX&..9X%%X9*..&XX***++^^^^^^^^^^^^++***XX&..*9X%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 40;
}
