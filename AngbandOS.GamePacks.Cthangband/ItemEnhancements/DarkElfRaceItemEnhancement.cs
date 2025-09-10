namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class DarkElfRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string Strength => "-1";
    public override string Charisma => "1";
    public override string Constitution => "-2";
    public override string Wisdom => "2";
    public override string Intelligence => "3";
    public override string Dexterity => "2";
    public override int? Value => 5250;
    public override string? Infravision => "5";
    public override string? DisarmTraps => "5";
    public override string? UseDevice => "15";
    public override string? SavingThrow => "20";
}
