using AngbandOS.Core.Interface;
using AngbandOS.Core.ItemCategories;
using AngbandOS.Core.ItemClasses;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class SpearOfDestinyFixedArtifact : BaseFixedArtifact, IActivatible
{
    // Destiny does rock to mud
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("Your spear pulsates...");
        if (!saveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        saveGame.WallToMud(dir);
        item.RechargeTimeLeft = 5;
    }
    public string DescribeActivationEffect() => "stone to mud every 5 turns";
    public override ItemClass BaseItemCategory => new PolearmSpear();

    public override char Character => '/';
    public override Colour Colour => Colour.Grey;
    public override string Name => "The Spear of Destiny";
    public override int Ac => 0;
    public override bool Activate => true;
    public override bool Blessed => true;
    public override bool BrandFire => true;
    public override int Cost => 77777;
    public override int Dd => 1;
    public override int Ds => 6;
    public override bool Feather => true;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.SpearOfDestiny;
    public override string FriendlyName => "of Destiny";
    public override bool HideType => true;
    public override bool HoldLife => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool Infra => true;
    public override bool Int => true;
    public override int Level => 15;
    public override bool Lightsource => true;
    public override int Pval => 4;
    public override int Rarity => 45;
    public override bool ResFear => true;
    public override bool ResFire => true;
    public override bool ResLight => true;
    public override bool Search => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayDemon => true;
    public override bool SlayDragon => true;
    public override bool SlayEvil => true;
    public override bool SlayGiant => true;
    public override bool SlayUndead => true;
    public override int ToA => 0;
    public override int ToD => 15;
    public override int ToH => 15;
    public override int Weight => 50;
    public override bool Wis => true;
}
