
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DruidCharacterClassItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string Strength => "-1";
    public override string Charisma => "3";
    public override string Constitution => "0";
    public override string Wisdom => "4";
    public override string Intelligence => "-3";
    public override string Dexterity => "-2";
    public override int? Value => -1050;
    public override string? DisarmTraps => "30";
}
