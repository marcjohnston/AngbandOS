namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class HalfOgreRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string Strength => "3";
    public override string Charisma => "-3";
    public override string Constitution => "3";
    public override string Wisdom => "-1";
    public override string Intelligence => "-1";
    public override string Dexterity => "-1";
    public override int? Value => 2250;
    public override string? Infravision => "3";
}
