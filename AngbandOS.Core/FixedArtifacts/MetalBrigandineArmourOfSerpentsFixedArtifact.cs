// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”


namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class MetalBrigandineArmorOfSerpentsFixedArtifact : FixedArtifact
{
    private MetalBrigandineArmorOfSerpentsFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(MetalBrigandineHardArmorItemFactory);

    public override void ApplyResistances(Item item)
    {
        item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemAdditiveBundleWeightedRandom>(nameof(FixedArtifactItemAdditiveBundleWeightedRandom)));
    }

    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "The Metal Brigandine Armor of Serpents";
    public override int Ac => 19;
    public override int Cost => 30000;
    public override int Dd => 1;
    public override bool Dex => true;
    public override int Ds => 4;
    public override string FriendlyName => "of Serpents";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 30;
    public override int InitialTypeSpecificValue => 2;
    public override int Rarity => 3;
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResConf => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override bool ResSound => true;
    public override bool Str => true;
    public override int ToA => 15;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 200;
}
