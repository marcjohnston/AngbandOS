// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class SlimeMoldJuicePotionItemFactory : PotionItemFactory
{
    private SlimeMoldJuicePotionItemFactory(Game game) : base(game) { } // This object is a singleton

    protected override string SymbolName => nameof(ExclamationPointSymbol);
    public override string Name => "Slime Mold Juice";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 2;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Slime Mold Juice";
    public override int InitialNutritionalValue => 400;
    public override int Weight => 4;
    public override bool Quaff()
    {
        // Slime mold juice has a random effect (calling this function again recusively)
        Game.MsgPrint("That tastes awful.");
        PotionItemFactory potion = RandomPotion(Game);
        potion.Quaff();
        return true;
    }

    /// <summary>
    /// Returns null because the slime-mold potion is always an icky-green flavor.
    /// </summary>
    public override IEnumerable<ReadableFlavor>? GetFlavorRepository()
    {
        Flavor = Game.SingletonRepository.Get<PotionReadableFlavor>(nameof(IckyGreenPotionReadableFlavor));
        return null;
    }

    public override bool Smash(int who, int y, int x)
    {
        return true;
    }

    /// <summary>
    /// Pick a random potion to use from a selection that won't kill us
    /// </summary>
    /// <returns> The item sub-category of the potion to use </returns>
    private PotionItemFactory RandomPotion(Game game)
    {
        // The following potions are not selected as random.  SlimeMold is the potion causing the random.
        //Death = 23,
        //DecCha = 21,
        //DecCon = 20,
        //DecDex = 19,
        //DecInt = 17,
        //DecStr = 16,
        //DecWis = 18,
        //LoseMemories = 13,
        //Ruination = 15,
        //SlimeMold = 2,

        switch (Game.DieRoll(48))
        {
            case 1:
                return (PotionItemFactory)game.SingletonRepository.Get<ItemFactory>(nameof(WaterPotionItemFactory));
            case 2:
                return (PotionItemFactory)game.SingletonRepository.Get<ItemFactory>(nameof(AppleJuicePotionItemFactory));
            case 3:
                return (PotionItemFactory)game.SingletonRepository.Get<ItemFactory>(nameof(SlownessPotionItemFactory));
            case 4:
                return (PotionItemFactory)game.SingletonRepository.Get<ItemFactory>(nameof(SaltWaterPotionItemFactory));
            case 5:
                return (PotionItemFactory)game.SingletonRepository.Get<ItemFactory>(nameof(PoisonPotionItemFactory));
            case 6:
                return (PotionItemFactory)game.SingletonRepository.Get<ItemFactory>(nameof(BlindnessPotionItemFactory));
            case 7:
                return (PotionItemFactory)game.SingletonRepository.Get<ItemFactory>(nameof(BoozePotionItemFactory));
            case 8:
                return (PotionItemFactory)game.SingletonRepository.Get<ItemFactory>(nameof(SleepPotionItemFactory));
            case 9:
                return (PotionItemFactory)game.SingletonRepository.Get<ItemFactory>(nameof(InfravisionPotionItemFactory));
            case 10:
                return (PotionItemFactory)game.SingletonRepository.Get<ItemFactory>(nameof(DetectInvisiblePotionItemFactory));
            case 11:
                return (PotionItemFactory)game.SingletonRepository.Get<ItemFactory>(nameof(SlowPoisonPotionItemFactory));
            case 12:
                return (PotionItemFactory)game.SingletonRepository.Get<ItemFactory>(nameof(NeutralizePoisonPotionItemFactory));
            case 13:
                return (PotionItemFactory)game.SingletonRepository.Get<ItemFactory>(nameof(BoldnessPotionItemFactory));
            case 14:
                return (PotionItemFactory)game.SingletonRepository.Get<ItemFactory>(nameof(SpeedPotionItemFactory));
            case 15:
                return (PotionItemFactory)game.SingletonRepository.Get<ItemFactory>(nameof(ResistHeatPotionItemFactory));
            case 16:
                return (PotionItemFactory)game.SingletonRepository.Get<ItemFactory>(nameof(ResistColdPotionItemFactory));
            case 17:
                return (PotionItemFactory)game.SingletonRepository.Get<ItemFactory>(nameof(HeroismPotionItemFactory));
            case 18:
                return (PotionItemFactory)game.SingletonRepository.Get<ItemFactory>(nameof(BerserkStrengthPotionItemFactory));
            case 19:
                return (PotionItemFactory)game.SingletonRepository.Get<ItemFactory>(nameof(CureLightWoundsPotionItemFactory));
            case 20:
                return (PotionItemFactory)game.SingletonRepository.Get<ItemFactory>(nameof(CureSeriousWoundsPotionItemFactory));
            case 21:
                return (PotionItemFactory)game.SingletonRepository.Get<ItemFactory>(nameof(CureCriticalWoundsPotionItemFactory));
            case 22:
                return (PotionItemFactory)game.SingletonRepository.Get<ItemFactory>(nameof(HealingPotionItemFactory));
            case 23:
                return (PotionItemFactory)game.SingletonRepository.Get<ItemFactory>(nameof(SpecialHealingPotionItemFactory));
            case 24:
                return (PotionItemFactory)game.SingletonRepository.Get<ItemFactory>(nameof(LifePotionItemFactory));
            case 25:
                return (PotionItemFactory)game.SingletonRepository.Get<ItemFactory>(nameof(RestoreManaPotionItemFactory));
            case 26:
                return (PotionItemFactory)game.SingletonRepository.Get<ItemFactory>(nameof(RestoreLifeLevelsPotionItemFactory));
            case 27:
                return (PotionItemFactory)game.SingletonRepository.Get<ItemFactory>(nameof(RestoreStrengthPotionItemFactory));
            case 28:
                return (PotionItemFactory)game.SingletonRepository.Get<ItemFactory>(nameof(RestoreIntelligencePotionItemFactory));
            case 29:
                return (PotionItemFactory)game.SingletonRepository.Get<ItemFactory>(nameof(RestoreWisdomPotionItemFactory));
            case 30:
                return (PotionItemFactory)game.SingletonRepository.Get<ItemFactory>(nameof(RestoreDexterityPotionItemFactory));
            case 31:
                return (PotionItemFactory)game.SingletonRepository.Get<ItemFactory>(nameof(RestoreConstitutionPotionItemFactory));
            case 32:
                return (PotionItemFactory)game.SingletonRepository.Get<ItemFactory>(nameof(RestoreCharismaPotionItemFactory));
            case 33:
                return (PotionItemFactory)game.SingletonRepository.Get<ItemFactory>(nameof(StrengthPotionItemFactory));
            case 34:
                return (PotionItemFactory)game.SingletonRepository.Get<ItemFactory>(nameof(IntelligencePotionItemFactory));
            case 35:
                return (PotionItemFactory)game.SingletonRepository.Get<ItemFactory>(nameof(WisdomPotionItemFactory));
            case 36:
                return (PotionItemFactory)game.SingletonRepository.Get<ItemFactory>(nameof(DexterityPotionItemFactory));
            case 37:
                return (PotionItemFactory)game.SingletonRepository.Get<ItemFactory>(nameof(ConstitutionPotionItemFactory));
            case 38:
                return (PotionItemFactory)game.SingletonRepository.Get<ItemFactory>(nameof(CharismaPotionItemFactory));
            case 39:
                return (PotionItemFactory)game.SingletonRepository.Get<ItemFactory>(nameof(AugmentationPotionItemFactory));
            case 40:
                return (PotionItemFactory)game.SingletonRepository.Get<ItemFactory>(nameof(EnlightenmentPotionItemFactory));
            case 41:
                return (PotionItemFactory)game.SingletonRepository.Get<ItemFactory>(nameof(SpecialEnlightenmentPotionItemFactory));
            case 42:
                return (PotionItemFactory)game.SingletonRepository.Get<ItemFactory>(nameof(SelfKnowledgePotionItemFactory));
            case 43:
                return (PotionItemFactory)game.SingletonRepository.Get<ItemFactory>(nameof(ExperiencePotionItemFactory));
            case 44:
                return (PotionItemFactory)game.SingletonRepository.Get<ItemFactory>(nameof(ResistancePotionItemFactory));
            case 45:
                return (PotionItemFactory)game.SingletonRepository.Get<ItemFactory>(nameof(CuringPotionItemFactory));
            case 46:
                return (PotionItemFactory)game.SingletonRepository.Get<ItemFactory>(nameof(InvulnerabilityPotionItemFactory));
            case 47:
                return (PotionItemFactory)game.SingletonRepository.Get<ItemFactory>(nameof(NewLifePotionItemFactory));
            default:
                throw new Exception("Invalid random potion chosen.");
        }
    }
    public override Item CreateItem() => new Item(Game, this);
}
