// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class BroadSwordBlackIceFixedArtifact : FixedArtifact
{
    private ItemFactory _baseItemCategory;
    private BroadSwordBlackIceFixedArtifact(SaveGame saveGame) : base(saveGame) { }

    public override void Loaded()
    {
        _baseItemCategory = SaveGame.SingletonRepository.ItemFactories.Get<SwordBroadSword>();
    }


    public override ItemFactory BaseItemCategory => _baseItemCategory;

    public override void ApplyResistances(SaveGame saveGame, Item item)
    {
        if (SaveGame.Rng.DieRoll(2) == 1)
        {
            IArtifactBias artifactBias = null;
            item.ApplyRandomResistance(ref artifactBias, SaveGame.Rng.DieRoll(22) + 16);
        }
        else
        {
            item.BonusPowerType = RareItemTypeEnum.SpecialAbility;
            item.BonusPowerSubType = SaveGame.SingletonRepository.Activations.ToWeightedRandom().Choose();
        }
    }
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<VerticalBarSymbol>();
    public override ColourEnum Colour => ColourEnum.BrightWhite;
    public override string Name => "The Broad Sword 'Black Ice'";
    public override int Ac => 0;
    public override bool BrandCold => true;
    public override int Cost => 40000;
    public override int Dd => 2;
    public override int Ds => 5;
    public override string FriendlyName => "'Black Ice'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 20;
    public override bool Lightsource => true;
    public override int Pval => 3;
    public override int Rarity => 20;
    public override bool ResCold => true;
    public override bool ShowMods => true;
    public override bool SlayEvil => true;
    public override bool SlayOrc => true;
    public override bool SlowDigest => true;
    public override bool Stealth => true;
    public override int ToA => 0;
    public override int ToD => 15;
    public override int ToH => 10;
    public override int Weight => 150;
}