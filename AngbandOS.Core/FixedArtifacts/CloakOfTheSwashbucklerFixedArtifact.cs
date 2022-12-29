using AngbandOS.ActivationPowers;
using AngbandOS.Core.ItemCategories;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class CloakOfTheSwashbucklerFixedArtifact : BaseFixedArtifact, IActivatible
{
    private readonly ItemClass _baseItemCategory;
    private CloakOfTheSwashbucklerFixedArtifact(SaveGame saveGame)
    {
        _baseItemCategory = saveGame.SingletonRepository.ItemCategories.Get<Cloak>();
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
        item.BonusPowerType = Enumerations.RareItemType.SpecialAbility;
        item.BonusPowerSubType = ActivationPowerManager.GetRandom();
    }
    public override ItemClass BaseItemCategory => _baseItemCategory;

    public override char Character => '(';
    public override Colour Colour => Colour.Green;
    public override string Name => "The Cloak of the Swashbuckler";
    public override int Ac => 1;
    public override bool Activate => true;
    public override bool Cha => true;
    public override int Cost => 35000;
    public override int Dd => 0;
    public override bool Dex => true;
    public override int Ds => 0;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.CloakOfTheSwashbuckler;
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
