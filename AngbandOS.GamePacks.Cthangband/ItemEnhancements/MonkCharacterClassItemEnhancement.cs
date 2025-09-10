
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MonkCharacterClassItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string Strength => "2";
    public override string Charisma => "1";
    public override string Constitution => "2";
    public override string Wisdom => "1";
    public override string Intelligence => "-1";
    public override string Dexterity => "3";
    public override int? Value => 8850;
    public override string? DisarmTraps => "45";
    public override string? UseDevice => "32";
    public override string? SavingThrow => "28";
}
