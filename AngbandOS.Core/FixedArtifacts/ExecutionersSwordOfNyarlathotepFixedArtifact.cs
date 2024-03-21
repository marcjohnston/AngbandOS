// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class ExecutionersSwordOfNyarlathotepFixedArtifact : FixedArtifact
{
    private ExecutionersSwordOfNyarlathotepFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(ExecutionersSwordWeaponItemFactory);
    public override ColorEnum Color => ColorEnum.Red;
    public override string Name => "The Executioner's Sword of Nyarlathotep";
    public override int Ac => 0;
    public override bool BrandPois => true;
    public override int Cost => 111000;
    public override int Dd => 4;
    public override int Ds => 5;
    public override string FriendlyName => "of Nyarlathotep";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 40;
    public override int Pval => 0;
    public override int Rarity => 15;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayDragon => true;
    public override bool SlayEvil => true;
    public override bool SlayGiant => true;
    public override bool SlayOrc => true;
    public override bool SlayTroll => true;
    public override bool SlayUndead => true;
    public override int ToA => 0;
    public override int ToD => 19;
    public override int ToH => 18;
    public override bool Vorpal => true;
    public override int Weight => 260;
}
