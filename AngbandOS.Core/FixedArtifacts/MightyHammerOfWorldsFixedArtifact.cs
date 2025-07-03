// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class MightyHammerOfWorldsFixedArtifact : FixedArtifact
{
    private MightyHammerOfWorldsFixedArtifact(Game game) : base(game) { }   
    protected override string BaseItemFactoryName => nameof(MightyHammerHaftedWeaponItemFactory);
    public override ColorEnum Color => ColorEnum.Black;
    public override string Name => "The Mighty Hammer of Worlds";
    public override int Ac => 0;
    public override int Cost => 500000;
    public override int Dd => 9;
    public override int Ds => 9;
    public override int Level => 100;
    public override int Rarity => 1;
    public override int ToA => 10;
    public override int ToD => 25;
    public override int ToH => 5;
    public override int Weight => 1000;
}
