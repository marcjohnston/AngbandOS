// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class LargeLeatherShieldRawhideFixedArtifact : FixedArtifact
{
    private LargeLeatherShieldRawhideFixedArtifact(Game game) : base(game) { }
    protected override string BaseItemFactoryName => nameof(LargeLeatherShieldItemFactory);
    public override ColorEnum Color => ColorEnum.BrightBrown;
    public override string Name => "The Large Leather Shield 'Rawhide'";
    public override int Cost => 12000;
    public override int Dd => 1;
    public override int Ds => 2;
    public override int Level => 30;
    public override int Rarity => 3;
    public override int ToA => 20;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 60;
}
