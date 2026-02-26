// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class StarEssenceOfPolarisFixedArtifact : FixedArtifact
{
    public override bool DisableStomp => true;
    private StarEssenceOfPolarisFixedArtifact(Game game) : base(game) { }
    protected override string BaseItemFactoryName => nameof(StarEssenceGaladrielLightSourceItemFactory);
    public override string Name => "The Star Essence of Polaris";
    public override bool DisableViaEnchantment => true;
    public override bool DisableViaRandom => true;
    public override int Level => 1;
    public override int Rarity => 1;
    public override ColorEnum Color => ColorEnum.Yellow;
}
