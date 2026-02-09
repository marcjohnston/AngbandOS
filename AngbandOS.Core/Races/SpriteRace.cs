// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Races;

[Serializable]
internal class SpriteRace : Race
{
    private SpriteRace(Game game) : base(game) { }
    protected override string EnhancementBindingKey => nameof(SpriteRaceItemEnhancement);
    public override string Title => "Sprite";
    public override int UseDevice => 10;
    public override int SavingThrow => 10;
    public override int Stealth => 4;
    public override int Search => 10;
    public override int BaseSearchFrequency => 10;
    public override int MeleeToHit => -12;
    public override int RangedToHit => 0;
    public override int HitDieBonus => 7;
    public override int ExperienceFactor => 175;
    public override int BaseAge => 50;
    public override int AgeRange => 25;
    public override int Infravision => 4;
    public override uint Choice => 0xBE5E;
    public override string Description => "Sprites are tiny fairies, distantly related to elves. They\nshare their relatives' resistance to light based attacks,\nand their wings both protect them from falling damage and\nallow them to move progressively faster if unencumbered.\nSprites glow in the dark and can learn to throw fairy dust\nto send their enemies to sleep (at lvl 12).";

    /// <summary>
    /// Sprite 124->125->126->127->128->End
    /// </summary>
    public override int Chart => 124;

    public override string RacialPowersDescription(int lvl) => lvl < 12 ? "sleeping dust      (racial, unusable until level 12)" : "sleeping dust      (racial, cost 12, INT based)";
    protected override string? RacialPowerScriptBindingKey => nameof(UseRacialPowerScript);
    public override bool HasRacialPowers => true;
    public override void UpdateRacialAbilities(int level, EffectiveAttributeSet itemCharacteristics)
    {
        itemCharacteristics.ResLight = true;
        itemCharacteristics.Feather = true;
        if (level > 9)
        {
            itemCharacteristics.Speed++;
        }
    }
    protected override string GenerateNameSyllableSetName => nameof(ElvishSyllableSet);

    public override string[]? SelfKnowledge(int level)
    {
        if (level > 11)
        {
            return new string[] { "You can throw magic dust which induces sleep (cost 12)." };
        }
        return null;
    }
    public override void CalcBonuses()
    {
        Game.HasFeatherFall = true;
        Game.GlowInTheDarkRadius = 1;
        Game.HasLightResistance = true;
        Game.Speed.IntValue += Game.ExperienceLevel.IntValue / 10;
    }
}
