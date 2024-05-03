// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class BronzeDragonScaleMailArmorItemFactory : DragonScaleMailArmorItemFactory, IItemsCanBeActivated
{
    private BronzeDragonScaleMailArmorItemFactory(Game game) : base(game) { } // This object is a singleton.

    public void ActivateItem(Item item)
    {
        if (!Game.GetDirectionWithAim(out int dir))
        {
            return;
        }
        Game.MsgPrint("You breathe confusion.");
        Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(ConfusionProjectile)), dir, 120, -2);
        item.RingsArmorActivationAndFixedArtifactsRechargeTimeLeft = Game.RandomLessThan(450) + 450;
    }
    public override string? DescribeActivationEffect => "breathe confusion (120) every 450+d450 turns";
    protected override string SymbolName => nameof(OpenBraceSymbol);
    public override ColorEnum Color => ColorEnum.BrightBrown;
    public override string Name => "Bronze Dragon Scale Mail";

    public override int ArmorClass => 30;
    public override bool Activate => true;
    public override int Cost => 30000;
    public override int DamageDice => 2;
    public override int DamageSides => 4;
    public override string FriendlyName => "Bronze Dragon Scale Mail~";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int LevelNormallyFound => 55;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (55, 8)
    };
    public override bool ResConf => true;
    public override int BonusArmorClass => 10;
    public override int BonusHit => -2;
    public override int Weight => 200;
}
