namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class DwarfRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string Strength => "2";
    public override string Charisma => "-3";
    public override string Constitution => "2";
    public override string Wisdom => "2";
    public override string Intelligence => "-2";
    public override string Dexterity => "-2";
    public override int? Value => 1050;
    public override string? Infravision => "5";
    public override string? DisarmTraps => "2";
    public override string? UseDevice => "9";
    public override string? SavingThrow => "10";
    public override string? Stealth => "-1";
    public override string? Search => "7";
}
