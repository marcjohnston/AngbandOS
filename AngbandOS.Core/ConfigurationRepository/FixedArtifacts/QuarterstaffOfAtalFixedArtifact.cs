// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class QuarterstaffOfAtalFixedArtifact : FixedArtifact, IFixedArtifactActivatible
{
    private ItemFactory _baseItemCategory;
    private QuarterstaffOfAtalFixedArtifact(SaveGame saveGame) : base(saveGame) { }

    public override void Loaded()
    {
        _baseItemCategory = SaveGame.SingletonRepository.ItemFactories.Get<HaftedQuarterstaff>();
    }


    // Atal does full identify
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("Your quarterstaff glows brightly...");
        saveGame.DetectAll();
        saveGame.Probing();
        saveGame.IdentifyFully();
        item.RechargeTimeLeft = 1000;
    }
    public override void ApplyResistances(SaveGame saveGame, Item item)
    {
        item.BonusPowerType = RareItemTypeEnum.SpecialAbility;
        item.BonusPowerSubType= SaveGame.SingletonRepository.Activations.ToWeightedRandom().Choose();
    }
    public string DescribeActivationEffect() => "probing, detection and full id  every 1000 turns";
    public override ItemFactory BaseItemCategory => _baseItemCategory;

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<BackSlashSymbol>();
    public override ColourEnum Colour => ColourEnum.BrightBrown;
    public override string Name => "The Quarterstaff of Atal";
    public override int Ac => 0;
    public override bool Activate => true;
    public override bool BrandFire => true;
    public override bool Cha => true;
    public override int Cost => 140000;
    public override int Dd => 2;
    public override int Ds => 9;
    public override string FriendlyName => "of Atal";
    public override bool HideType => true;
    public override bool HoldLife => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool Int => true;
    public override int Level => 30;
    public override bool Lightsource => true;
    public override int Pval => 4;
    public override int Rarity => 105;
    public override bool ResFire => true;
    public override bool ResNether => true;
    public override bool Search => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayEvil => true;
    public override bool SlayOrc => true;
    public override bool SlayTroll => true;
    public override int ToA => 0;
    public override int ToD => 13;
    public override int ToH => 10;
    public override int Weight => 150;
    public override bool Wis => true;
}