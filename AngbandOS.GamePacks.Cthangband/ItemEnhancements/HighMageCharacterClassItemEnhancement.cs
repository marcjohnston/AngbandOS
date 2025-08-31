
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HighMageCharacterClassItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string Strength => "-5";
    public override string Charisma => "1";
    public override string Constitution => "-2";
    public override string Wisdom => "0";
    public override string Intelligence => "4";
    public override string Dexterity => "0";
    public override int? Value => -3150;
    public override string? DisarmTraps => "30";
}
