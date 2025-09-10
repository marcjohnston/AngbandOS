
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PaladinCharacterClassItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string Strength => "3";
    public override string Charisma => "2";
    public override string Constitution => "2";
    public override string Wisdom => "1";
    public override string Intelligence => "-3";
    public override string Dexterity => "0";
    public override int? Value => 4500;
    public override string? DisarmTraps => "20";
    public override string? UseDevice => "24";
    public override string? SavingThrow => "26";
}
