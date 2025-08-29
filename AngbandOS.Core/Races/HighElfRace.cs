// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Races;

[Serializable]
internal class HighElfRace : Race
{
    private HighElfRace(Game game) : base(game) { }
    protected override string EnhancementBindingKey => nameof(HighElfRaceItemEnhancement);
    public override string Title => "High Elf";
    public override int BaseDisarmBonus => 4;
    public override int BaseDeviceBonus => 20;
    public override int BaseSaveBonus => 20;
    public override int BaseStealthBonus => 4;
    public override int BaseSearchBonus => 3;
    public override int BaseSearchFrequency => 14;
    public override int BaseMeleeAttackBonus => 10;
    public override int BaseRangedAttackBonus => 25;
    public override int HitDieBonus => 10;
    public override int ExperienceFactor => 200;
    public override int BaseAge => 100;
    public override int AgeRange => 30;
    public override uint Choice => 0xBF5F;
    public override string Description => "High-Elves are the leaders of the elven race. They are\nmore magical than their lesser cousins, but retain their\naffinity with nature. High-elves resist light based attacks\nand their acute senses are able to see invisible creatures.";

    /// <summary>
    /// High-Elf 7->8->9->54->55->56->End 
    /// </summary>
    public override int Chart => 7;
    public override void UpdateRacialAbilities(int level, EffectiveAttributeSet itemCharacteristics)
    {
        if (level > 19)
        {
            itemCharacteristics.SetBoolAttributeValue(AttributeEnum.SeeInvis, true);
        }
    }
    protected override string GenerateNameSyllableSetName => nameof(ElvishSyllableSet);
    public override void CalcBonuses()
    {
        Game.HasSeeInvisibility = true;
    }
}