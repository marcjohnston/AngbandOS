// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class HardLeatherCapOfTheMindcrafterFixedArtifact : FixedArtifact
{
    private HardLeatherCapOfTheMindcrafterFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(HardLeatherCapHelmItemFactory);

    public override void ApplyResistances(Item item)
    {
        item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemEnhancementWeightedRandom>(nameof(FixedArtifactItemEnhancementWeightedRandom)));
    }
    public override ColorEnum Color => ColorEnum.Brown;
    public override string Name => "The Hard Leather Cap of the Mindcrafter";
    public override int Ac => 2;
    public override int Cost => 50000;
    public override int Dd => 0;
    public override int Ds => 0;
    public override string FriendlyName => "of the Mindcrafter";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool Int => true;
    public override int Level => 20;
    protected override string? BonusIntelligenceRollExpression => "2";
    protected override string? BonusWisdomRollExpression => "2";
    public override int Rarity => 2;
    public override bool ResBlind => true;
    public override bool Telepathy => true;
    public override int ToA => 10;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 15;
    public override bool Wis => true;
}
