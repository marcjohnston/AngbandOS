// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class PowerDragonScaleMailBladeturnerFixedArtifact : FixedArtifact
{
    private PowerDragonScaleMailBladeturnerFixedArtifact(Game game) : base(game) { }
    protected override string BaseItemFactoryName => nameof(PowerDragonScaleMailItemFactory);
    public override ColorEnum Color => ColorEnum.Purple;
    public override string Name => "The Power Dragon Scale Mail 'Bladeturner'";
    public override int Cost => 500000;
    public override int Dd => 2;
    public override int Ds => 4;
    public override int Level => 95;
    public override int Rarity => 3;
    public override int ToA => 35;
    public override int ToD => 0;
    public override int ToH => -8;
    public override int Weight => 600;
}
