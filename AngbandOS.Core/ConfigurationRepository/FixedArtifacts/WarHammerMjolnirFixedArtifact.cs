// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class WarHammerMjolnirFixedArtifact : FixedArtifact
{
    private ItemFactory _baseItemCategory;
    private WarHammerMjolnirFixedArtifact(SaveGame saveGame) : base(saveGame) { }

    public override void Loaded()
    {
        _baseItemCategory = SaveGame.SingletonRepository.ItemFactories.Get<HaftedWarHammer>();
    }


    public override ItemFactory BaseItemCategory => _baseItemCategory;

    public override void ApplyResistances(SaveGame saveGame, Item item)
    {
        item.BonusPowerType = RareItemTypeEnum.SpecialAbility;
        item.BonusPowerSubType= SaveGame.SingletonRepository.Activations.ToWeightedRandom().Choose();

        IArtifactBias artifactBias = null;
        item.ApplyRandomResistance(ref artifactBias, SaveGame.Rng.DieRoll(22) + 16);
    }
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<BackSlashSymbol>();
    public override ColourEnum Colour => ColourEnum.Black;
    public override string Name => "The War Hammer 'Mjolnir'";
    public override int Ac => 0;
    public override bool BrandElec => true;
    public override int Cost => 250000;
    public override int Dd => 9;
    public override int Ds => 3;
    public override bool FreeAct => true;
    public override string FriendlyName => "'Mjolnir'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool KillDragon => true;
    public override int Level => 40;
    public override int Pval => 4;
    public override int Rarity => 75;
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override bool ResNexus => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayDemon => true;
    public override bool SlayEvil => true;
    public override bool SlayUndead => true;
    public override int ToA => 5;
    public override int ToD => 21;
    public override int ToH => 19;
    public override int Weight => 120;
    public override bool Wis => true;
}