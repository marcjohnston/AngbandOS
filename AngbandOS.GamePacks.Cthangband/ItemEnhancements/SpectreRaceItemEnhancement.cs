namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class SpectreRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string Strength => "-5";
    public override string Charisma => "-6";
    public override string Constitution => "-3";
    public override string Wisdom => "4";
    public override string Intelligence => "4";
    public override string Dexterity => "2";
    public override int? Value => -300;
    public override string? Infravision => "5";
}
