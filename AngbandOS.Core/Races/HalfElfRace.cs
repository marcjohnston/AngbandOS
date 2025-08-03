// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Races;

[Serializable]
internal class HalfElfRace : Race
{
    private HalfElfRace(Game game) : base(game) { }
    public override string Title => "Half Elf";
    public override int BaseDisarmBonus => 2;
    public override int BaseDeviceBonus => 3;
    public override int BaseSaveBonus => 3;
    public override int BaseStealthBonus => 1;
    public override int BaseSearchBonus => 6;
    public override int BaseSearchFrequency => 11;
    public override int BaseMeleeAttackBonus => -1;
    public override int BaseRangedAttackBonus => 5;
    public override int HitDieBonus => 9;
    public override int ExperienceFactor => 110;
    public override int BaseAge => 24;
    public override int AgeRange => 16;
    public override int Infravision => 2;
    public override uint Choice => 0xFFFF;
    public override string Description => "Half-Elves inherit better ability scores and skills from\ntheir elven parent, but none of that parent's special\nabilities. However, a half elf will advance in level more\nquickly than a full elf.";

    /// <summary>
    /// Half-Elf 4->1->2->3->50->51->52->53->End
    /// </summary>
    public override int Chart => 4;

    public override void UpdateRacialAbilities(int level, EffectivePropertySet itemCharacteristics)
    {
        itemCharacteristics.ResLight = true;
        itemCharacteristics.SeeInvis = true;
    }
    protected override string GenerateNameSyllableSetName => nameof(ElvishSyllableSet);
    public override void CalcBonuses()
    {
        Game.HasLightResistance = true;
    }
}