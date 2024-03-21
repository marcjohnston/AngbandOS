// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class BastardSwordSelfSlayerFixedArtifact : FixedArtifact
{
    private BastardSwordSelfSlayerFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(BastardSwordSwordWeaponItemFactory);


    public override ColorEnum Color => ColorEnum.BrightWhite;
    public override string Name => "The Bastard Sword 'Selfslayer'";
    public override int Ac => 0;
    public override bool Aggravate => true;
    public override bool Con => true;
    public override int Cost => 100000;
    public override bool Cursed => true;
    public override int Dd => 5;
    public override int Ds => 4;
    public override string FriendlyName => "'Selfslayer'";
    public override bool HeavyCurse => true;
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool KillDragon => true;
    public override int Level => 30;
    public override int Pval => 5;
    public override int Rarity => 15;
    public override bool ResDisen => true;
    public override bool ShowMods => true;
    public override bool SlayDemon => true;
    public override bool SlayEvil => true;
    public override bool SlayTroll => true;
    public override int ToA => 0;
    public override int ToD => 20;
    public override int ToH => -20;
    public override int Weight => 140;
}
