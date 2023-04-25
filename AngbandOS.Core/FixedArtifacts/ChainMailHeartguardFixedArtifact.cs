namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class ChainMailHeartguardFixedArtifact : FixedArtifact
{
    private readonly ItemFactory _baseItemCategory;
    private ChainMailHeartguardFixedArtifact(SaveGame saveGame)
    {
        _baseItemCategory = saveGame.SingletonRepository.ItemFactories.Get<HardArmorChainMail>();
    }

    public override void ApplyResistances(SaveGame saveGame, Item item)
    {
        IArtifactBias artifactBias = null;
        item.ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
    }
    public override ItemFactory BaseItemCategory => _baseItemCategory;

    public override char Character => '[';
    public override Colour Colour => Colour.Grey;
    public override string Name => "The Chain Mail 'Heartguard'";
    public override int Ac => 14;
    public override bool Cha => true;
    public override int Cost => 32000;
    public override int Dd => 1;
    public override int Ds => 4;
    public override string FriendlyName => "'Heartguard'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 20;
    public override int Pval => 2;
    public override int Rarity => 3;
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override bool ResNexus => true;
    public override bool ResShards => true;
    public override bool Str => true;
    public override int ToA => 15;
    public override int ToD => 0;
    public override int ToH => -2;
    public override int Weight => 220;
}
