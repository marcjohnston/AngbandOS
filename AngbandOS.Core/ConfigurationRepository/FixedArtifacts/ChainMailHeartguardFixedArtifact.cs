// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class ChainMailHeartguardFixedArtifact : FixedArtifact
{
    private ItemFactory _baseItemCategory;
    private ChainMailHeartguardFixedArtifact(SaveGame saveGame) : base(saveGame) { }

    public override void Loaded()
    {
        _baseItemCategory = SaveGame.SingletonRepository.ItemFactories.Get<ChainMailHardArmorItemFactory>();
    }


    public override void ApplyResistances(SaveGame saveGame, Item item)
    {
        IArtifactBias artifactBias = null;
        item.ApplyRandomResistance(ref artifactBias, SaveGame.Rng.DieRoll(22) + 16);
    }
    public override ItemFactory BaseItemCategory => _baseItemCategory;

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<OpenBraceSymbol>();
    public override ColourEnum Colour => ColourEnum.Grey;
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