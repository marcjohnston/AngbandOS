using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using AngbandOS.Core.ItemCategories;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class CloakOfBarzaiFixedArtifact : BaseFixedArtifact, IActivatible
{
    // Cloak of Barzai gives resistances
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("Your cloak glows many colours...");
        saveGame.Player.SetTimedAcidResistance(saveGame.Player.TimedAcidResistance + Program.Rng.DieRoll(20) + 20);
        saveGame.Player.SetTimedLightningResistance(saveGame.Player.TimedLightningResistance + Program.Rng.DieRoll(20) + 20);
        saveGame.Player.SetTimedFireResistance(saveGame.Player.TimedFireResistance + Program.Rng.DieRoll(20) + 20);
        saveGame.Player.SetTimedColdResistance(saveGame.Player.TimedColdResistance + Program.Rng.DieRoll(20) + 20);
        saveGame.Player.SetTimedPoisonResistance(saveGame.Player.TimedPoisonResistance + Program.Rng.DieRoll(20) + 20);
        item.RechargeTimeLeft = 111;
    }
    public string DescribeActivationEffect() => "resistance (20+d20 turns) every 111 turns";
    public override ItemClass BaseItemCategory => new Cloak();

    public override char Character => '(';
    public override Colour Colour => Colour.Green;
    public override string Name => "The Cloak of Barzai";
    public override int Ac => 1;
    public override bool Activate => true;
    public override int Cost => 10000;
    public override int Dd => 0;
    public override int Ds => 0;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.CloakOfBarzai;
    public override string FriendlyName => "of Barzai";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 5;
    public override int Pval => 0;
    public override int Rarity => 45;
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override bool ResPois => true;
    public override int ToA => 15;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 10;
}