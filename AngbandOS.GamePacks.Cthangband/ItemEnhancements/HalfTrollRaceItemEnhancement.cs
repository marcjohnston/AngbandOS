namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class HalfTrollRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string Strength => "4";
    public override string Charisma => "-6";
    public override string Constitution => "3";
    public override string Wisdom => "2";
    public override string Intelligence => "-4";
    public override string Dexterity => "-4";
    public override int? Value => -1500;
    public override string? Infravision => "3";
    public override string? DisarmTraps => "-5";
}
