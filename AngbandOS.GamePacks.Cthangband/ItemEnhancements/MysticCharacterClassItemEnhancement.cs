
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MysticCharacterClassItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string Strength => "2";
    public override string Charisma => "0";
    public override string Constitution => "2";
    public override string Wisdom => "2";
    public override string Intelligence => "-1";
    public override string Dexterity => "2";
    public override int? Value => 8400;
}
