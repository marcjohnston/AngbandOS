// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class LightCrossbowOfDeathFixedArtifact : FixedArtifact
{
    private LightCrossbowOfDeathFixedArtifact(Game game) : base(game) { }
    protected override string BaseItemFactoryName => nameof(LightCrossbowRangedWeaponItemFactory);
    public string DescribeActivationEffect => "fire branding of bolts every 999 turns";
    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "The Light Crossbow of Death";
    public override int Ac => 0;
    public override int Cost => 50000;
    public override int Dd => 0;
    public override int Ds => 0;
    public override int Level => 50;
    public override int Rarity => 25;
    public override int ToA => 0;
    public override int ToD => 14;
    public override int ToH => 10;
    public override int Weight => 110;
}
