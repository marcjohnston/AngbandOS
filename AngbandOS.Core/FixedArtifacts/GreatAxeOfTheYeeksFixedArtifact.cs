// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class GreatAxeOfTheYeeksFixedArtifact : FixedArtifact
{
    private GreatAxeOfTheYeeksFixedArtifact(Game game) : base(game) { }
    protected override string BaseItemFactoryName => nameof(GreatAxePolearmWeaponItemFactory);
    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "The Great Axe of the Yeeks";
    public override int Level => 30;
    public override int Rarity => 90;
    public override int ToA => 15;
    public override int ToD => 20;
    public override int ToH => 10;
}
