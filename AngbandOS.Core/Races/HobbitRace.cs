// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Races;

[Serializable]
internal class HobbitRace : Race
{
    private HobbitRace(Game game) : base(game) { }
    protected override string EnhancementBindingKey => nameof(HobbitRaceItemEnhancement);
    public override string Title => "Hobbit";
    public override int UseDevice => 18;
    public override int SavingThrow => 18;
    public override int Stealth => 5;
    public override int Search => 12;
    public override int BaseSearchFrequency => 15;
    public override int MeleeToHit => -10;
    public override int RangedToHit => 20;
    public override int HitDieBonus => 7;
    public override int ExperienceFactor => 110;
    public override int BaseAge => 21;
    public override int AgeRange => 12;
    public override int Infravision => 4;
    public override uint Choice => 0xBC0B;
    public override string Description => "Hobbits are small and surprisingly dextrous given their\npropensity for plumpness. They make excellent burglars\nand are adept at spell casting too. Hobbits can't have\ntheir dexterity reduced, and they can learn to put together\nnourishing meals from the barest scraps (at lvl 15).";

    /// <summary>
    /// Hobbit 10->11->3->50->51->52->53->End
    /// </summary>
    public override int Chart => 10;

    public override string RacialPowersDescription(int lvl) => lvl < 15 ? "create food        (racial, unusable until level 15)" : "create food        (racial, cost 10, INT based)";
    protected override string? RacialPowerScriptBindingKey => nameof(UseRacialPowerScript);
    public override bool HasRacialPowers => true;

    public override void UpdateRacialAbilities(int level, EffectiveAttributeSet itemCharacteristics)
    {
        itemCharacteristics.Get<OrEffectiveAttributeValue>(nameof(SustDexAttribute)).Set();
    }
    protected override string GenerateNameSyllableSetName => nameof(HobbitSyllableSet);

    public override string[]? SelfKnowledge(int level)
    {
        if (level > 14)
        {
            return new string[] { "You can produce food (cost 10)." };
        }
        return null;
    }

    public override void CalcBonuses()
    {
        Game.HasSustainDexterity = true;
    }
}
