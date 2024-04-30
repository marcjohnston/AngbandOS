// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class AcidBoltsWandItemFactory : WandItemFactory
{
    private AcidBoltsWandItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override void ApplyMagic(Item item, int level, int power, Store? store)
    {
        item.TypeSpecificValue = Game.DieRoll(8) + 6;
    }
    public override Symbol Symbol => Game.SingletonRepository.Get<Symbol>(nameof(MinusSignSymbol));
    public override string Name => "Acid Bolts";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 950;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Acid Bolts";
    public override int LevelNormallyFound => 30;
    public override int[] Locale => new int[] { 30, 0, 0, 0 };
    public override int Weight => 10;
    public override bool ExecuteActivation(Game game, int dir)
    {
        game.FireBoltOrBeam(20, game.SingletonRepository.Get<Projectile>(nameof(AcidProjectile)), dir, Game.DiceRoll(3, 8));
        return true;
    }
    public override Item CreateItem() => new Item(Game, this);
}
