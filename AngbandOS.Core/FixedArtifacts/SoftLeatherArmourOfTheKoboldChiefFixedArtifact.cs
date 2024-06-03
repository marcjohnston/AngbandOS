// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”


namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class SoftLeatherArmorOfTheKoboldChiefFixedArtifact : FixedArtifact
{
    private SoftLeatherArmorOfTheKoboldChiefFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(SoftLeatherSoftArmorItemFactory);

    public override void ApplyResistances(Item item)
    {
        item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemAdditiveBundleWeightedRandom>(nameof(FixedArtifactItemAdditiveBundleWeightedRandom)));
    }

    public override ColorEnum Color => ColorEnum.BrightBrown;
    public override string Name => "The Soft Leather Armor of the Kobold Chief";
    public override int Ac => 4;
    public override int Cost => 45000;
    public override int Dd => 0;
    public override int Ds => 0;
    public override string FriendlyName => "of the Kobold Chief";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 20;
    public override int InitialTypeSpecificValue => 4;
    public override int Rarity => 3;
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResDark => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override bool Stealth => true;
    public override int ToA => 20;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 80;
}
