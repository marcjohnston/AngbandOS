﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class SpikeItemFactory : ItemFactory
{
    public SpikeItemFactory(SaveGame saveGame) : base(saveGame) { }
    public override ItemClass ItemClass => SaveGame.SingletonRepository.ItemClasses.Get(nameof(SpikesItemClass));

    public override int GetAdditionalMassProduceCount(Item item)
    {
        int cost = item.Value();
        if (cost <= 5)
        {
            return item.MassRoll(5, 5);
        }
        if (cost <= 50)
        {
            return item.MassRoll(5, 5);
        }
        if (cost <= 500)
        {
            return item.MassRoll(5, 5);
        }
        return 0;
    }

    public override int MakeObjectCount => SaveGame.Rng.DiceRoll(6, 7);
    public override bool EasyKnow => true;
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Spike;
    public override int PackSort => 37;
    public override ColorEnum Color => ColorEnum.Grey;

}