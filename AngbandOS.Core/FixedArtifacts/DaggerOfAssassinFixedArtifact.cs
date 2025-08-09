// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class DaggerOfAssassinFixedArtifact : FixedArtifact
{
    private DaggerOfAssassinFixedArtifact(Game game) : base(game) { }
    protected override string BaseItemFactoryName => nameof(DaggerWeaponItemFactory);
    public override ColorEnum Color => ColorEnum.BrightWhite;
    public override string Name => "The Dagger of Assassin";
    public override int Ds => 4;
    public override int Level => 20;
    public override int Rarity => 80;
    public override int ToA => 5;
    public override int ToD => 15;
    public override int ToH => 10;
}
