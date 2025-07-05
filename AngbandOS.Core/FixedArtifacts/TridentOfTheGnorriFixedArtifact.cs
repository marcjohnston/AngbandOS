// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class TridentOfTheGnorriFixedArtifact : FixedArtifact
{
    private TridentOfTheGnorriFixedArtifact(Game game) : base(game) { }
    protected override string BaseItemFactoryName => nameof(TridentPolearmWeaponItemFactory);
    public override ColorEnum Color => ColorEnum.Yellow;
    public override string Name => "The Trident of the Gnorri";
    public override int Cost => 120000;
    public override int Dd => 4;
    public override int Ds => 8;
    public override int Level => 30;
    public override int Rarity => 90;
    public override int ToA => 0;
    public override int ToD => 19;
    public override int ToH => 15;
    public override int Weight => 70;
}
