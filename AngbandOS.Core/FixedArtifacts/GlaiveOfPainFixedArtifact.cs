// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class GlaiveOfPainFixedArtifact : FixedArtifact
{
    private GlaiveOfPainFixedArtifact(Game game) : base(game) { }
    protected override string BaseItemFactoryName => nameof(GlaivePolearmWeaponItemFactory);
    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "The Glaive of Pain";
    public override int Cost => 50000;
    public override int Dd => 9;
    public override int Ds => 6;
    public override int Level => 30;
    public override int Rarity => 25;
    public override int ToA => 0;
    public override int ToD => 30;
    public override int ToH => 0;
    public override int Weight => 190;
}
