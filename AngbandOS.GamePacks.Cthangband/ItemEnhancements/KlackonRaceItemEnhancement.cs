namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class KlackonRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string Strength => "2";
    public override string Charisma => "-2";
    public override string Constitution => "2";
    public override string Wisdom => "-1";
    public override string Intelligence => "-1";
    public override string Dexterity => "1";
    public override int? Value => 2700;
    public override string? Infravision => "2";
    public override string? DisarmTraps => "10";
    public override string? UseDevice => "5";
    public override string? SavingThrow => "5";
}
