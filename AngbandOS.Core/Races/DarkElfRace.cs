// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Races;

[Serializable]
internal class DarkElfRace : Race
{
    private DarkElfRace(Game game) : base(game) { }
    protected override string EnhancementBindingKey => nameof(DarkElfRaceItemEnhancement);
    public override string Title => "Dark Elf";
    public override int UseDevice => 15;
    public override int SavingThrow => 20;
    public override int Stealth => 3;
    public override int Search => 8;
    public override int BaseSearchFrequency => 12;
    public override int MeleeToHit => -5;
    public override int RangedToHit => 10;
    public override int HitDieBonus => 9;
    public override int ExperienceFactor => 150;
    public override int BaseAge => 75;
    public override int AgeRange => 75;
    public override int Infravision => 5;
    public override uint Choice => 0xBFDF;
    public override string Description => "Dark elves are underground elves who have a kinship with\nfungi the way that surface elves have a kinship with trees.\nThe innately magical nature of dark elves lets them learn\nto fire magical missiles at their opponents (at lvl 2).\nThey also resist dark-based attacks and can learn to see\ninvisible creatures (at lvl 20).";

    /// <summary>
    /// Dark-Elf 68->70->71->72->73->End
    /// </summary>
    public override int Chart => 69;

    public override string RacialPowersDescription(int lvl) => lvl < 2 ? "magic missile      (racial, unusable until level 2)" : "magic missile      (racial, cost 2, INT based)";
    protected override string? RacialPowerScriptBindingKey => nameof(UseRacialPowerScript);
    public override bool HasRacialPowers => true;
    public override void UpdateRacialAbilities(int level, EffectiveAttributeSet itemCharacteristics)
    {
        itemCharacteristics.Get<OrEffectiveAttributeValue>(nameof(ResDarkAttribute)).Set();
    }
    protected override string GenerateNameSyllableSetName => nameof(ElvishSyllableSet);

    public override string[]? SelfKnowledge(int level)
    {
        if (level > 1)
        {
            return new string[] { $"You can cast a Magic Missile, dam {3 + ((level - 1) / 5)} (cost 2)." };
        }
        return null;
    }
    public override void CalcBonuses()
    {
        Game.HasDarkResistance = true;
        if (Game.ExperienceLevel.IntValue > 19)
        {
            Game.HasSeeInvisibility = true;
        }
    }
}
