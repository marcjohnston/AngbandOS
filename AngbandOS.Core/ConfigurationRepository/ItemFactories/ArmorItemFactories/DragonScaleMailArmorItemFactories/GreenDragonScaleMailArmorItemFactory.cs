// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class GreenDragonScaleMailArmorItemFactory : DragonScaleMailArmorItemFactory, IItemsCanBeActivated
{
    private GreenDragonScaleMailArmorItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public void ActivateItem(Item item)
    {
        if (!SaveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        SaveGame.MsgPrint("You breathe poison gas.");
        SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get(nameof(PoisProjectile)), dir, 150, -2);
        item.RechargeTimeLeft = SaveGame.Rng.RandomLessThan(450) + 450;
    }
    public override string? DescribeActivationEffect => "breathe poison gas (150) every 450+d450 turns";
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(OpenBraceSymbol));
    public override ColorEnum Color => ColorEnum.Green;
    public override string Name => "Green Dragon Scale Mail";

    public override int Ac => 30;
    public override bool Activate => true;
    public override int[] Chance => new int[] { 8, 0, 0, 0 };
    public override int Cost => 80000;
    public override int Dd => 2;
    public override int Ds => 4;
    public override string FriendlyName => "Green Dragon Scale Mail~";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 70;
    public override int[] Locale => new int[] { 70, 0, 0, 0 };
    public override bool ResPois => true;
    public override int ToA => 10;
    public override int ToH => -2;
    public override int Weight => 200;
    public override Item CreateItem() => new Item(SaveGame, this);
}