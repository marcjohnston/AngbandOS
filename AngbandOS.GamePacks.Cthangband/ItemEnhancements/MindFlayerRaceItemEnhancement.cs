namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class MindFlayerRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string Strength => "-3";
    public override string Charisma => "-5";
    public override string Constitution => "-2";
    public override string Wisdom => "4";
    public override string Intelligence => "4";
    public override string Dexterity => "0";
    public override int? Value => 1350;
    public override string? Infravision => "4";
    public override string? DisarmTraps => "10";
    public override string? UseDevice => "25";
}
