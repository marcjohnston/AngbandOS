namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class VorpalAndWarriorArtifactBiasItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(Vorpal1InChanceAttribute), "2"),
        (nameof(VorpalExtraAttacks1InChanceAttribute), "2"),
        (nameof(ValueAttribute), "5000"),
    };
    public override string? ArtifactBiasWeightedRandomBindingKey => nameof(Warrior1In9ArtifactBiasWeightedRandom);
    public override string[]? ApplicableItemFactoryBindingKeys => new string[]
    {
        nameof(BastardSwordWeaponItemFactory),
        nameof(BladeOfChaosWeaponItemFactory),
        nameof(BroadSwordWeaponItemFactory),
        nameof(BrokenDaggerWeaponItemFactory),
        nameof(BrokenSwordWeaponItemFactory),
        nameof(CutlassWeaponItemFactory),
        nameof(DaggerWeaponItemFactory),
        nameof(ExecutionersSwordWeaponItemFactory),
        nameof(KatanaWeaponItemFactory),
        nameof(LongSwordWeaponItemFactory),
        nameof(MainGaucheWeaponItemFactory),
        nameof(RapierWeaponItemFactory),
        nameof(SabreWeaponItemFactory),
        nameof(ScimitarWeaponItemFactory),
        nameof(ShortSwordWeaponItemFactory),
        nameof(SmallSwordWeaponItemFactory),
        nameof(TulwarWeaponItemFactory),
        nameof(TwoHandedSwordWeaponItemFactory)
    };
}
