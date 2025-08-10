// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class MultiHuedDragonScaleMailRazorbackFixedArtifact : FixedArtifact
{
    private MultiHuedDragonScaleMailRazorbackFixedArtifact(Game game) : base(game) { }
    protected override string BaseItemFactoryName => nameof(MultiHuedDragonScaleMailItemFactory);
    public override ColorEnum Color => ColorEnum.Purple;
    public override string Name => "The Multi-Hued Dragon Scale Mail 'Razorback'";
    public override int Level => 90;
    public override int Rarity => 9;
}
