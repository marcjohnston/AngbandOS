namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class HalfElfRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string Strength => "-1";
    public override string Charisma => "1";
    public override string Constitution => "-1";
    public override string Wisdom => "1";
    public override string Intelligence => "1";
    public override string Dexterity => "1";
    public override int? Value => 1650;
    public override string? Infravision => "2";
    public override string? DisarmTraps => "2";
    public override string? UseDevice => "3";
    public override string? SavingThrow => "3";
}
