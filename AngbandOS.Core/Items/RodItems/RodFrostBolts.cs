// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class RodFrostBolts : RodItemFactory
{
    private RodFrostBolts(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override bool RequiresAiming => true;
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<MinusSignSymbol>();
    public override string Name => "Frost Bolts";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 2500;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Frost Bolts";
    public override int Level => 25;
    public override int[] Locale => new int[] { 25, 0, 0, 0 };
    public override int Weight => 15;
    public override void Execute(ZapRodEvent zapRodEvent)
    {
        SaveGame.FireBoltOrBeam(10, SaveGame.SingletonRepository.Projectiles.Get<ColdProjectile>(), zapRodEvent.Dir.Value, Program.Rng.DiceRoll(5, 8));
        zapRodEvent.Identified = true;
        zapRodEvent.Item.TypeSpecificValue = 13;
    }
    public override Item CreateItem() => new FrostBoltsRodItem(SaveGame);
}
