namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class ZombieRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string Strength => "2";
    public override string Charisma => "-5";
    public override string Constitution => "4";
    public override string Wisdom => "-6";
    public override string Intelligence => "-6";
    public override string Dexterity => "1";
    public override int? Value => -8250;
    public override string? Infravision => "2";
    public override string? DisarmTraps => "-5";
    public override string? UseDevice => "-5";
    public override string? SavingThrow => "8";
    public override string? Stealth => "-1";
    public override string? Search => "-1";
}
