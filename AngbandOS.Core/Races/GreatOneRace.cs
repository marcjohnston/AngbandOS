// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Races;

[Serializable]
internal class GreatOneRace : Race
{
    private GreatOneRace(Game game) : base(game) { }
    protected override string EnhancementBindingKey => nameof(GreatOneRaceItemEnhancement);
    public override string Title => "Great One";
    public override int UseDevice => 5;
    public override int SavingThrow => 5;
    public override int Stealth => 2;
    public override int Search => 3;
    public override int BaseSearchFrequency => 13;
    public override int MeleeToHit => 15;
    public override int RangedToHit => 10;
    public override int HitDieBonus => 10;
    public override int ExperienceFactor => 225;
    public override int BaseAge => 50;
    public override int AgeRange => 50;
    public override int Infravision => 0;
    public override uint Choice => 0xFFFF;
    public override string Description => "Great-Ones are the offspring of the petty gods that rule\nDreamlands. As such they are somewhat more than human.\nTheir constitution cannot be reduced, and they heal\nquickly. They can also learn to travel through dreams\n(at lvl 30) and restore their health (at lvl 40).";

    /// <summary>
    /// Great One 67->68->50->51->52->53->End 
    /// </summary>
    public override int Chart => 67;

    public override string RacialPowersDescription(int lvl) => "dream powers    (unusable until level 30/40)";
    protected override string? RacialPowerScriptBindingKey => nameof(GreatOneRacialPowerScript);
    public override bool HasRacialPowers => true;

    public override void UpdateRacialAbilities(int level, EffectiveAttributeSet itemCharacteristics)
    {
        itemCharacteristics.Get<OrEffectiveAttributeValue>(nameof(SustConAttribute)).Set();
        itemCharacteristics.Get<OrEffectiveAttributeValue>(nameof(RegenAttribute)).Set();
    }
    protected override string GenerateNameSyllableSetName => nameof(HumanSyllableSet);

    public override string[]? SelfKnowledge(int level)
    {
        List<string> values = new List<string>();
        if (level > 29)
        {
            values.Add("You can dream travel (cost 50).");
        }
        if (level > 39)
        {
            values.Add("You can dream a better self (cost 75).");
        }
        if (values.Count == 0)
            return null;
        return values.ToArray();
    }

    public override void CalcBonuses()
    {
        Game.HasSustainConstitution = true;
        Game.HasRegeneration = true;
    }
}
