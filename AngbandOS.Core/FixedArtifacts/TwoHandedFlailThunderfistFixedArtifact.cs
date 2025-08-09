// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class TwoHandedFlailThunderfistFixedArtifact : FixedArtifact
{
    private TwoHandedFlailThunderfistFixedArtifact(Game game) : base(game) { }
    protected override string BaseItemFactoryName => nameof(TwoHandedFlailHaftedWeaponItemFactory);
    public override ColorEnum Color => ColorEnum.Yellow;
    public override string Name => "The Two-Handed Flail 'Thunderfist'";
    public override int Ds => 6;
    public override int Level => 45;
    public override int Rarity => 38;
    public override int ToA => 0;
    public override int ToD => 18;
    public override int ToH => 5;
}
