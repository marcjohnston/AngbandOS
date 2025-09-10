namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class SpriteRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string Strength => "-4";
    public override string Charisma => "2";
    public override string Constitution => "-2";
    public override string Wisdom => "3";
    public override string Intelligence => "3";
    public override string Dexterity => "3";
    public override int? Value => 4500;
    public override string? Infravision => "4";
    public override string? DisarmTraps => "10";
    public override string? UseDevice => "10";
}
