using Cthangband.Enumerations;
using Cthangband.StaticData;
using System;

namespace Cthangband.Stores
{
    [Serializable]
    internal class BlackStore : Store
    {
        public BlackStore() : base(StoreType.StoreBlack)
        {
        }

        public override string FeatureType => "BlackMarket";

        protected override StoreOwner[] StoreOwners => new StoreOwner[]
        {
            new StoreOwner("Vhassa the Dead", 20000, 150, RaceId.Zombie),
            new StoreOwner("Kyn the Treacherous", 20000, 150, RaceId.Vampire),
            new StoreOwner("Batrachian Belle", 30000, 150, RaceId.MiriNigri),
            new StoreOwner("Corpselight", 30000, 150, RaceId.Spectre),
            new StoreOwner("Parrish the Bloodthirsty", 20000, 150, RaceId.Vampire),
            new StoreOwner("Vile", 20000, 150, RaceId.Skeleton),
            new StoreOwner("Prentice the Trusted", 30000, 150, RaceId.Skeleton),
            new StoreOwner("Griella Humanslayer", 30000, 150, RaceId.Imp),
            new StoreOwner("Charity the Necromancer", 20000, 150, RaceId.DarkElf),
            new StoreOwner("Pugnacious the Pugilist", 20000, 150, RaceId.HalfOrc),
            new StoreOwner("Footsore the Lucky", 30000, 150, RaceId.MiriNigri),
            new StoreOwner("Sidria Lighfingered", 30000, 150, RaceId.Human),
            new StoreOwner("Riatho the Juggler", 20000, 150, RaceId.Hobbit),
            new StoreOwner("Janaaka the Shifty", 20000, 150, RaceId.Gnome),
            new StoreOwner("Cina the Rogue", 30000, 150, RaceId.Gnome),
            new StoreOwner("Arunikki Greatclaw", 30000, 150, RaceId.Draconian),
            new StoreOwner("Chaeand the Poor", 20000, 150, RaceId.Human),
            new StoreOwner("Afardorf the Brigand", 20000, 150, RaceId.TchoTcho),
            new StoreOwner("Lathaxl the Greedy", 30000, 150, RaceId.MindFlayer),
            new StoreOwner("Falarewyn", 30000, 150, RaceId.Sprite)
        };

        protected override bool HasStoreTable => false;

        protected override bool StoreWillBuy(Item item)
        {
            return item.Value() > 0;
        }

        protected override int AdjustPrice(int price, bool trueToMarkDownFalseToMarkUp)
        {
            if (trueToMarkDownFalseToMarkUp == true)
            {
                return price / 2;
            }
            else
            {
                return price * 2;
            }
        }

        protected override Item CreateItem()
        {
            int level;
            ItemType itemType;
            level = 35 + Program.Rng.RandomLessThan(35);
            itemType = ItemType.RandomItemType(level);
            if (itemType == null)
            {
                return null; ;
            }
            Item qPtr = new Item();
            qPtr.AssignItemType(itemType);
            qPtr.ApplyMagic(level, false, false, false);
            return qPtr;
        }
        protected override int MinimumItemValue => 10;
    }
}
