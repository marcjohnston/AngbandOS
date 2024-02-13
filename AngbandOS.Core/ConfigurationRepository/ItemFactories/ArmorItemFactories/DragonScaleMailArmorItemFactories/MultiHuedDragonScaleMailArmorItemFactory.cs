// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class MultiHuedDragonScaleMailArmorItemFactory : DragonScaleMailArmorItemFactory, IItemsCanBeActivated
{
    private MultiHuedDragonScaleMailArmorItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public void ActivateItem(Item item)
    {
        if (!SaveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        int chance = SaveGame.RandomLessThan(5);
        string element = chance == 1 ? "lightning" : (chance == 2 ? "frost" : (chance == 3 ? "acid" : (chance == 4 ? "poison gas" : "fire")));
        SaveGame.MsgPrint($"You breathe {element}.");
        switch (chance)
        {
            case 0:
                SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get(nameof(FireProjectile)), dir, 250, -2);
                return;
            case 1:
                SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get(nameof(ElecProjectile)), dir, 250, -2);
                return;

            case 2:
                SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get(nameof(ColdProjectile)), dir, 250, -2);
                return;

            case 3:
                SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get(nameof(AcidProjectile)), dir, 250, -2);
                return;

            case 4:
                SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get(nameof(PoisProjectile)), dir, 250, -2);
                return;
        }
        item.RechargeTimeLeft = SaveGame.RandomLessThan(225) + 225;
    }
    public override string? DescribeActivationEffect => "breathe multi-hued (250) every 225+d225 turns";
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(OpenBraceSymbol));
    public override ColorEnum Color => ColorEnum.Purple;
    public override string Name => "Multi-Hued Dragon Scale Mail";

    public override int Ac => 30;
    public override bool Activate => true;
    public override int[] Chance => new int[] { 16, 0, 0, 0 };
    public override int Cost => 150000;
    public override int Dd => 2;
    public override int Ds => 4;
    public override string FriendlyName => "Multi-Hued Dragon Scale Mail~";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 100;
    public override int[] Locale => new int[] { 100, 0, 0, 0 };
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override bool ResPois => true;
    public override int ToA => 10;
    public override int ToH => -2;
    public override int Weight => 200;
    public override Item CreateItem() => new Item(SaveGame, this);
}
