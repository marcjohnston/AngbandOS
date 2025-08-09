// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class RingOfSetFixedArtifact : FixedArtifact
{
    private RingOfSetFixedArtifact(Game game) : base(game) { }
    public override bool DisableStomp => true;
    protected override string BaseItemFactoryName => nameof(PowerRingItemFactory);
    public override ColorEnum Color => ColorEnum.Yellow;
    public override string Name => "The Ring of Set";
    public override int Ds => 1;
    public override bool HasOwnType => true;
    public override int Level => 100;
    public override int Rarity => 100;
    public override int ToA => 0;
    public override int ToD => 15;
    public override int ToH => 15;
}
