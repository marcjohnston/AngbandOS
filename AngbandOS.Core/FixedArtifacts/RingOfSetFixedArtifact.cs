using AngbandOS.ActivationPowers;
using AngbandOS.Core.ItemCategories;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class RingOfSetFixedArtifact : BaseFixedArtifact, IActivatible
{
    private readonly ItemClass _baseItemCategory;
    private RingOfSetFixedArtifact(SaveGame saveGame)
    {
        _baseItemCategory = saveGame.SingletonRepository.ItemCategories.Get<RingPower>();
    }

    // Ring of Set has a random effect
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("The ring glows intensely black...");
        if (!saveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        saveGame.RingOfSetPower(dir);
        item.RechargeTimeLeft = Program.Rng.RandomLessThan(450) + 450;
    }
    public string DescribeActivationEffect() => "bizarre things every 450+d450 turns";
    public override void ApplyResistances(SaveGame saveGame, Item item)
    {
        item.BonusPowerType = Enumerations.RareItemType.SpecialAbility;
        item.BonusPowerSubType = ActivationPowerManager.GetRandom();

        IArtifactBias artifactBias = null;
        item.ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
    }
    public override ItemClass BaseItemCategory => _baseItemCategory;

    public override char Character => '=';
    public override Colour Colour => Colour.Yellow;
    public override string Name => "The Ring of Set";
    public override int Ac => 0;
    public override bool Activate => true;
    public override bool Aggravate => true;
    public override bool Cha => true;
    public override bool Con => true;
    public override int Cost => 5000000;
    public override bool Cursed => true;
    public override int Dd => 1;
    public override bool Dex => true;
    public override bool DrainExp => true;
    public override bool DreadCurse => true;
    public override int Ds => 1;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.RingOfSet;
    public override string FriendlyName => "of Set";
    public override bool HasOwnType => true;
    public override bool HeavyCurse => true;
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ImAcid => true;
    public override bool ImCold => true;
    public override bool ImElec => true;
    public override bool ImFire => true;
    public override bool InstaArt => true;
    public override bool Int => true;
    public override int Level => 100;
    public override bool PermaCurse => true;
    public override int Pval => 5;
    public override int Rarity => 100;
    public override bool Regen => true;
    public override bool SeeInvis => true;
    public override bool Speed => true;
    public override bool Str => true;
    public override bool SustCha => true;
    public override bool SustCon => true;
    public override bool SustDex => true;
    public override bool SustInt => true;
    public override bool SustStr => true;
    public override bool SustWis => true;
    public override int ToA => 0;
    public override int ToD => 15;
    public override int ToH => 15;
    public override int Weight => 2;
    public override bool Wis => true;
}
