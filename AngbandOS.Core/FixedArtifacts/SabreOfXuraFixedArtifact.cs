// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class SabreOfXuraFixedArtifact : FixedArtifact
{
    private SabreOfXuraFixedArtifact(Game game) : base(game) { }
    protected override string BaseItemFactoryName => nameof(SabreWeaponItemFactory);
    public override ColorEnum Color => ColorEnum.BrightWhite;
    public override string Name => "The Sabre of Xura";
    public override int Cost => 125000;
    public override int Dd => 2;
    public override int Ds => 7;
    public override int Level => 20;
    public override int Rarity => 45;
    public override int ToA => 0;
    public override int ToD => 12;
    public override int ToH => 20;
    public override int Weight => 50;
}
