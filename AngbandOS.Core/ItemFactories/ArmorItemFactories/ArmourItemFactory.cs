// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
/// <summary>
/// Represents armor items.  Boots, cloaks, crowns, dragon armor, gloves, hard armor, helm, shield and soft armor are all armor classes.
/// </summary>
internal abstract class ArmorItemFactory : ItemFactory
{
    public ArmorItemFactory(Game game) : base(game) { }

    protected override (int, string)[]? MassProduceTupleNames => new (int, string)[]
    {
        (100, "3d5-3")
    };

    public override void ApplyBonusForRandomArtifactCreation(RandomArtifactCharacteristics characteristics)
    {
        characteristics.BonusArmorClass += Game.DieRoll(characteristics.BonusArmorClass > 19 ? 1 : 20 - characteristics.BonusArmorClass);
    }

    public override int BonusHitRealValueMultiplier => 100;
    public override int BonusDamageRealValueMultiplier => 100;
    public override int BonusArmorClassRealValueMultiplier => 100;
}
