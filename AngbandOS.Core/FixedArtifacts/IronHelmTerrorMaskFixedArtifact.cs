// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class IronHelmTerrorMaskFixedArtifact : FixedArtifact
{
    private IronHelmTerrorMaskFixedArtifact(Game game) : base(game) { }
    public override int TreasureRating => 10;

    protected override string BaseItemFactoryName => nameof(IronHelmItemFactory);

    public override void ApplyResistances(Item item)
    {
        if (Game.BaseCharacterClass.ID == CharacterClassEnum.Warrior)
        {
            item.RandomPower = Game.SingletonRepository.Get<ItemEnhancementWeightedRandom>(nameof(AbilityItemEnhancementWeightedRandom)).Choose();

            item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemEnhancementWeightedRandom>(nameof(FixedArtifactItemEnhancementWeightedRandom)));
        }
        else
        {
            item.EnchantmentItemProperties.IsCursed = true;
            item.EnchantmentItemProperties.HeavyCurse = true;
            item.EnchantmentItemProperties.Aggravate = true;
            item.EnchantmentItemProperties.DreadCurse = true;
            return;
        }
    }

    // Dragon Helm and Terror Mask cause fear
    protected override string? ActivationName => nameof(Terror40xEvery3xp10Activation);

    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "The Iron Helm 'Terror Mask'";
    public override int Ac => 5;
    public override int Cost => 0;
    public override int Dd => 1;
    public override int Ds => 3;
    public override bool FreeAct => true;
    public override string FriendlyName => "'Terror Mask'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ImCold => true;
    public override bool Int => true;
    public override int Level => 20;
    public override bool NoMagic => true;
    public override string? BonusIntelligenceRollExpression => "-1";
    public override string? BonusSearchRollExpression => "-1";
    public override string? BonusWisdomRollExpression => "-1";
    public override int Rarity => 5;
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResDisen => true;
    public override bool ResFear => true;
    public override bool ResPois => true;
    public override bool Search => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool Teleport => true;
    public override int ToA => 10;
    public override int ToD => 25;
    public override int ToH => 25;
    public override int Weight => 75;
    public override bool Wis => true;
}
