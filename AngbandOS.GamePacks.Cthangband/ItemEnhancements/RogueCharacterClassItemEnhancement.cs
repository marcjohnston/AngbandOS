
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RogueCharacterClassItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string Strength => "2";
    public override string Charisma => "-1";
    public override string Constitution => "1";
    public override string Wisdom => "-2";
    public override string Intelligence => "1";
    public override string Dexterity => "3";
    public override int? Value => 5550;
    public override string? DisarmTraps => "45";
}
