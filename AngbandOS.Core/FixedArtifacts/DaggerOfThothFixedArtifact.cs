// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class DaggerOfThothFixedArtifact : FixedArtifact
{
    private DaggerOfThothFixedArtifact(Game game) : base(game) { }
    protected override string BaseItemFactoryName => nameof(DaggerWeaponItemFactory);
    public override ColorEnum Color => ColorEnum.BrightWhite;
    public override string Name => "The Dagger of Thoth";
    public override int Cost => 35000;
    public override int Dd => 2;
    public override int Ds => 4;
    public override int Level => 5;
    public override int Rarity => 40;
    public override int ToA => 0;
    public override int ToD => 3;
    public override int ToH => 4;
}
