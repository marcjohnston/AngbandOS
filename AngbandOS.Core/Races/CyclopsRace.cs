// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Races;

[Serializable]
internal class CyclopsRace : Race
{
    private CyclopsRace(Game game) : base(game) { }
    protected override string EnhancementBindingKey => nameof(CyclopsRaceItemEnhancement);
    public override string Title => "Cyclops";
    public override int UseDevice => -5;
    public override int BaseSaveBonus => -5;
    public override int BaseStealthBonus => -2;
    public override int BaseSearchBonus => -2;
    public override int BaseSearchFrequency => 5;
    public override int MeleeToHit => 20;
    public override int BaseRangedAttackBonus => 12;
    public override int HitDieBonus => 13;
    public override int ExperienceFactor => 130;
    public override int BaseAge => 50;
    public override int AgeRange => 24;
    public override int Infravision => 1;
    public override uint Choice => 0x0005;
    public override string Description => "Cyclopes are one eyed giants, often seen as freaks by the\nother races. They can learn to throw boulders (at lvl 20)\nand although they have weak eyesight their hearing is very\nkeen and hard to damage, so they are resistant to sound\nbased attacks.";

    /// <summary>
    /// Cyclops 77->109->110->111->112->End
    /// </summary>
    public override int Chart => 77;

    public override string RacialPowersDescription(int lvl) => lvl < 20 ? "throw boulder      (racial, unusable until level 20)" : "throw boulder      (racial, cost 15, dam 3*lvl, STR based)";
    protected override string? RacialPowerScriptBindingKey => nameof(UseRacialPowerScript);
    public override bool HasRacialPowers => true;

    public override void UpdateRacialAbilities(int level, EffectiveAttributeSet itemCharacteristics)
    {
        itemCharacteristics.SetBoolAttributeValue(AttributeEnum.ResSound, true);
    }

    protected override string GenerateNameSyllableSetName => nameof(DwarvenSyllableSet);

    public override string[]? SelfKnowledge(int level)
    {
        if (level > 19)
        {
            return new string[] { $"You can throw a boulder, dam. {3 * level} (cost 15)." };
        }
        return null;
    }
    public override void CalcBonuses()
    {
        Game.HasSoundResistance = true;
    }
}
