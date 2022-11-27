using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using AngbandOS.Core.ItemCategories;

using AngbandOS.Core.ItemClasses;
using AngbandOS.Projection;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class MorningStarFirestarterFixedArtifact : BaseFixedArtifact, IActivatible
{
    // Firestarter does fire ball
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("Your morning star rages in fire...");
        TargetEngine targetEngine = new TargetEngine(saveGame);
        if (!targetEngine.GetDirectionWithAim(out int dir))
        {
            return;
        }
        saveGame.FireBall(new ProjectFire(saveGame), dir, 72, 3);
        item.RechargeTimeLeft = 100;
    }
    public string DescribeActivationEffect() => "large fire ball (72) every 100 turns";
    public override ItemClass BaseItemCategory => new HaftedMorningStar();

    public override char Character => '\\';
    public override Colour Colour => Colour.Black;
    public override string Name => "The Morning Star 'Firestarter'";
    public override int Ac => 0;
    public override bool Activate => true;
    public override bool BrandFire => true;
    public override int Cost => 35000;
    public override int Dd => 2;
    public override int Ds => 6;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.MorningStarFirestarter;
    public override string FriendlyName => "'Firestarter'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 20;
    public override bool Lightsource => true;
    public override int Pval => 0;
    public override int Rarity => 15;
    public override bool ResFire => true;
    public override bool ShowMods => true;
    public override int ToA => 2;
    public override int ToD => 7;
    public override int ToH => 5;
    public override int Weight => 150;
}
