using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using AngbandOS.Core.ItemCategories;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class RingOfBastFixedArtifact : BaseFixedArtifact, IActivatible
{
    // Ring of Bast hastes you
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("The ring glows brightly...");
        if (saveGame.Player.TimedHaste == 0)
        {
            saveGame.Player.SetTimedHaste(Program.Rng.DieRoll(75) + 75);
        }
        else
        {
            saveGame.Player.SetTimedHaste(saveGame.Player.TimedHaste + 5);
        }
        item.RechargeTimeLeft = Program.Rng.RandomLessThan(150) + 150;
    }
    public string DescribeActivationEffect() => "haste self (75+d75 turns) every 150+d150 turns";
    public override ItemClass BaseItemCategory => new RingTulkas();

    public override char Character => '=';
    public override string Name => "The Ring of Bast";
    public override int Ac => 0;
    public override bool Activate => true;
    public override bool Con => true;
    public override int Cost => 175000;
    public override int Dd => 0;
    public override bool Dex => true;
    public override int Ds => 0;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.RingOfBast;
    public override string FriendlyName => "of Bast";
    public override bool HasOwnType => true;
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool InstaArt => true;
    public override int Level => 70;
    public override int Pval => 4;
    public override int Rarity => 50;
    public override bool Speed => true;
    public override bool Str => true;
    public override int ToA => 0;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 2;
}