namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class NibelungRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string Strength => "1";
    public override string Charisma => "-4";
    public override string Constitution => "2";
    public override string Wisdom => "2";
    public override string Intelligence => "-1";
    public override string Dexterity => "0";
    public override int? Value => 3000;
    public override string? Infravision => "5";
    public override string? DisarmTraps => "3";
    public override string? UseDevice => "5";
    public override string? SavingThrow => "10";
}
