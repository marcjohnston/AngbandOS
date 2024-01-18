// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class RodColdBalls : RodItemFactory
{
    private RodColdBalls(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override bool RequiresAiming => true;
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(MinusSignSymbol));
    public override string Name => "Cold Balls";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 4500;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Cold Balls";
    public override int Level => 60;
    public override int[] Locale => new int[] { 60, 0, 0, 0 };
    public override int Weight => 15;
    public override void Execute(ZapRodEvent zapRodEvent)
    {
        SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get<ColdProjectile>(), zapRodEvent.Dir.Value, 48, 2);
        zapRodEvent.Identified = true;
        zapRodEvent.Item.TypeSpecificValue = 25;
    }
    public override Item CreateItem() => new ColdBallsRodItem(SaveGame);
}
