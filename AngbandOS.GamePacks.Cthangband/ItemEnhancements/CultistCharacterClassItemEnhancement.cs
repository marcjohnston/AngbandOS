
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CultistCharacterClassItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string Strength => "-5";
    public override string Charisma => "-2";
    public override string Constitution => "-2";
    public override string Wisdom => "0";
    public override string Intelligence => "4";
    public override string Dexterity => "1";
    public override int? Value => -3300;
}
