// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class TwoHandedSwordTwilightFixedArtifact : FixedArtifact
{
    private TwoHandedSwordTwilightFixedArtifact(Game game) : base(game) { }
    protected override string BaseItemFactoryName => nameof(TwoHandedSwordWeaponItemFactory);
    public override ColorEnum Color => ColorEnum.BrightWhite;
    public override string Name => "The Two-Handed Sword 'Twilight'";
    public override int Cost => 40000;
    public override int Dd => 4;
    public override int Ds => 6;
    public override int Level => 30;
    public override int Rarity => 15;
    public override int ToA => -50;
    public override int ToD => -60;
    public override int ToH => -40;
    public override int Weight => 250;
}
