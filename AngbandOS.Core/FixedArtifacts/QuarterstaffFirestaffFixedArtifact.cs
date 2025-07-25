// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class QuarterstaffFirestaffFixedArtifact : FixedArtifact
{
    private QuarterstaffFirestaffFixedArtifact(Game game) : base(game) { }
    protected override string BaseItemFactoryName => nameof(QuarterstaffHaftedWeaponItemFactory);
    public override ColorEnum Color => ColorEnum.BrightBrown;
    public override string Name => "The Quarterstaff 'Firestaff'";
    public override int Cost => 70000;
    public override int Dd => 1;
    public override int Ds => 9;
    public override int Level => 20;
    public override int Rarity => 18;
    public override int ToA => 0;
    public override int ToD => 20;
    public override int ToH => 10;
    public override int Weight => 150;
}
