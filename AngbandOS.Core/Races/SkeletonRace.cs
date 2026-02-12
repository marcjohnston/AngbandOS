// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Races;

[Serializable]
internal class SkeletonRace : Race
{
    private SkeletonRace(Game game) : base(game) { }
    protected override string EnhancementBindingKey => nameof(SkeletonRaceItemEnhancement);
    public override string Title => "Skeleton";
    public override int UseDevice => -5;
    public override int SavingThrow => 5;
    public override int Stealth => -1;
    public override int Search => -1;
    public override int BaseSearchFrequency => 8;
    public override int MeleeToHit => 10;
    public override int RangedToHit => 0;
    public override int HitDieBonus => 10;
    public override int ExperienceFactor => 145;
    public override int BaseAge => 100;
    public override int AgeRange => 35;
    public override int Infravision => 2;
    public override uint Choice => 0x5F0F;
    public override string Description => "Skeletons are undead creatures. Being without eyes, they\nuse magical sight which can see invisible creatures. Their\nlack of flesh means that they resist poison and shards, and\ntheir life force is hard to drain. They can learn to resist\ncold (at lvl 10), and restore their life force (at lvl 30).";

    /// <summary>
    /// Skeleton 102->103->104->105->106->End
    /// </summary>
    public override int Chart => 102;
    public override string RacialPowersDescription(int lvl) => lvl < 30 ? "restore life       (racial, unusable until level 30)" : "restore life       (racial, cost 30, WIS based)";
    protected override string? RacialPowerScriptBindingKey => nameof(UseRacialPowerScript);
    public override bool HasRacialPowers => true;
    public override void UpdateRacialAbilities(int level, EffectiveAttributeSet itemCharacteristics)
    {
        itemCharacteristics.SeeInvis = true;
        itemCharacteristics.ResShards = true;
        itemCharacteristics.HoldLife = true;
        itemCharacteristics.ResPois = true;
        if (level > 9)
        {
            itemCharacteristics.ResCold = true;
        }
    }
    protected override string GenerateNameSyllableSetName => nameof(HumanSyllableSet);
    public override string[]? SelfKnowledge(int level)
    {
        if (level > 29)
        {
            return new string[] { "You can restore lost life forces (cost 30)." };
        }
        return null;
    }
    public override void CalcBonuses()
    {
        Game.HasShardResistance = true;
        Game.HasHoldLife = true;
        Game.HasSeeInvisibility = true;
        Game.HasPoisonResistance = true;
        if (Game.ExperienceLevel.IntValue > 9)
        {
            Game.HasColdResistance = true;
        }
    }
    public override bool RestsTillDuskInsteadOfDawn => true;

    // Skeletons get no food sustenance
    public override void Eat(Item item)
    {
        // Check to see if the food item is a waybread, warpstones or a biscuit.
        if (item.VanishesWhenEatenBySkeletons)
        {
            // These magical food types vanish.
            Game.MsgPrint("The food falls through your jaws and vanishes!");
        }
        else
        {
            // Spawn a new food item on the floor to make up for the one that will be destroyed
            Item floorItem = item.TakeFromStack(1);
            Game.MsgPrint("The food falls through your jaws!");
            Game.DropNear(floorItem, null, Game.MapY.IntValue, Game.MapX.IntValue);
        }
    }

    public override void Quaff(Item item)
    {
        if (Game.DieRoll(12) == 1)
        {
            Game.MsgPrint("Some of the fluid falls through your jaws!");
            item.Smash(0, Game.MapY.IntValue, Game.MapX.IntValue);
        }
    }
    public override bool CanBleed(int level) => false;
    public override int ChanceOfSanityBlastImmunity(int level) => level + 25;
}
