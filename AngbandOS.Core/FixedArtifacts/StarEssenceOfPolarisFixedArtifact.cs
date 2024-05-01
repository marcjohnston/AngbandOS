// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class StarEssenceOfPolarisFixedArtifact : FixedArtifact, IFixedArtifactActivatible
{
    private StarEssenceOfPolarisFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(StarEssenceGaladrielLightSourceItemFactory);

    // Star Essence of Polaris lights the area
    public void ActivateItem(Item item)
    {
        Game.MsgPrint("The essence wells with clear light...");
        Game.LightArea(base.Game.DiceRoll(2, 15), 3);
        item.RingsArmorActivationAndFixedArtifactsRechargeTimeLeft = base.Game.RandomLessThan(10) + 10;
    }

    public string DescribeActivationEffect => "illumination every 10+d10 turns";

    public override ColorEnum Color => ColorEnum.Yellow;
    public override string Name => "The Star Essence of Polaris";
    public override int Ac => 0;
    public override bool Activate => true;
    public override int Cost => 10000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "of Polaris";
    public override bool HasOwnType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool InstaArt => true;
    public override int Level => 1;
    public override int InitialTypeSpecificValue => 1;
    public override int Rarity => 1;
    public override bool Search => true;
    public override int ToA => 0;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 10;
}
