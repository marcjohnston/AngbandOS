// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class TwoHandedSwordDragonslayerFixedArtifact : FixedArtifact
{
    private ItemFactory _baseItemCategory;
    private TwoHandedSwordDragonslayerFixedArtifact(SaveGame saveGame) : base(saveGame) { }

    public override void Loaded()
    {
        _baseItemCategory = SaveGame.SingletonRepository.ItemFactories.Get<SwordTwoHandedSword>();
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
            item.BonusPowerSubType= SaveGame.SingletonRepository.Activations.ToWeightedRandom().Choose();
        }
    }
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<VerticalBarSymbol>();
    public override ColourEnum Colour => ColourEnum.BrightWhite;
    public override string Name => "The Two-Handed Sword 'Dragonslayer'";
    public override int Ac => 0;
    public override int Cost => 100000;
    public override int Dd => 3;
    public override int Ds => 6;
    public override bool FreeAct => true;
    public override string FriendlyName => "'Dragonslayer'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool KillDragon => true;
    public override int Level => 30;
    public override int Pval => 2;
    public override int Rarity => 30;
    public override bool Regen => true;
    public override bool ShowMods => true;
    public override bool SlayTroll => true;
    public override bool SlowDigest => true;
    public override bool Str => true;
    public override int ToA => 0;
    public override int ToD => 17;
    public override int ToH => 13;
    public override int Weight => 200;
}