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
    private AcidBoltsWandItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override void ApplyMagic(Item item, int level, int power, Store? store)
    {
        item.TypeSpecificValue = SaveGame.Rng.DieRoll(8) + 6;
    }
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(MinusSignSymbol));
    public override string Name => "Acid Bolts";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 950;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Acid Bolts";
    public override int Level => 30;
    public override int[] Locale => new int[] { 30, 0, 0, 0 };
    public override int Weight => 10;
    public override bool ExecuteActivation(SaveGame saveGame, int dir)
    {
        saveGame.FireBoltOrBeam(20, saveGame.SingletonRepository.Projectiles.Get(nameof(AcidProjectile)), dir, SaveGame.Rng.DiceRoll(3, 8));
        return true;
    }
    public override Item CreateItem() => new Item(SaveGame, this);
}
