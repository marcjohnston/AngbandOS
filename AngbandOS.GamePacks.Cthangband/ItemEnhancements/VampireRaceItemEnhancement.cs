namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class VampireRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string Strength => "3";
    public override string Charisma => "2";
    public override string Constitution => "1";
    public override string Wisdom => "-1";
    public override string Intelligence => "3";
    public override string Dexterity => "-1";
    public override int? Value => 6900;
    public override string? Infravision => "5";
    public override string? DisarmTraps => "4";
    public override string? UseDevice => "10";
    public override string? SavingThrow => "10";
    public override string? Stealth => "4";
    public override string? Search => "1";
}
