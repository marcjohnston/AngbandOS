using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using AngbandOS.Core.ItemCategories;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class BattleAxeSpleenSlicerFixedArtifact : BaseFixedArtifact, IActivatible
{
    // Spleens Slicer heals you
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("Your battle axe radiates deep purple...");
        saveGame.Player.RestoreHealth(Program.Rng.DiceRoll(4, 8));
        saveGame.Player.SetTimedBleeding((saveGame.Player.TimedBleeding / 2) - 50);
        item.RechargeTimeLeft = Program.Rng.RandomLessThan(3) + 3;
    }
    public string DescribeActivationEffect() => "cure wounds (4d7) every 3+d3 turns";
    public override ItemClass BaseItemCategory => new PolearmBattleAxe();

    public override char Character => '/';
    public override Colour Colour => Colour.Grey;
    public override string Name => "The Battle Axe 'Spleen Slicer'";
    public override int Ac => 0;
    public override bool Activate => true;
    public override int Cost => 21000;
    public override int Dd => 2;
    public override bool Dex => true;
    public override int Ds => 8;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.AxeSpleenSlicer;
    public override string FriendlyName => "'Spleen Slicer'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 30;
    public override int Pval => 1;
    public override int Rarity => 15;
    public override bool ShowMods => true;
    public override bool SlayOrc => true;
    public override bool SlayTroll => true;
    public override bool Str => true;
    public override int ToA => 0;
    public override int ToD => 3;
    public override int ToH => 4;
    public override int Weight => 170;
}