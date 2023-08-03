// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class SlimeMoldJuicePotionItemFactory : PotionItemFactory
{
    private SlimeMoldJuicePotionItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<ExclamationPointSymbol>();
    public override string Name => "Slime Mold Juice";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 2;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Slime Mold Juice";
    public override int Pval => 400;
    public override int Weight => 4;
    public override bool Quaff()
    {
        // Slime mold juice has a random effect (calling this function again recusively)
        SaveGame.MsgPrint("That tastes awful.");
        PotionItemFactory potion = RandomPotion(SaveGame);
        potion.Quaff();
        return true;
    }

    /// <summary>
    /// Returns null because the slime-mold potion is always an icky-green flavour.
    /// </summary>
    public override IEnumerable<Flavour>? GetFlavorRepository()
    {
        Flavor = SaveGame.SingletonRepository.PotionFlavours.Get<IckyGreenPotionFlavour>();
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
    private PotionItemFactory RandomPotion(SaveGame saveGame)
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

        switch (SaveGame.Rng.DieRoll(48))
        {
            case 1:
                return (PotionItemFactory)saveGame.SingletonRepository.ItemFactories.Get<WaterPotionItemFactory>();
            case 2:
                return (PotionItemFactory)saveGame.SingletonRepository.ItemFactories.Get<AppleJuicePotionItemFactory>();
            case 3:
                return (PotionItemFactory)saveGame.SingletonRepository.ItemFactories.Get<SlownessPotionItemFactory>();
            case 4:
                return (PotionItemFactory)saveGame.SingletonRepository.ItemFactories.Get<SaltWaterPotionItemFactory>();
            case 5:
                return (PotionItemFactory)saveGame.SingletonRepository.ItemFactories.Get<PoisonPotionItemFactory>();
            case 6:
                return (PotionItemFactory)saveGame.SingletonRepository.ItemFactories.Get<BlindnessPotionItemFactory>();
            case 7:
                return (PotionItemFactory)saveGame.SingletonRepository.ItemFactories.Get<BoozePotionItemFactory>();
            case 8:
                return (PotionItemFactory)saveGame.SingletonRepository.ItemFactories.Get<SleepPotionItemFactory>();
            case 9:
                return (PotionItemFactory)saveGame.SingletonRepository.ItemFactories.Get<InfravisionPotionItemFactory>();
            case 10:
                return (PotionItemFactory)saveGame.SingletonRepository.ItemFactories.Get<DetectInvisiblePotionItemFactory>();
            case 11:
                return (PotionItemFactory)saveGame.SingletonRepository.ItemFactories.Get<SlowPoisonPotionItemFactory>();
            case 12:
                return (PotionItemFactory)saveGame.SingletonRepository.ItemFactories.Get<NeutralizePoisonPotionItemFactory>();
            case 13:
                return (PotionItemFactory)saveGame.SingletonRepository.ItemFactories.Get<BoldnessPotionItemFactory>();
            case 14:
                return (PotionItemFactory)saveGame.SingletonRepository.ItemFactories.Get<SpeedPotionItemFactory>();
            case 15:
                return (PotionItemFactory)saveGame.SingletonRepository.ItemFactories.Get<ResistHeatPotionItemFactory>();
            case 16:
                return (PotionItemFactory)saveGame.SingletonRepository.ItemFactories.Get<ResistColdPotionItemFactory>();
            case 17:
                return (PotionItemFactory)saveGame.SingletonRepository.ItemFactories.Get<HeroismPotionItemFactory>();
            case 18:
                return (PotionItemFactory)saveGame.SingletonRepository.ItemFactories.Get<BerserkStrengthPotionItemFactory>();
            case 19:
                return (PotionItemFactory)saveGame.SingletonRepository.ItemFactories.Get<CureLightWoundsPotionItemFactory>();
            case 20:
                return (PotionItemFactory)saveGame.SingletonRepository.ItemFactories.Get<CureSeriousWoundsPotionItemFactory>();
            case 21:
                return (PotionItemFactory)saveGame.SingletonRepository.ItemFactories.Get<CureCriticalWoundsPotionItemFactory>();
            case 22:
                return (PotionItemFactory)saveGame.SingletonRepository.ItemFactories.Get<HealingPotionItemFactory>();
            case 23:
                return (PotionItemFactory)saveGame.SingletonRepository.ItemFactories.Get<SpecialHealingPotionItemFactory>();
            case 24:
                return (PotionItemFactory)saveGame.SingletonRepository.ItemFactories.Get<LifePotionItemFactory>();
            case 25:
                return (PotionItemFactory)saveGame.SingletonRepository.ItemFactories.Get<RestoreManaPotionItemFactory>();
            case 26:
                return (PotionItemFactory)saveGame.SingletonRepository.ItemFactories.Get<RestoreLifeLevelsPotionItemFactory>();
            case 27:
                return (PotionItemFactory)saveGame.SingletonRepository.ItemFactories.Get<RestoreStrengthPotionItemFactory>();
            case 28:
                return (PotionItemFactory)saveGame.SingletonRepository.ItemFactories.Get<RestoreIntelligencePotionItemFactory>();
            case 29:
                return (PotionItemFactory)saveGame.SingletonRepository.ItemFactories.Get<RestoreWisdomPotionItemFactory>();
            case 30:
                return (PotionItemFactory)saveGame.SingletonRepository.ItemFactories.Get<RestoreDexterityPotionItemFactory>();
            case 31:
                return (PotionItemFactory)saveGame.SingletonRepository.ItemFactories.Get<RestoreConstitutionPotionItemFactory>();
            case 32:
                return (PotionItemFactory)saveGame.SingletonRepository.ItemFactories.Get<RestoreCharismaPotionItemFactory>();
            case 33:
                return (PotionItemFactory)saveGame.SingletonRepository.ItemFactories.Get<StrengthPotionItemFactory>();
            case 34:
                return (PotionItemFactory)saveGame.SingletonRepository.ItemFactories.Get<IntelligencePotionItemFactory>();
            case 35:
                return (PotionItemFactory)saveGame.SingletonRepository.ItemFactories.Get<WisdomPotionItemFactory>();
            case 36:
                return (PotionItemFactory)saveGame.SingletonRepository.ItemFactories.Get<DexterityPotionItemFactory>();
            case 37:
                return (PotionItemFactory)saveGame.SingletonRepository.ItemFactories.Get<ConstitutionPotionItemFactory>();
            case 38:
                return (PotionItemFactory)saveGame.SingletonRepository.ItemFactories.Get<CharismaPotionItemFactory>();
            case 39:
                return (PotionItemFactory)saveGame.SingletonRepository.ItemFactories.Get<AugmentationPotionItemFactory>();
            case 40:
                return (PotionItemFactory)saveGame.SingletonRepository.ItemFactories.Get<EnlightenmentPotionItemFactory>();
            case 41:
                return (PotionItemFactory)saveGame.SingletonRepository.ItemFactories.Get<SpecialEnlightenmentPotionItemFactory>();
            case 42:
                return (PotionItemFactory)saveGame.SingletonRepository.ItemFactories.Get<SelfKnowledgePotionItemFactory>();
            case 43:
                return (PotionItemFactory)saveGame.SingletonRepository.ItemFactories.Get<ExperiencePotionItemFactory>();
            case 44:
                return (PotionItemFactory)saveGame.SingletonRepository.ItemFactories.Get<ResistancePotionItemFactory>();
            case 45:
                return (PotionItemFactory)saveGame.SingletonRepository.ItemFactories.Get<CuringPotionItemFactory>();
            case 46:
                return (PotionItemFactory)saveGame.SingletonRepository.ItemFactories.Get<InvulnerabilityPotionItemFactory>();
            case 47:
                return (PotionItemFactory)saveGame.SingletonRepository.ItemFactories.Get<NewLifePotionItemFactory>();
            default:
                throw new Exception("Invalid random potion chosen.");
        }
    }
    public override Item CreateItem() => new SlimeMoldJuicePotionItem(SaveGame);
}
