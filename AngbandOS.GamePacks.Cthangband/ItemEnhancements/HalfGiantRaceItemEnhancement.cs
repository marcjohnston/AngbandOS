namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class HalfGiantRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string Strength => "4";
    public override string Charisma => "-3";
    public override string Constitution => "3";
    public override string Wisdom => "-2";
    public override string Intelligence => "-2";
    public override string Dexterity => "-2";
    public override int? Value => -150;
    public override string? Infravision => "3";
    public override string? DisarmTraps => "-6";
    public override string? UseDevice => "-8";
}
