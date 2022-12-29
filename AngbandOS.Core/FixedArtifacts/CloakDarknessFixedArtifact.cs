using AngbandOS.Core.ItemCategories;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class CloakDarknessFixedArtifact : BaseFixedArtifact, IActivatible
{
    private readonly ItemClass _baseItemCategory;
    private CloakDarknessFixedArtifact(SaveGame saveGame)
    {
        _baseItemCategory = saveGame.SingletonRepository.ItemCategories.Get<Cloak>();
    }

    // Darkness sends monsters to sleep
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("Your cloak glows deep blue...");
        saveGame.SleepMonstersTouch();
        item.RechargeTimeLeft = 55;
    }
    public string DescribeActivationEffect() => "Sleep II every 55 turns";
    public override ItemClass BaseItemCategory => _baseItemCategory;

    public override char Character => '(';
    public override Colour Colour => Colour.Green;
    public override string Name => "The Cloak 'Darkness'";
    public override int Ac => 1;
    public override bool Activate => true;
    public override int Cost => 13000;
    public override int Dd => 0;
    public override int Ds => 0;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.CloakDarkness;
    public override string FriendlyName => "'Darkness'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool Int => true;
    public override int Level => 5;
    public override int Pval => 2;
    public override int Rarity => 45;
    public override bool ResAcid => true;
    public override bool ResDark => true;
    public override bool Stealth => true;
    public override int ToA => 4;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 10;
    public override bool Wis => true;
}
