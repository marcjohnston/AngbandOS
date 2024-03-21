// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class DragonsFrostWandItemFactory : WandItemFactory
{
    private DragonsFrostWandItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override Symbol Symbol => Game.SingletonRepository.Symbols.Get(nameof(MinusSignSymbol));
    public override string Name => "Dragon's Frost";

    public override void ApplyMagic(Item item, int level, int power, Store? store)
    {
        item.TypeSpecificValue = Game.DieRoll(3) + 1;
    }
    public override int[] Chance => new int[] { 4, 0, 0, 0 };
    public override int Cost => 2400;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Dragon's Frost";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int LevelNormallyFound => 50;
    public override int[] Locale => new int[] { 50, 0, 0, 0 };
    public override int Weight => 10;
    public override bool ExecuteActivation(Game game, int dir)
    {
        game.FireBall(game.SingletonRepository.Projectiles.Get(nameof(ColdProjectile)), dir, 80, 3);
        return true;
    }
    public override Item CreateItem() => new Item(Game, this);
}
