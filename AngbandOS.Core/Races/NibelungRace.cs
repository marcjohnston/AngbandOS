// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Races;

[Serializable]
internal class NibelungRace : Race
{
    private NibelungRace(Game game) : base(game) { }
    public override string Title => "Nibelung";
    public override int BaseDisarmBonus => 3;
    public override int BaseDeviceBonus => 5;
    public override int BaseSaveBonus => 10;
    public override int BaseStealthBonus => 1;
    public override int BaseSearchBonus => 5;
    public override int BaseSearchFrequency => 10;
    public override int BaseMeleeAttackBonus => 9;
    public override int BaseRangedAttackBonus => 0;
    public override int HitDieBonus => 11;
    public override int ExperienceFactor => 135;
    public override int BaseAge => 40;
    public override int AgeRange => 12;
    public override int Infravision => 5;
    public override uint Choice => 0xDC0F;
    public override string Description => "Nibelungen are also known as dark dwarves and are famous\nas the makers of (often cursed) magical items. They can\nresist darkness and protect the items they are carrying\nfrom disenchantment. They can also learn to detect traps,\nstairs, and secret doors (at lvl 5).";

    /// <summary>
    /// Nibelung 87->88->18->57->58->59->60->61->End
    /// </summary>
    public override int Chart => 87;

    public override string RacialPowersDescription(int lvl) => lvl < 5 ? "detect doors+traps (racial, WIS based, unusable until level 5)" : "detect doors+traps (racial, cost 5, WIS based)";
    protected override string? RacialPowerScriptBindingKey => nameof(UseRacialPowerScript);
    public override bool HasRacialPowers => true;

    public override void UpdateRacialAbilities(int level, RwItemPropertySet itemCharacteristics)
    {
        itemCharacteristics.ResDisen = true;
        itemCharacteristics.ResDark = true;
    }
    protected override string GenerateNameSyllableSetName => nameof(DwarvenSyllableSet);

    public override string[]? SelfKnowledge(int level)
    {
        if (level > 4)
        {
            return new string[] { "You can find traps, doors and stairs (cost 5)." };
        }
        return null;
    }

    public override void CalcBonuses()
    {
        Game.HasDisenchantResistance = true;
        Game.HasDarkResistance = true;
    }
}