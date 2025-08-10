// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class AmuletOfLobonFixedArtifact : FixedArtifact
{
    private AmuletOfLobonFixedArtifact(Game game) : base(game) { }
    protected override string BaseItemFactoryName => nameof(CarlammasAmuletItemFactory);
    public override string Name => "The Amulet of Lobon";
    public override bool HasOwnType => true;
    public override int Level => 50;
    public override int Rarity => 10;
    public override int ToA => 0;
    public override int ToD => 0;
    public override int ToH => 0;
}
