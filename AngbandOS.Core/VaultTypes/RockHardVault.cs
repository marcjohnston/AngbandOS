namespace AngbandOS.Core.VaultTypes;

[Serializable]
internal class RockHardVault : Vault
{
    public override char Character => '#';
    public override string Name => "Rock-Hard";
    public override int Category => 7;
    public override int Height => 11;
    public override int Rating => 10;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%..................%%.#^############^#.%%.#^#,,,,,,,,,,#^#.%%.#^##,,,,,,,,##^#.%%.##^##^^^^^^##^##.%%.###*##&&&&##*###.%%.#9##^##@@##^##9#.%%.#####^####^#####.%%..................%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 20;
}
