// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class GenericItemFactory : ItemFactory
{
    public GenericItemFactory(Game game, ItemFactoryGameConfiguration itemFactoryGameConfiguration) : base(game)
    {
        Key = itemFactoryGameConfiguration.Key ?? itemFactoryGameConfiguration.GetType().Name;
        ItemEnhancementBindingKey = itemFactoryGameConfiguration.ItemEnhancementBindingKey;

        PreassignedItemFlavorBindingKey = itemFactoryGameConfiguration.PreassignedItemFlavorBindingKey;
        NegativeBonusDamageRepresentsBroken = itemFactoryGameConfiguration.NegativeBonusDamageRepresentsBroken;
        NegativeBonusArmorClassRepresentsBroken = itemFactoryGameConfiguration.NegativeBonusArmorClassRepresentsBroken;
        NegativeBonusHitRepresentsBroken = itemFactoryGameConfiguration.NegativeBonusHitRepresentsBroken;
        SlayingRandomArtifactItemEnhancementWeightedRandomBindingKey = itemFactoryGameConfiguration.SlayingRandomArtifactItemEnhancementWeightedRandomBindingKey;
        RandomArtifactBonusArmorCeiling = itemFactoryGameConfiguration.RandomArtifactBonusArmorCeiling;
        RandomArtifactBonusHitCeiling = itemFactoryGameConfiguration.RandomArtifactBonusHitCeiling;
        RandomArtifactBonusDamageCeiling = itemFactoryGameConfiguration.RandomArtifactBonusDamageCeiling;
        RefillScriptBindingKey = itemFactoryGameConfiguration.RefillScriptBindingKey;
        SymbolBindingKey = itemFactoryGameConfiguration.SymbolBindingKey;
        CanBeWeaponOfLaw = itemFactoryGameConfiguration.CanBeWeaponOfLaw;
        CanBeWeaponOfSharpness = itemFactoryGameConfiguration.CanBeWeaponOfSharpness;
        CapableOfVorpalSlaying = itemFactoryGameConfiguration.CapableOfVorpalSlaying;
        Color = itemFactoryGameConfiguration.Color;
        UseBindingTuple = itemFactoryGameConfiguration.UseBindingTuple;
        QuaffBindingTuple = itemFactoryGameConfiguration.QuaffBindingTuple;
        AmmunitionItemFactoryBindingKeys = itemFactoryGameConfiguration.AmmunitionItemFactoryBindingKeys;
        CanSpikeDoorClosed = itemFactoryGameConfiguration.CanSpikeDoorClosed;
        CanTunnel = itemFactoryGameConfiguration.CanTunnel;
        CanProjectArrows = itemFactoryGameConfiguration.CanProjectArrows;
        EnchantmentMaximumCount = itemFactoryGameConfiguration.EnchantmentMaximumCount;
        IsMagical = itemFactoryGameConfiguration.IsMagical;
        ValuePerTurnOfLight = itemFactoryGameConfiguration.ValuePerTurnOfLight;
        AimingBindingTuple = itemFactoryGameConfiguration.AimingBindingTuple;
        IsBroken = itemFactoryGameConfiguration.IsBroken;
        InitialBrokenStomp = itemFactoryGameConfiguration.InitialBrokenStomp;
        InitialAverageStomp = itemFactoryGameConfiguration.InitialAverageStomp;
        InitialGoodStomp = itemFactoryGameConfiguration.InitialGoodStomp;
        InitialExcellentStomp = itemFactoryGameConfiguration.InitialExcellentStomp;
        RechargeScriptBindingKey = itemFactoryGameConfiguration.RechargeScriptBindingKey;
        IsIgnoredByMonsters = itemFactoryGameConfiguration.IsIgnoredByMonsters;
        IsContainer = itemFactoryGameConfiguration.IsContainer;
        IsRangedWeapon = itemFactoryGameConfiguration.IsRangedWeapon;
        MissileDamageMultiplier = itemFactoryGameConfiguration.MissileDamageMultiplier;
        MaxPhlogiston = itemFactoryGameConfiguration.MaxPhlogiston;
        BurnRate = itemFactoryGameConfiguration.BurnRate;
        MassProduceBindingTuples = itemFactoryGameConfiguration.MassProduceBindingTuples;
        BonusHitRealValueMultiplier = itemFactoryGameConfiguration.BonusHitRealValueMultiplier;
        BonusDamageRealValueMultiplier = itemFactoryGameConfiguration.BonusDamageRealValueMultiplier;
        BonusArmorClassRealValueMultiplier = itemFactoryGameConfiguration.BonusArmorClassRealValueMultiplier;
        BonusDiceRealValueMultiplier = itemFactoryGameConfiguration.BonusDiceRealValueMultiplier;
        BreaksDuringEnchantmentProbabilityExpression = itemFactoryGameConfiguration.BreaksDuringEnchantmentProbabilityExpression;
        EnchantmentBindingTuples = itemFactoryGameConfiguration.EnchantmentBindingTuples;
        EatMagicScriptBindingKey = itemFactoryGameConfiguration.EatMagicScriptBindingKey;
        GridProcessWorldScriptBindingKey = itemFactoryGameConfiguration.GridProcessWorldScriptBindingKey;
        MonsterProcessWorldScriptBindingKey = itemFactoryGameConfiguration.MonsterProcessWorldScriptBindingKey;
        EquipmentProcessWorldScriptBindingKey = itemFactoryGameConfiguration.EquipmentProcessWorldScriptBindingKey;
        PackProcessWorldScriptBindingKey = itemFactoryGameConfiguration.PackProcessWorldScriptBindingKey;
        CanApplyBonusArmorClassMiscPower = itemFactoryGameConfiguration.CanApplyBonusArmorClassMiscPower;
        CanApplyBlowsBonus = itemFactoryGameConfiguration.CanApplyBlowsBonus;
        BreakageChanceProbabilityExpression = itemFactoryGameConfiguration.BreakageChanceProbabilityExpression;
        MakeObjectCountExpression = itemFactoryGameConfiguration.MakeObjectCountExpression;
        GetsDamageMultiplier = itemFactoryGameConfiguration.GetsDamageMultiplier;
        IdentityCanBeSensed = itemFactoryGameConfiguration.IdentityCanBeSensed;
        IsFuelForTorch = itemFactoryGameConfiguration.IsFuelForTorch;
        IsWearableOrWieldable = itemFactoryGameConfiguration.IsWearableOrWieldable;
        CanBeEaten = itemFactoryGameConfiguration.CanBeEaten;
        IsArmor = itemFactoryGameConfiguration.IsArmor;
        IsWeapon = itemFactoryGameConfiguration.IsWeapon;
        NumberOfItemsContained = itemFactoryGameConfiguration.NumberOfItemsContained;
        Name = itemFactoryGameConfiguration.Name;
        DescriptionSyntax = itemFactoryGameConfiguration.DescriptionSyntax;
        AlternateDescriptionSyntax = itemFactoryGameConfiguration.AlternateDescriptionSyntax;
        FlavorSuppressedDescriptionSyntax = itemFactoryGameConfiguration.FlavorSuppressedDescriptionSyntax;
        AlternateFlavorSuppressedDescriptionSyntax = itemFactoryGameConfiguration.AlternateFlavorSuppressedDescriptionSyntax;
        FlavorUnknownDescriptionSyntax = itemFactoryGameConfiguration.FlavorUnknownDescriptionSyntax;
        AlternateFlavorUnknownDescriptionSyntax = itemFactoryGameConfiguration.AlternateFlavorUnknownDescriptionSyntax;
        ZapBindingTuple = itemFactoryGameConfiguration.ZapBindingTuple;
        ItemClassBindingKey = itemFactoryGameConfiguration.ItemClassBindingKey;
        IsLanternFuel = itemFactoryGameConfiguration.IsLanternFuel;
        PackSort = itemFactoryGameConfiguration.PackSort;
        WieldSlotBindingKeys = itemFactoryGameConfiguration.WieldSlotBindingKeys;
        AskDestroyAll = itemFactoryGameConfiguration.AskDestroyAll;
        HasQualityRatings = itemFactoryGameConfiguration.HasQualityRatings;
        ArmorClass = itemFactoryGameConfiguration.ArmorClass;
        DepthsFoundAndChances = itemFactoryGameConfiguration.DepthsFoundAndChances;
        Cost = itemFactoryGameConfiguration.Cost;
        DamageDice = itemFactoryGameConfiguration.DamageDice;
        DamageSides = itemFactoryGameConfiguration.DamageSides;
        LevelNormallyFound = itemFactoryGameConfiguration.LevelNormallyFound;
        InitialBonusAttacks = itemFactoryGameConfiguration.InitialBonusAttacks;
        InitialBonusInfravision = itemFactoryGameConfiguration.InitialBonusInfravision;
        InitialBonusSpeed = itemFactoryGameConfiguration.InitialBonusSpeed;
        InitialBonusSearchExpression = itemFactoryGameConfiguration.InitialBonusSearchExpression;
        InitialBonusStealthExpression = itemFactoryGameConfiguration.InitialBonusStealthExpression;
        InitialBonusTunnel = itemFactoryGameConfiguration.InitialBonusTunnel;
        InitialTurnsOfLight = itemFactoryGameConfiguration.InitialTurnsOfLight;
        InitialNutritionalValue = itemFactoryGameConfiguration.InitialNutritionalValue;
        InitialGoldPiecesRollExpression = itemFactoryGameConfiguration.InitialGoldPiecesRollExpression;
        ExperienceGainDivisorForDestroying = itemFactoryGameConfiguration.ExperienceGainDivisorForDestroying;
        SpellBindingKeys = itemFactoryGameConfiguration.SpellBindingKeys;
        BonusArmorClass = itemFactoryGameConfiguration.BonusArmorClass;
        BonusDamage = itemFactoryGameConfiguration.BonusDamage;
        BonusHit = itemFactoryGameConfiguration.BonusHit;
        Weight = itemFactoryGameConfiguration.Weight;
        IsSmall = itemFactoryGameConfiguration.IsSmall;
        CanApplySlayingBonus = itemFactoryGameConfiguration.CanApplySlayingBonus;
        BaseValue = itemFactoryGameConfiguration.BaseValue;
        HatesElectricity = itemFactoryGameConfiguration.HatesElectricity;
        HatesFire = itemFactoryGameConfiguration.HatesFire;
        HatesAcid = itemFactoryGameConfiguration.HatesAcid;
        HatesCold = itemFactoryGameConfiguration.HatesCold;
        CanProvideSheathOfElectricity = itemFactoryGameConfiguration.CanProvideSheathOfElectricity;
        CanProvideSheathOfFire = itemFactoryGameConfiguration.CanProvideSheathOfFire;
        CanReflectBoltsAndArrows = itemFactoryGameConfiguration.CanReflectBoltsAndArrows;
        RandartActivationChance = itemFactoryGameConfiguration.RandartActivationChance;
        ProvidesSunlight = itemFactoryGameConfiguration.ProvidesSunlight;
        CanApplyArtifactBiasSlaying = itemFactoryGameConfiguration.CanApplyArtifactBiasSlaying;
        CanApplyArtifactBiasResistance = itemFactoryGameConfiguration.CanApplyArtifactBiasResistance;
        CanApplyBlessedArtifactBias = itemFactoryGameConfiguration.CanApplyBlessedArtifactBias;
        CanBeEatenByMonsters = itemFactoryGameConfiguration.CanBeEatenByMonsters;
        EatScriptBindingKey = itemFactoryGameConfiguration.EatScriptBindingKey;
        VanishesWhenEatenBySkeletons = itemFactoryGameConfiguration.VanishesWhenEatenBySkeletons;
        IsConsumedWhenEaten = itemFactoryGameConfiguration.IsConsumedWhenEaten;
        ReadBindingTuple = itemFactoryGameConfiguration.ReadBindingTuple;
    }

    public override string Key { get; }
    protected override string? ItemEnhancementBindingKey { get; } = null;

    /// <summary>
    /// Returns the name of the <see cref="ItemFlavor"/> that this item should be assigned.  This assignment overrides the random flavor assignment, when the <see cref="ItemClass"/>
    /// utilizes item flavors.  Returns null, to allow the <see cref="ItemClass"/> to assign a random <see cref="ItemFlavor"/> or when this factory doesn't produce flavored items.
    /// This property is used to bind the <see cref="PreassignedItemFlavor"/> property during the binding phase.
    /// </summary>
    protected override string? PreassignedItemFlavorBindingKey { get; } = null;

    public override bool NegativeBonusDamageRepresentsBroken { get; } = false;
    public override bool NegativeBonusArmorClassRepresentsBroken { get; } = false;
    public override bool NegativeBonusHitRepresentsBroken { get; } = false;

    protected override string? SlayingRandomArtifactItemEnhancementWeightedRandomBindingKey { get; } = nameof(SlayingItemEnhancementWeightedRandom);
    public override int? RandomArtifactBonusArmorCeiling { get; } = null;
    public override int? RandomArtifactBonusHitCeiling { get; } = null;
    public override int? RandomArtifactBonusDamageCeiling { get; } = null;
    protected override string? RefillScriptBindingKey { get; } = null;
    protected override string SymbolBindingKey { get; }
    public override bool CanBeWeaponOfLaw { get; } = false;
    public override bool CanBeWeaponOfSharpness { get; } = false;
    public override bool CapableOfVorpalSlaying { get; } = false;
    public override ColorEnum Color { get; } = ColorEnum.White;
    protected override (string UseScriptBindingKey, string InitialChargesRollExpression, int PerChargeValue, int ManaEquivalent)? UseBindingTuple { get; } = null;
    protected override (string QuaffScriptName, string? SmashScriptName, int ManaEquivalent)? QuaffBindingTuple { get; } = null;
    protected override string[]? AmmunitionItemFactoryBindingKeys { get; } = null;
    public override bool CanSpikeDoorClosed { get; } = false;
    public override bool CanTunnel { get; } = false;
    public override bool CanProjectArrows { get; } = false;
    public override int EnchantmentMaximumCount { get; } = 1;
    public override bool IsMagical { get; } = false;
    public override int ValuePerTurnOfLight { get; } = 0;
    protected override (string ActivationScriptName, string InitialChargesCountRollExpression, int PerChargeValue, int ManaValue)? AimingBindingTuple { get; } = null;
    public override bool IsBroken { get; } = false;
    public override bool InitialBrokenStomp { get; } = false;
    public override bool InitialAverageStomp { get; } = false;
    public override bool InitialGoodStomp { get; } = false;
    public override bool InitialExcellentStomp { get; } = false;
    protected override string? RechargeScriptBindingKey { get; } = null;
    public override bool IsIgnoredByMonsters { get; } = false;
    public override bool IsContainer { get; } = false;
    public override bool IsRangedWeapon { get; } = false;
    public override int MissileDamageMultiplier { get; } = 1;
    public override int? MaxPhlogiston { get; } = null;
    public override int BurnRate { get; } = 0;
    protected override (int count, string rollExpression)[]? MassProduceBindingTuples { get; } = null;
    public override int BonusHitRealValueMultiplier { get; } = 100;
    public override int BonusDamageRealValueMultiplier { get; } = 100;
    public override int BonusArmorClassRealValueMultiplier { get; } = 100;
    public override int BonusDiceRealValueMultiplier { get; } = 100;
    protected override string? BreaksDuringEnchantmentProbabilityExpression { get; } = null;
    protected override (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]? EnchantmentBindingTuples { get; } = null;
    protected override string? EatMagicScriptBindingKey { get; } = null;
    protected override string? GridProcessWorldScriptBindingKey { get; } = null;
    protected override string? MonsterProcessWorldScriptBindingKey { get; } = null;
    protected override string? EquipmentProcessWorldScriptBindingKey { get; } = null;
    protected override string? PackProcessWorldScriptBindingKey { get; } = null;
    public override bool CanApplyBonusArmorClassMiscPower { get; } = false;
    public override bool CanApplyBlowsBonus { get; } = false;
    protected override string BreakageChanceProbabilityExpression { get; } = "10/100";
    protected override string MakeObjectCountExpression { get; } = "1";
    public override bool GetsDamageMultiplier { get; } = false;
    public override bool IdentityCanBeSensed { get; } = false;
    public override bool IsFuelForTorch { get; } = false;
    public override bool IsWearableOrWieldable { get; } = false;
    public override bool CanBeEaten { get; } = false;
    public override bool IsArmor { get; } = false;
    public override bool IsWeapon { get; } = false;
    public override int NumberOfItemsContained { get; } = 0;
    public override string Name { get; }
    protected override string? DescriptionSyntax { get; } = null; // TODO: Books use a hard-coded realm name when the realm is set at run-time.
    protected override string? AlternateDescriptionSyntax { get; } = null; // TODO: This coded divine name has hard-coded realm names when realm is set at run-time.
    protected override string? FlavorSuppressedDescriptionSyntax { get; } = null;
    protected override string? AlternateFlavorSuppressedDescriptionSyntax { get; } = null;
    protected override string? FlavorUnknownDescriptionSyntax { get; } = null;
    protected override string? AlternateFlavorUnknownDescriptionSyntax { get; } = null;
    protected override (string ScriptName, string TurnsToRecharge, bool RequiresAiming, int ManaEquivalent)? ZapBindingTuple { get; } = null;
    protected override string ItemClassBindingKey { get; }
    public override bool IsLanternFuel { get; } = false;
    public override int PackSort { get; }
    protected override string[] WieldSlotBindingKeys { get; } = new string[] { nameof(PackWieldSlot) };
    public override bool AskDestroyAll { get; } = true;
    public override bool HasQualityRatings { get; } = false;
    public override int ArmorClass { get; } = 0;
    public override (int level, int chance)[]? DepthsFoundAndChances { get; } = null; // TODO: Convert the chance into a Roll object
    public override int Cost { get; } = 0;
    public override int DamageDice { get; } = 0;
    public override int DamageSides { get; } = 0;
    public override int LevelNormallyFound { get; } = 0;
    public override int InitialBonusAttacks { get; } = 0;
    public override int InitialBonusInfravision { get; } = 0;
    public override int InitialBonusSpeed { get; } = 0;
    protected override string InitialBonusSearchExpression { get; } = "0";
    protected override string InitialBonusStealthExpression { get; } = "0";
    public override int InitialBonusTunnel { get; } = 0;
    public override int InitialTurnsOfLight { get; } = 0;
    public override int InitialNutritionalValue { get; } = 0;
    protected override string InitialGoldPiecesRollExpression { get; } = "0";
    public override int ExperienceGainDivisorForDestroying { get; } = 0;
    protected override string[]? SpellBindingKeys { get; } = null;
    public override int BonusArmorClass { get; } = 0;
    public override int BonusDamage { get; } = 0;
    public override int BonusHit { get; } = 0;
    public override int Weight { get; } = 0;
    public override bool IsSmall { get; } = false; // TODO: This property is only valid when IsContainer.  The data type is horrible.
    public override bool CanApplySlayingBonus { get; } = false;
    public override int BaseValue { get; } = 0;
    public override bool HatesElectricity { get; } = false;
    public override bool HatesFire { get; } = false;
    public override bool HatesAcid { get; } = false;
    public override bool HatesCold { get; } = false;
    public override bool CanProvideSheathOfElectricity { get; } = false;
    public override bool CanProvideSheathOfFire { get; } = false;
    public override bool CanReflectBoltsAndArrows { get; } = false;
    public override int RandartActivationChance { get; } = 3;
    public override bool ProvidesSunlight { get; } = false;
    public override bool CanApplyArtifactBiasSlaying { get; } = true;
    public override bool CanApplyArtifactBiasResistance { get; } = true;
    public override bool CanApplyBlessedArtifactBias { get; } = false;
    public override bool CanBeEatenByMonsters { get; } = false;
    public override string? EatScriptBindingKey { get; } = null;
    public override bool VanishesWhenEatenBySkeletons { get; } = false;
    public override bool IsConsumedWhenEaten { get; } = true;
    protected override (string ScriptName, int ManaValue)? ReadBindingTuple { get; } = null;
}
