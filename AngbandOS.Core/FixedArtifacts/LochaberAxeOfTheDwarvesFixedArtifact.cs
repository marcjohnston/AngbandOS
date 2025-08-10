// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class LochaberAxeOfTheDwarvesFixedArtifact : FixedArtifact
{
    private LochaberAxeOfTheDwarvesFixedArtifact(Game game) : base(game) { }
    protected override string BaseItemFactoryName => nameof(LochaberAxePolearmWeaponItemFactory);
    public override ColorEnum Color => ColorEnum.Black;
    public override string Name => "The Lochaber Axe of the Dwarves";
    public override int Level => 30;
    public override int Rarity => 8;
    public override int ToA => 0;
    public override int ToD => 17;
    public override int ToH => 12;
}
