
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WarriorCharacterClassItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string Strength => "5";
    public override string Charisma => "-1";
    public override string Constitution => "2";
    public override string Wisdom => "-2";
    public override string Intelligence => "-2";
    public override string Dexterity => "2";
    public override int? Value => 5550;
    public override string? DisarmTraps => "25";
    public override string? UseDevice => "18";
    public override string? SavingThrow => "18";
}
