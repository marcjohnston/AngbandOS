// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class RingOfElementalPowerStormFixedArtifact : FixedArtifact
{
    private RingOfElementalPowerStormFixedArtifact(Game game) : base(game) { }
    protected override string BaseItemFactoryName => nameof(VilyaRingItemFactory);
    public override string Name => "The Ring of Elemental Power (Storm)";
    public override int Cost => 300000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override bool HasOwnType => true;
    public override int Level => 90;
    public override int Rarity => 50;
    public override int ToA => 0;
    public override int ToD => 12;
    public override int ToH => 12;
    public override int Weight => 2;
}
