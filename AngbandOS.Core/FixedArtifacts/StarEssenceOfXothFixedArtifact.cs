// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class StarEssenceOfXothFixedArtifact : FixedArtifact
{
    public override bool DisableStomp => true;
    private StarEssenceOfXothFixedArtifact(Game game) : base(game) { }
    protected override string BaseItemFactoryName => nameof(StarEssenceElendilLightSourceItemFactory);
    public override string Name => "The Star Essence of Xoth";
    public override bool DisableViaEnchantment => true;
    public override bool DisableViaRandom => true;
    public override int Level => 30;
    public override int Rarity => 25;
    public override ColorEnum Color => ColorEnum.Yellow;
}
