// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class CuringRodItemFactory : RodItemFactory
{
    private CuringRodItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override bool RequiresAiming => false;
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(MinusSignSymbol));
    public override string Name => "Curing";

    public override int[] Chance => new int[] { 8, 0, 0, 0 };
    public override int Cost => 15000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Curing";
    public override int Level => 65;
    public override int[] Locale => new int[] { 65, 0, 0, 0 };
    public override int Weight => 15;
    public override void Execute(ZapRodEvent zapRodEvent)
    {
        if (SaveGame.TimedBlindness.ResetTimer())
        {
            zapRodEvent.Identified = true;
        }
        if (SaveGame.TimedPoison.ResetTimer())
        {
            zapRodEvent.Identified = true;
        }
        if (SaveGame.TimedConfusion.ResetTimer())
        {
            zapRodEvent.Identified = true;
        }
        if (SaveGame.TimedStun.ResetTimer())
        {
            zapRodEvent.Identified = true;
        }
        if (SaveGame.TimedBleeding.ResetTimer())
        {
            zapRodEvent.Identified = true;
        }
        if (SaveGame.TimedHallucinations.ResetTimer())
        {
            zapRodEvent.Identified = true;
        }
        zapRodEvent.Item.TypeSpecificValue = 999;
    }
    public override Item CreateItem() => new CuringRodItem(SaveGame);
}
