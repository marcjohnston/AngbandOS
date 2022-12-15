using AngbandOS.Core.Interface;
using AngbandOS.Core.ItemCategories;
using AngbandOS.Core.ItemClasses;
using AngbandOS.Enumerations;
using AngbandOS.Projection;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class LongSwordExcaliburFixedArtifact : BaseFixedArtifact, IActivatible
{
    // Excalibur shoots a frost ball
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("Your sword glows an intense blue...");
        if (!saveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        saveGame.FireBall(new ProjectCold(saveGame), dir, 100, 2);
        item.RechargeTimeLeft = 300;
    }
    public string DescribeActivationEffect() => "frost ball (100) every 300 turns";
    public override ItemClass BaseItemCategory => new SwordLongSword();

    public override char Character => '|';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "The Long Sword 'Excalibur'";
    public override int Ac => 0;
    public override bool Activate => true;
    public override bool BrandCold => true;
    public override int Cost => 300000;
    public override int Dd => 4;
    public override int Ds => 5;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.SwordExcalibur;
    public override bool FreeAct => true;
    public override string FriendlyName => "'Excalibur'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 20;
    public override bool Lightsource => true;
    public override int Pval => 10;
    public override int Rarity => 120;
    public override bool Regen => true;
    public override bool ResCold => true;
    public override bool ResLight => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayDemon => true;
    public override bool SlayEvil => true;
    public override bool SlayTroll => true;
    public override bool SlayUndead => true;
    public override bool SlowDigest => true;
    public override bool Speed => true;
    public override int ToA => 0;
    public override int ToD => 25;
    public override int ToH => 22;
    public override int Weight => 130;
}
