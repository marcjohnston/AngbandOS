namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class SetOfCestiOfCombatFixedArtifact : FixedArtifact, IActivatible
{
    private readonly ItemFactory _baseItemCategory;
    private SetOfCestiOfCombatFixedArtifact(SaveGame saveGame) : base(saveGame)
    {
        _baseItemCategory = saveGame.SingletonRepository.ItemFactories.Get<GlovesSetOfCesti>();
    }

    // Cesti shoot arrows
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("Your cesti grows magical spikes...");
        if (!saveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        saveGame.FireBolt(saveGame.SingletonRepository.Projectiles.Get<ArrowProjectile>(), dir, 150);
        item.RechargeTimeLeft = Program.Rng.RandomLessThan(90) + 90;
    }
    public override void ApplyResistances(SaveGame saveGame, Item item)
    {
        item.BonusPowerType = RareItemTypeEnum.SpecialAbility;
        item.BonusPowerSubType= SaveGame.SingletonRepository.Activations.ToWeightedRandom().Choose();
    }
    public string DescribeActivationEffect() => "a magical arrow (150) every 90+d90 turns";
    public override ItemFactory BaseItemCategory => _baseItemCategory;

    public override char Character => ']';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "The Set of Cesti of Combat";
    public override int Ac => 5;
    public override bool Activate => true;
    public override int Cost => 110000;
    public override int Dd => 1;
    public override bool Dex => true;
    public override int Ds => 1;
    public override bool FreeAct => true;
    public override string FriendlyName => "of Combat";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 40;
    public override int Pval => 4;
    public override int Rarity => 15;
    public override bool ResAcid => true;
    public override bool ShowMods => true;
    public override int ToA => 20;
    public override int ToD => 10;
    public override int ToH => 10;
    public override int Weight => 40;
}
