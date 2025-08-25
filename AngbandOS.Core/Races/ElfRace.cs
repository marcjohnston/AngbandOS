// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Races;

[Serializable]
internal class ElfRace : Race
{
    private ElfRace(Game game) : base(game) { }
    protected override string EnhancementBindingKey => nameof(ElfRaceItemEnhancement);
    public override string Title => "Elf";
    public override int BaseDisarmBonus => 5;
    public override int BaseDeviceBonus => 6;
    public override int BaseSaveBonus => 6;
    public override int BaseStealthBonus => 2;
    public override int BaseSearchBonus => 8;
    public override int BaseSearchFrequency => 12;
    public override int BaseMeleeAttackBonus => -5;
    public override int BaseRangedAttackBonus => 15;
    public override int HitDieBonus => 8;
    public override int ExperienceFactor => 120;
    public override int BaseAge => 75;
    public override int AgeRange => 75;
    public override int Infravision => 3;
    public override uint Choice => 0xFF5F;
    public override string Description => "Elves are creatures of the woods, and cultivate a symbiotic\nrelationship with trees. While not the sturdiest of races,\nthey are dextrous and have excellent mental faculties.\nBecause they are partially photosynthetic, elves are able\nto resist light based attacks.";

    /// <summary>
    /// Elf 7->8->9->54->55->56->End 
    /// </summary>
    public override int Chart => 7;

    public override void UpdateRacialAbilities(int level, EffectiveAttributeSet itemCharacteristics)
    {
        itemCharacteristics.SetBoolValue(AttributeEnum.ResLight, true);
    }
    protected override string GenerateNameSyllableSetName => nameof(ElvishSyllableSet);

    public override void CalcBonuses()
    {
        Game.HasLightResistance = true;
    }
}