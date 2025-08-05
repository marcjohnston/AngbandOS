// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class GreatAxeOfTheTrollsFixedArtifact : FixedArtifact
{
    private GreatAxeOfTheTrollsFixedArtifact(Game game) : base(game) { }
    protected override string BaseItemFactoryName => nameof(GreatAxePolearmWeaponItemFactory);
    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "The Great Axe of the Trolls";
    public override int Cost => 200000;
    public override int Dd => 4;
    public override int Ds => 4;
    public override int Level => 30;
    public override int Rarity => 120;
    public override int ToA => 8;
    public override int ToD => 18;
    public override int ToH => 15;
}
