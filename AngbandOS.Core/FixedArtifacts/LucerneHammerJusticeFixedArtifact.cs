// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class LucerneHammerJusticeFixedArtifact : FixedArtifact
{
    private LucerneHammerJusticeFixedArtifact(Game game) : base(game) { }
    protected override string BaseItemFactoryName => nameof(LucerneHammerHaftedWeaponItemFactory);
    public override ColorEnum Color => ColorEnum.BrightBlue;
    public override string Name => "The Lucerne Hammer 'Justice'";
    public override int Level => 20;
    public override int Rarity => 15;
    public override int ToA => 8;
    public override int ToD => 6;
    public override int ToH => 10;
}
