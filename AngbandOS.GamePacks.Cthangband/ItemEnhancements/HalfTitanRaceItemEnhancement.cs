namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class HalfTitanRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string Strength => "5";
    public override string Charisma => "1";
    public override string Constitution => "3";
    public override string Wisdom => "1";
    public override string Intelligence => "1";
    public override string Dexterity => "-2";
    public override int? Value => 10050;
    public override string? DisarmTraps => "-5";
    public override string? UseDevice => "5";
}
