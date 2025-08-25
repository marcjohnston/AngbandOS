// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Races;

[Serializable]
internal class SpectreRace : Race
{
    private SpectreRace(Game game) : base(game) { }
    protected override string EnhancementBindingKey => nameof(SpectreRaceItemEnhancement);
    public override string Title => "Spectre";
    public override int BaseDisarmBonus => 10;
    public override int BaseDeviceBonus => 25;
    public override int BaseSaveBonus => 20;
    public override int BaseStealthBonus => 5;
    public override int BaseSearchBonus => 5;
    public override int BaseSearchFrequency => 14;
    public override int BaseMeleeAttackBonus => -15;
    public override int BaseRangedAttackBonus => -5;
    public override int HitDieBonus => 7;
    public override int ExperienceFactor => 180;
    public override int BaseAge => 100;
    public override int AgeRange => 30;
    public override int Infravision => 5;
    public override uint Choice => 0x5F4E;
    public override string Description => "Spectres are ethereal and they can pass through walls and\nother obstacles. They resist nether, attacks, poison, and\ncold; and they need little food. They also resist having\ntheir life force drained and can see invisible creatures.\nFinally, they glow with their own light, can learn to\nscare monsters (at lvl 4) and gain telepathy (at lvl 35).";

    /// <summary>
    /// Spectre 118->119->134->120->121->122->123->End
    /// </summary>
    public override int Chart => 118;

    public override string RacialPowersDescription(int lvl) => lvl < 4 ? "scare monster      (racial, unusable until level 4)" : "scare monster      (racial, cost 3, INT based)";
    protected override string? RacialPowerScriptBindingKey => nameof(UseRacialPowerScript);
    public override bool HasRacialPowers => true;
    public override void UpdateRacialAbilities(int level, EffectiveAttributeSet itemCharacteristics)
    {
        itemCharacteristics.SetBoolValue(AttributeEnum.ResCold, true);
        itemCharacteristics.SetBoolValue(AttributeEnum.SeeInvis, true);
        itemCharacteristics.HoldLife = true;
        itemCharacteristics.SetBoolValue(AttributeEnum.ResNether, true);
        itemCharacteristics.SetBoolValue(AttributeEnum.ResPois, true);
        itemCharacteristics.SetBoolValue(AttributeEnum.SlowDigest, true);
        if (level > 34)
        {
            itemCharacteristics.SetBoolValue(AttributeEnum.Telepathy, true);
        }
    }
    protected override string GenerateNameSyllableSetName => nameof(HumanSyllableSet);

    public override string[]? SelfKnowledge(int level)
    {
        if (level > 3)
        {
            return new string[] { "You can wail to terrify your enemies (cost 3)." };
        }
        return null;
    }
    public override void CalcBonuses()
    {
        Game.HasFeatherFall = true;
        Game.HasNetherResistance = true;
        Game.HasHoldLife = true;
        Game.HasSeeInvisibility = true;
        Game.HasPoisonResistance = true;
        Game.HasSlowDigestion = true;
        Game.HasColdResistance = true;
        Game.GlowInTheDarkRadius = 1;
        if (Game.ExperienceLevel.IntValue > 34)
        {
            Game.HasTelepathy = true;
        }
    }
    public override bool RestsTillDuskInsteadOfDawn => true;
    public override void Eat(Item item)
    {
        // This race only gets 1/20th of the food value
        Game.MsgPrint("The food of mortals is poor sustenance for you.");
        Game.SetFood(Game.Food.IntValue + (item.NutritionalValue / 20));
    }
    public override bool CanBleed(int level) => false;

    public override bool NegatesNetherResistance => true;

    public override bool ProjectingNetherRestoresHealth => true;

    public override bool OutfitsWithScrollsOfSatisfyHunger => true;
    public override bool OutfitsWithScrollsOfLight => true;
    public override int ChanceOfSanityBlastImmunity(int level) => level + 25;
}