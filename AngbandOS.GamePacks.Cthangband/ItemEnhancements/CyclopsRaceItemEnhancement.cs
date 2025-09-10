namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class CyclopsRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string Strength => "4";
    public override string Charisma => "-6";
    public override string Constitution => "4";
    public override string Wisdom => "-3";
    public override string Intelligence => "-3";
    public override string Dexterity => "-3";
    public override int? Value => -3900;
    public override string? Infravision => "1";
    public override string? DisarmTraps => "-4";
    public override string? UseDevice => "-5";
}
