// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class DaggerFaithFixedArtifact : FixedArtifact
{
    private DaggerFaithFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(DaggerWeaponItemFactory);

    // Faith shoots a fire bolt
    protected override string? ActivationName => nameof(FireBolt9d8Every8p1d8DirectionalActivation);

    public override void ApplyResistances(Item item)
    {
        item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemEnhancementWeightedRandom>(nameof(FixedArtifactItemEnhancementWeightedRandom)));
    }

    public override ColorEnum Color => ColorEnum.BrightWhite;
    public override string Name => "The Dagger 'Faith'";
    public override int Ac => 0;
    public override bool BrandFire => true;
    public override int Cost => 12000;
    public override int Dd => 1;
    public override int Ds => 4;
    public override string FriendlyName => "'Faith'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 4;

    /// <summary>
    /// Returns a value of 3 to add to the radius of light for a dagger which provides no light.
    /// </summary>
    public override int Radius => 3;

    public override int Rarity => 10;
    public override bool ResFire => true;
    public override bool ShowMods => true;
    public override int ToA => 0;
    public override int ToD => 6;
    public override int ToH => 4;
    public override int Weight => 12;
}
