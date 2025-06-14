// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class CloakOfTheSwashbucklerFixedArtifact : FixedArtifact
{
    private CloakOfTheSwashbucklerFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(ClothCloakItemFactory);

    // Swashbuckler recharges items
    protected override string? ActivationName => nameof(RechargeActivation);

    public override void ApplyResistances(Item item)
    {
        item.RandomPower = Game.SingletonRepository.Get<ItemEnhancementWeightedRandom>(nameof(AbilityItemEnhancementWeightedRandom)).Choose();
    }

    public override ColorEnum Color => ColorEnum.Green;
    public override string Name => "The Cloak of the Swashbuckler";
    public override int Ac => 1;
    public override bool Cha => true;
    public override int Cost => 35000;
    public override int Dd => 0;
    public override bool Dex => true;
    public override int Ds => 0;
    public override bool FreeAct => true;
    public override string FriendlyName => "of the Swashbuckler";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 10;
    protected override string? BonusCharismaRollExpression => "3";
    protected override string? BonusDexterityRollExpression => "3";
    public override int Rarity => 90;
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResFire => true;
    public override int ToA => 18;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 10;
}
