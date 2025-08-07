// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class BladeOfChaosDoomcallerFixedArtifact : FixedArtifact
{
    private BladeOfChaosDoomcallerFixedArtifact(Game game) : base(game) { }
    protected override string BaseItemFactoryName => nameof(BladeOfChaosWeaponItemFactory);
    public override ColorEnum Color => ColorEnum.Purple;
    public override string Name => "The Blade of Chaos 'Doomcaller'";
    public override int Dd => 6;
    public override int Ds => 5;
    public override int Level => 70;
    public override int Rarity => 25;
    public override int ToA => -50;
    public override int ToD => 28;
    public override int ToH => 18;
}
