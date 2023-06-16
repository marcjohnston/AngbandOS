// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class RodAcidBalls : RodItemFactory
{
    private RodAcidBalls(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override bool RequiresAiming => true;
    public override char Character => '-';
    public override string Name => "Acid Balls";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 5500;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Acid Balls";
    public override int Level => 70;
    public override int[] Locale => new int[] { 70, 0, 0, 0 };
    public override int? SubCategory => 24;
    public override int Weight => 15;
    public override void Execute(ZapRodEvent zapRodEvent)
    {
        SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get<AcidProjectile>(), zapRodEvent.Dir.Value, 60, 2);
        zapRodEvent.Identified = true;
        zapRodEvent.Item.TypeSpecificValue = 27;
    }
    public override Item CreateItem() => new AcidBallsRodItem(SaveGame);
}
