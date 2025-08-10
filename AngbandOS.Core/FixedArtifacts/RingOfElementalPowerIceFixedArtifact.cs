// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class RingOfElementalPowerIceFixedArtifact : FixedArtifact
{
    public override bool DisableStomp => true;
    private RingOfElementalPowerIceFixedArtifact(Game game) : base(game) { }
    protected override string BaseItemFactoryName => nameof(NenyaRingItemFactory);
    public override string Name => "The Ring of Elemental Power (Ice)";
    public override bool HasOwnType => true;
    public override int Level => 80;
    public override int Rarity => 40;
    public override int ToA => 0;
    public override int ToD => 11;
    public override int ToH => 11;
}
