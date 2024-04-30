// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class FlaskItemFactory : ItemFactory
{
    public FlaskItemFactory(Game game) : base(game) { }
    public override ItemClass ItemClass => Game.SingletonRepository.Get<ItemClass>(nameof(FlasksItemClass));
    public override bool EasyKnow => true;
    public override int GetAdditionalMassProduceCount(Item item)
    {
        // Rare items will not mass produce.
        if (item.RareItem != null)
        {
            return 0;
        }

        int cost = item.Value();
        if (cost <= 5)
        {
            return item.MassRoll(3, 5);
        }
        if (cost <= 20)
        {
            return item.MassRoll(3, 5);
        }
        return 0;
    }
    public override int PercentageBreakageChance => 100;
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Flask;
    public override bool HatesCold => true;
    public override int PackSort => 10;
    public override ColorEnum Color => ColorEnum.Yellow;
}
