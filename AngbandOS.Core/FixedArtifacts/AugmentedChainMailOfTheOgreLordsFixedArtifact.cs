// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”


namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class AugmentedChainMailOfTheOgreLordsFixedArtifact : FixedArtifact
{
    private AugmentedChainMailOfTheOgreLordsFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(AugmentedChainMailHardArmorItemFactory);

    // Ogre Lords destroys doors
    protected override string? ActivationName => nameof(DestroyDoorsEvery10Activation);

    public override void ApplyResistances(Item item)
    {
        item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemAdditiveBundleWeightedRandom>(nameof(FixedArtifactItemAdditiveBundleWeightedRandom)));
    }

    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "The Augmented Chain Mail of the Ogre Lords";
    public override int Ac => 16;
    public override bool Con => true;
    public override int Cost => 40000;
    public override int Dd => 1;
    public override int Ds => 4;
    public override string FriendlyName => "of the Ogre Lords";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool Int => true;
    public override int Level => 25;
    public override int InitialBonusConstitution => 3;
    public override int InitialBonusIntelligence => 3;
    public override int InitialBonusWisdom => 3;
    public override int Rarity => 9;
    public override bool ResAcid => true;
    public override bool ResConf => true;
    public override bool ResPois => true;
    public override int ToA => 20;
    public override int ToD => 0;
    public override int ToH => -2;
    public override int Weight => 270;
    public override bool Wis => true;
}
