namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class TchoTchoRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string Strength => "3";
    public override string Charisma => "-2";
    public override string Constitution => "2";
    public override string Wisdom => "-1";
    public override string Intelligence => "-2";
    public override string Dexterity => "1";
    public override int? Value => 2700;
    public override string? DisarmTraps => "-2";
    public override string? UseDevice => "-10";
    public override string? SavingThrow => "2";
    public override string? Stealth => "-1";
    public override string? Search => "1";
}
