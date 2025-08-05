// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class ScytheOfGharneFixedArtifact : FixedArtifact
{
    private ScytheOfGharneFixedArtifact(Game game) : base(game) { }
    protected override string BaseItemFactoryName => nameof(ScythePolearmWeaponItemFactory);
    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "The Scythe of G'harne";
    public override int Cost => 18000;
    public override int Dd => 5;
    public override int Ds => 3;
    public override int Level => 40;
    public override int Rarity => 8;
    public override int ToA => 10;
    public override int ToD => 8;
    public override int ToH => 8;
}
