using AngbandOS.Core.ItemCategories;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class MaceThunderFixedArtifact : BaseFixedArtifact, IActivatible
{
    private readonly ItemClass _baseItemCategory;
    private MaceThunderFixedArtifact(SaveGame saveGame)
    {
        _baseItemCategory = saveGame.SingletonRepository.ItemCategories.Get<HaftedMace>();
    }

    // Thunder does haste
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("Your mace glows bright green...");
        if (saveGame.Player.TimedHaste == 0)
        {
            saveGame.Player.SetTimedHaste(Program.Rng.DieRoll(20) + 20);
        }
        else
        {
            saveGame.Player.SetTimedHaste(saveGame.Player.TimedHaste + 5);
        }
        item.RechargeTimeLeft = Program.Rng.RandomLessThan(100) + 100;
    }
    public string DescribeActivationEffect() => "haste self (20+d20 turns) every 100+d100 turns";
    public override ItemClass BaseItemCategory => _baseItemCategory;

    public override char Character => '\\';
    public override Colour Colour => Colour.Black;
    public override string Name => "The Mace 'Thunder'";
    public override int Ac => 0;
    public override bool Activate => true;
    public override bool BrandElec => true;
    public override int Cost => 50000;
    public override int Dd => 3;
    public override int Ds => 4;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.MaceThunder;
    public override string FriendlyName => "'Thunder'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ImElec => true;
    public override bool KillDragon => true;
    public override int Level => 20;
    public override int Pval => 0;
    public override int Rarity => 15;
    public override bool ShowMods => true;
    public override int ToA => 0;
    public override int ToD => 12;
    public override int ToH => 12;
    public override int Weight => 200;
}
