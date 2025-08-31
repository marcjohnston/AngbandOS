
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class FanaticCharacterClassItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string Strength => "2";
    public override string Charisma => "-2";
    public override string Constitution => "2";
    public override string Wisdom => "0";
    public override string Intelligence => "1";
    public override string Dexterity => "1";
    public override int? Value => 6300;
    public override string? DisarmTraps => "20";
}
