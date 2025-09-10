
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WarriorMageCharacterClassItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string Strength => "2";
    public override string Charisma => "1";
    public override string Constitution => "0";
    public override string Wisdom => "0";
    public override string Intelligence => "2";
    public override string Dexterity => "1";
    public override int? Value => 6450;
    public override string? DisarmTraps => "30";
    public override string? UseDevice => "30";
    public override string? SavingThrow => "28";
}
