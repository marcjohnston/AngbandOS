namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class KoboldRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string Strength => "1";
    public override string Charisma => "-4";
    public override string Constitution => "0";
    public override string Wisdom => "0";
    public override string Intelligence => "-1";
    public override string Dexterity => "1";
    public override int? Value => -600;
    public override string? Infravision => "3";
    public override string? DisarmTraps => "-2";
    public override string? UseDevice => "-3";
}
