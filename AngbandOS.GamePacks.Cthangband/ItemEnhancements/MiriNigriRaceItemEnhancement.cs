namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class MiriNigriRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string Strength => "2";
    public override string Charisma => "-4";
    public override string Constitution => "2";
    public override string Wisdom => "-1";
    public override string Intelligence => "-2";
    public override string Dexterity => "-1";
    public override int? Value => -1800;
    public override string? DisarmTraps => "-5";
    public override string? UseDevice => "-2";
    public override string? SavingThrow => "-1";
    public override string? Stealth => "-1";
    public override string? Search => "-1";
}
