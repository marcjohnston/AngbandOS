// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class MithrilChainMailOfTheVampireHunterFixedArtifact : FixedArtifact
{
    private MithrilChainMailOfTheVampireHunterFixedArtifact(Game game) : base(game) { }
    protected override string BaseItemFactoryName => nameof(MithrilChainMailHardArmorItemFactory);
    public override ColorEnum Color => ColorEnum.BrightBlue;
    public override string Name => "The Mithril Chain Mail of the Vampire Hunter";
    public override int Dd => 1;
    public override int Ds => 4;
    public override int Level => 40;
    public override int Rarity => 3;
    public override int ToA => 20;
    public override int ToD => 0;
    public override int ToH => -1;
}
