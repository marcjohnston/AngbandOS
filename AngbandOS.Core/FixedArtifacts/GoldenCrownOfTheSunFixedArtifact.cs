// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”


namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class GoldenCrownOfTheSunFixedArtifact : FixedArtifact
{
    private GoldenCrownOfTheSunFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(GoldenCrownArmorItemFactory);

    // Sun Crown heals
    protected override string? ActivationName => nameof(Heal700Every25Activation);

    public override void ApplyResistances(Item item)
    {
        item.RandomPower = Game.SingletonRepository.ToWeightedRandom<Power>(_power => _power.IsAbility == true).Choose();

        item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemAdditiveBundleWeightedRandom>(nameof(FixedArtifactItemAdditiveBundleWeightedRandom)));
    }

    public override ColorEnum Color => ColorEnum.Yellow;
    public override string Name => "The Golden Crown of the Sun";
    public override int Ac => 0;
    public override bool Activate => true;
    public override bool Con => true;
    public override int Cost => 125000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "of the Sun";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 40;

    /// <summary>
    /// Returns a value of 3 to add to the radius of light for a golden crown which provides no light.
    /// </summary>
    public override int Radius => 3;

    public override int InitialTypeSpecificValue => 3;
    public override int Rarity => 40;
    public override bool Regen => true;
    public override bool ResBlind => true;
    public override bool ResChaos => true;
    public override bool ResCold => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override bool ResLight => true;
    public override bool SeeInvis => true;
    public override bool Speed => true;
    public override bool Str => true;
    public override int ToA => 15;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 30;
    public override bool Wis => true;
}
