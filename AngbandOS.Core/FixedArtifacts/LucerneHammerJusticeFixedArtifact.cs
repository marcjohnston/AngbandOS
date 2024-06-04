// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class TheLucerneHammerJusticeFixedArtifact : FixedArtifact
{
    private TheLucerneHammerJusticeFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(LucerneHammerHaftedWeaponItemFactory);

    // Justice drains life
    protected override string? ActivationName => nameof(DrainLife90Every70Activation);

    public override void ApplyResistances(Item item)
    {
        item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemAdditiveBundleWeightedRandom>(nameof(FixedArtifactItemAdditiveBundleWeightedRandom)));
    }

    public override ColorEnum Color => ColorEnum.BrightBlue;
    public override string Name => "The Lucerne Hammer 'Justice'";
    public override int Ac => 0;
    public override bool Activate => true;
    public override bool BrandCold => true;
    public override int Cost => 30000;
    public override int Dd => 2;
    public override int Ds => 5;
    public override string FriendlyName => "'Justice'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool Infra => true;
    public override int Level => 20;

    /// <summary>
    /// Returns a value of 3 to add to the radius of light for a lucrene hammer which provides no light.
    /// </summary>
    public override int Radius => 3;

    public override int InitialTypeSpecificValue => 4;
    public override int Rarity => 15;
    public override bool Regen => true;
    public override bool ResCold => true;
    public override bool ResLight => true;
    public override bool ShowMods => true;
    public override bool SlayOrc => true;
    public override int ToA => 8;
    public override int ToD => 6;
    public override int ToH => 10;
    public override int Weight => 120;
    public override bool Wis => true;
}
