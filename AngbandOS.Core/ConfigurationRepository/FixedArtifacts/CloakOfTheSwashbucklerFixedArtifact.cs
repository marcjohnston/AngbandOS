// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class CloakOfTheSwashbucklerFixedArtifact : FixedArtifact, IFixedArtifactActivatible
{
    private ItemFactory _baseItemCategory;
    private CloakOfTheSwashbucklerFixedArtifact(SaveGame saveGame) : base(saveGame) { }

    public override void Loaded()
    {
        _baseItemCategory = SaveGame.SingletonRepository.ItemFactories.Get<ClothCloakCloakArmorItemFactory>();
    }


    // Swashbuckler recharges items
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("Your cloak glows bright yellow...");
        saveGame.Recharge(60);
        item.RechargeTimeLeft = 70;
    }
    public string DescribeActivationEffect() => "recharge item I every 70 turns";
    public override void ApplyResistances(SaveGame saveGame, Item item)
    {
        item.BonusPowerType = RareItemTypeEnum.SpecialAbility;
        item.BonusPowerSubType= SaveGame.SingletonRepository.Activations.ToWeightedRandom().Choose();
    }
    public override ItemFactory BaseItemCategory => _baseItemCategory;

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<OpenParenthesisSymbol>();
    public override ColourEnum Colour => ColourEnum.Green;
    public override string Name => "The Cloak of the Swashbuckler";
    public override int Ac => 1;
    public override bool Activate => true;
    public override bool Cha => true;
    public override int Cost => 35000;
    public override int Dd => 0;
    public override bool Dex => true;
    public override int Ds => 0;
    public override bool FreeAct => true;
    public override string FriendlyName => "of the Swashbuckler";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 10;
    public override int Pval => 3;
    public override int Rarity => 90;
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResFire => true;
    public override int ToA => 18;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 10;
}