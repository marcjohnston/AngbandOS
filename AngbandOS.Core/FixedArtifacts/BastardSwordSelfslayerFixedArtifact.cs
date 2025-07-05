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
    public override int Cost => 100000;
    public override int Dd => 5;
    public override int Ds => 4;
    public override int Level => 30;
    public override int Rarity => 15;
    public override int ToA => 0;
    public override int ToD => 20;
    public override int ToH => -20;
    public override int Weight => 140;
}
