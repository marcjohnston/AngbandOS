// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Races;

internal class YeekRace : Race
{
    private YeekRace(Game game) : base(game) { }
    protected override (int, string)[]? MinimumExperienceLevelAndEnhancementBindingTuples => new (int, string)[] { 
        (1, nameof(YeekRaceItemEnhancement)),
        (20, nameof(YeekRaceLevel20ItemEnhancement))
    };
    public override string Title => "Yeek";
    public override int BasePerception => 15;
    public override int MeleeToHit => -5;
    public override int RangedToHit => -5;
    public override int HitDieBonus => 7;
    public override int ExperienceFactor => 100;
    public override int BaseAge => 14;
    public override int AgeRange => 3;
    public override int Infravision => 2;
    public override uint Choice => 0xDE0F;
    public override string Description => "Yeeks are long-eared furry creatures that look vaguely\nlike humanoid rabbits. Although physically weak, they make\npassable spell casters. They are resistant to acid, and can\nlearn to scream to terrify their foes (at lvl 15) and\nbecome completely immune to acid (at lvl 20).";

    /// <summary>
    /// Yeek 78->79->80->81->135->136->137->End
    /// </summary>
    public override int Chart => 78;

    public override string RacialPowersDescription(int lvl) => lvl < 15 ? "scare monster      (racial, unusable until level 15)" : "scare monster      (racial, cost 15, WIS based)";
    protected override string? RacialPowerScriptBindingKey => nameof(UseRacialPowerScript);
    protected override string GenerateNameSyllableSetBindingKey => nameof(YeekishSyllableSet);
    public override string[]? SelfKnowledge(int level)
    {
        if (level > 14)
        {
            return new string[] { "You can make a terrifying scream (cost 15)." };
        }
        return null;
    }
}
