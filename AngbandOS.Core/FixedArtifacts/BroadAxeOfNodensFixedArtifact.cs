// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class BroadAxeOfNodensFixedArtifact : FixedArtifact
{
    private BroadAxeOfNodensFixedArtifact(Game game) : base(game) { }
    protected override string BaseItemFactoryName => nameof(BroadAxePolearmWeaponItemFactory);
    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "The Broad Axe of Nodens";
    public override int Cost => 50000;
    public override int Dd => 2;
    public override int Ds => 6;
    public override int Level => 20;
    public override int Rarity => 8;
    public override int ToA => 0;
    public override int ToD => 19;
    public override int ToH => 13;
    public override int Weight => 160;
}
