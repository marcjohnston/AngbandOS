// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class SpearOfDestinyFixedArtifact : FixedArtifact, IFixedArtifactActivatible
{
    private SpearOfDestinyFixedArtifact(SaveGame saveGame) : base(saveGame) { }

    protected override string BaseItemFactoryName => nameof(SpearPolearmWeaponItemFactory);

    // Destiny does rock to mud
    public void ActivateItem(Item item)
    {
        SaveGame.MsgPrint("Your spear pulsates...");
        if (!SaveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        SaveGame.WallToMud(dir);
        item.RechargeTimeLeft = 5;
    }
    public string DescribeActivationEffect() => "stone to mud every 5 turns";

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(ForwardSlashSymbol));
    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "The Spear of Destiny";
    public override int Ac => 0;
    public override bool Activate => true;
    public override bool Blessed => true;
    public override bool BrandFire => true;
    public override int Cost => 77777;
    public override int Dd => 1;
    public override int Ds => 6;
    public override bool Feather => true;
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
