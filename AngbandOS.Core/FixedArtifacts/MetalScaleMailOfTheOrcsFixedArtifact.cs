// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”


namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class MetalScaleMailOfTheOrcsFixedArtifact : FixedArtifact
{
    private MetalScaleMailOfTheOrcsFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(MetalScaleMailHardArmorItemFactory);

    public override void ApplyResistances(Item item)
    {
        item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemAdditiveBundleWeightedRandom>(nameof(FixedArtifactItemAdditiveBundleWeightedRandom)));
    }

    // Orc does Carnage
    protected override string? ActivationName => nameof(GenocideEvery500Activation);

    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "The Metal Scale Mail of the Orcs";
    public override int Ac => 15;
    public override bool Cha => true;
    public override int Cost => 150000;
    public override int TreasureRating => 20;
    public override int Dd => 2;
    public override int Ds => 4;
    public override string FriendlyName => "of the Orcs";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 40;
    protected override string? BonusCharismaRollExpression => "4";
    protected override string? BonusStrengthRollExpression => "4";
    public override int Rarity => 3;
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResDark => true;
    public override bool ResDisen => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override bool Str => true;
    public override int ToA => 40;
    public override int ToD => 0;
    public override int ToH => -2;
    public override int Weight => 250;
}
