namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class GnomeRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string Strength => "-1";
    public override string Charisma => "-2";
    public override string Constitution => "1";
    public override string Wisdom => "0";
    public override string Intelligence => "2";
    public override string Dexterity => "2";
    public override int? Value => 3900;
    public override string? Infravision => "4";
    public override string? DisarmTraps => "10";
    public override string? UseDevice => "12";
    public override string? SavingThrow => "12";
    public override string? Stealth => "3";
    public override string? Search => "6";
}
