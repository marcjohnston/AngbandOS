
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ChannelerCharacterClassItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string Strength => "-1";
    public override string Charisma => "3";
    public override string Constitution => "-1";
    public override string Wisdom => "2";
    public override string Intelligence => "0";
    public override string Dexterity => "-1";
    public override int? Value => 150;
    public override string? DisarmTraps => "40";
}
