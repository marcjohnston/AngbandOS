namespace AngbandOS.Core.Vaults;

[Serializable]
internal class RockHardVault : Vault
{
    private RockHardVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '#';
    public override string Name => "Rock-Hard";
    public override int Category => 7;
    public override int Height => 11;
    public override int Rating => 10;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%..................%%.#^############^#.%%.#^#,,,,,,,,,,#^#.%%.#^##,,,,,,,,##^#.%%.##^##^^^^^^##^##.%%.###*##&&&&##*###.%%.#9##^##@@##^##9#.%%.#####^####^#####.%%..................%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 20;
}
