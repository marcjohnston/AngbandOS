// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class ChaosDragonScaleMailArmorItemFactory : DragonScaleMailArmorItemFactory, IItemsCanBeActivated
{
    private ChaosDragonScaleMailArmorItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public void ActivateItem(Item item)
    {
        if (!SaveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        int chance = SaveGame.Rng.RandomLessThan(2);
        string element = chance == 1 ? "chaos" : "disenchantment";
        SaveGame.MsgPrint($"You breathe {element}.");
        SaveGame.FireBall(projectile: chance == 1 ? (Projectile)SaveGame.SingletonRepository.Projectiles.Get(nameof(ChaosProjectile)) : SaveGame.SingletonRepository.Projectiles.Get(nameof(DisenchantProjectile)), dir: dir, dam: 220, rad: -2);
        item.RechargeTimeLeft = SaveGame.Rng.RandomLessThan(300) + 300;
    }
    public override string? DescribeActivationEffect => "breathe chaos/disenchant (220) every 300+d300 turns";
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(OpenBraceSymbol));
    public override ColorEnum Color => ColorEnum.Purple;
    public override string Name => "Chaos Dragon Scale Mail";

    public override int Ac => 30;
    public override bool Activate => true;
    public override int[] Chance => new int[] { 16, 0, 0, 0 };
    public override int Cost => 70000;
    public override int Dd => 2;
    public override int Ds => 4;
    public override string FriendlyName => "Chaos Dragon Scale Mail~";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 75;
    public override int[] Locale => new int[] { 75, 0, 0, 0 };
    public override bool ResChaos => true;
    public override bool ResDisen => true;
    public override int ToA => 10;
    public override int ToH => -2;
    public override int Weight => 200;
    public override Item CreateItem() => new Item(SaveGame, this);
}