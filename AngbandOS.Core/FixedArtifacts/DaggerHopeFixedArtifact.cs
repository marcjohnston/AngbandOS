// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class DaggerHopeFixedArtifact : FixedArtifact
{
    private DaggerHopeFixedArtifact(Game game) : base(game) { }
    public override string? ItemEnhancementBindingKey => nameof(DaggerHopeFixedArtifactItemEnhancement);

    protected override string BaseItemFactoryName => nameof(DaggerWeaponItemFactory);

    public override void ApplyResistances(Item item)
    {
        item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemEnhancementWeightedRandom>(nameof(FixedArtifactItemEnhancementWeightedRandom)));
    }

    public override ColorEnum Color => ColorEnum.BrightWhite;
    public override string Name => "The Dagger 'Hope'";
    public override int Ac => 0;
    public override int Cost => 11000;
    public override int Dd => 1;
    public override int Ds => 4;
    public override int Level => 3;
    public override int Rarity => 10;
    public override int ToA => 0;
    public override int ToD => 6;
    public override int ToH => 4;
    public override int Weight => 12;
}
