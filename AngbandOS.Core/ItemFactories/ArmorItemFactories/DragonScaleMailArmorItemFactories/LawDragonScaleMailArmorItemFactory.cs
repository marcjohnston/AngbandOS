// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class LawDragonScaleMailArmorItemFactory : DragonScaleMailArmorItemFactory, IItemsCanBeActivated
{
    private LawDragonScaleMailArmorItemFactory(Game game) : base(game) { } // This object is a singleton.

    public void ActivateItem(Item item)
    {
        if (!Game.GetDirectionWithAim(out int dir))
        {
            return;
        }
        int chance = Game.RandomLessThan(2);
        string element = chance == 1 ? "sound" : "shards";
        Game.MsgPrint($"You breathe {element}.");
        Game.FireBall(chance == 1 ? (Projectile)Game.SingletonRepository.Get<Projectile>(nameof(SoundProjectile)) : Game.SingletonRepository.Get<Projectile>(nameof(ExplodeProjectile)), dir, 230, -2);
        item.RingsArmorActivationAndFixedArtifactsRechargeTimeLeft = Game.RandomLessThan(300) + 300;
    }
    public override string? DescribeActivationEffect => "breathe sound/shards (230) every 300+d300 turns";
    public override Symbol Symbol => Game.SingletonRepository.Get<Symbol>(nameof(OpenBraceSymbol));
    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "Law Dragon Scale Mail";

    public override int Ac => 30;
    public override bool Activate => true;
    public override int[] Chance => new int[] { 16, 0, 0, 0 };
    public override int Cost => 80000;
    public override int Dd => 2;
    public override int Ds => 4;
    public override string FriendlyName => "Law Dragon Scale Mail~";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int LevelNormallyFound => 80;
    public override int[] Locale => new int[] { 80, 0, 0, 0 };
    public override bool ResShards => true;
    public override bool ResSound => true;
    public override int ToA => 10;
    public override int ToH => -2;
    public override int Weight => 200;
    public override Item CreateItem() => new Item(Game, this);
}
