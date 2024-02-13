// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class StinkingCloudWandItemFactory : WandItemFactory
{
    private StinkingCloudWandItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(MinusSignSymbol));
    public override string Name => "Stinking Cloud";

    public override void ApplyMagic(Item item, int level, int power, Store? store)
    {
        item.TypeSpecificValue = SaveGame.DieRoll(8) + 6;
    }

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 400;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Stinking Cloud";
    public override int Level => 5;
    public override int[] Locale => new int[] { 5, 0, 0, 0 };
    public override int Weight => 10;
    public override bool ExecuteActivation(SaveGame saveGame, int dir)
    {
        saveGame.FireBall(saveGame.SingletonRepository.Projectiles.Get(nameof(PoisProjectile)), dir, 12, 2);
        return true;
    }
    public override Item CreateItem() => new Item(SaveGame, this);
}
