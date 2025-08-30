namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class GolemRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string Strength => "4";
    public override string Charisma => "-4";
    public override string Constitution => "4";
    public override string Wisdom => "-5";
    public override string Intelligence => "-5";
    public override string Dexterity => "0";
    public override int? Value => -4200;
    public override string? Infravision => "4";
}
