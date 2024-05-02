// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class PowerDragonScaleMailArmorItemFactory : DragonScaleMailArmorItemFactory, IItemsCanBeActivated
{
    private PowerDragonScaleMailArmorItemFactory(Game game) : base(game) { } // This object is a singleton.

    public void ActivateItem(Item item)
    {
        if (!Game.GetDirectionWithAim(out int dir))
        {
            return;
        }
        Game.MsgPrint("You breathe the elements.");
        Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(MissileProjectile)), dir, 300, -3);
        item.RingsArmorActivationAndFixedArtifactsRechargeTimeLeft = Game.RandomLessThan(300) + 300;
    }
    public override string? DescribeActivationEffect => "breathe the elements (300) every 300+d300 turns";
    protected override string SymbolName => nameof(OpenBraceSymbol);
    public override ColorEnum Color => ColorEnum.Yellow;
    public override string Name => "Power Dragon Scale Mail";

    public override int Ac => 40;
    public override bool Activate => true;
    public override int[] Chance => new int[] { 64, 0, 0, 0 };
    public override int Cost => 350000;
    public override int Dd => 2;
    public override int Ds => 4;
    public override string FriendlyName => "Power Dragon Scale Mail~";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int LevelNormallyFound => 110;
    public override int[] Locale => new int[] { 110, 0, 0, 0 };
    public override bool ResAcid => true;
    public override bool ResChaos => true;
    public override bool ResCold => true;
    public override bool ResConf => true;
    public override bool ResDark => true;
    public override bool ResDisen => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override bool ResLight => true;
    public override bool ResNether => true;
    public override bool ResNexus => true;
    public override bool ResPois => true;
    public override bool ResShards => true;
    public override bool ResSound => true;
    public override int ToA => 15;
    public override int ToH => -3;
    public override int Weight => 250;
    public override Item CreateItem() => new Item(Game, this);
}
