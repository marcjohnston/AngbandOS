// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Races;

[Serializable]
internal class MiriNigriRace : Race
{
    private MiriNigriRace(Game game) : base(game) { }
    protected override string EnhancementBindingKey => nameof(MiriNigriRaceItemEnhancement);
    public override string Title => "Miri Nigri";
    public override int BaseDisarmBonus => -5;
    public override int BaseDeviceBonus => -2;
    public override int BaseSaveBonus => -1;
    public override int BaseStealthBonus => -1;
    public override int BaseSearchBonus => -1;
    public override int BaseSearchFrequency => 5;
    public override int BaseMeleeAttackBonus => 12;
    public override int BaseRangedAttackBonus => 5;
    public override int HitDieBonus => 11;
    public override int ExperienceFactor => 140;
    public override int BaseAge => 14;
    public override int AgeRange => 6;
    public override uint Choice => 0xDFCF;
    public override string Description => "Miri-Nigri are squat, toad-like chaos beasts. Their\nclose ties to chaos render them resistant to sound and\nimmune to confusion. However, their chaotic nature also\nmakes them prone to random mutation. Also, the outer gods\npay special attention to miri-nigri servants and they\nare more likely to interfere with them for good or ill.";

    /// <summary>
    /// Miri-Nigri 129->130->131->132->133->End
    /// </summary>
    public override int Chart => 129;

    public override void UpdateRacialAbilities(int level, EffectiveAttributeSet itemCharacteristics)
    {
        itemCharacteristics.SetBoolAttributeValue(AttributeEnum.ResSound, true);
        itemCharacteristics.SetBoolAttributeValue(AttributeEnum.ResConf, true);
    }
    protected override string GenerateNameSyllableSetName => nameof(CthuloidSyllableSet);
    public override void CalcBonuses()
    {
        Game.HasConfusionResistance = true;
        Game.HasSoundResistance = true;
    }

    public override bool AutomaticallyGainsFirstLevelMutationAtBirth => true;
}