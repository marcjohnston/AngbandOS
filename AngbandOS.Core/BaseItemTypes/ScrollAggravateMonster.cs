using AngbandOS.Enumerations;
using System;
using System.Diagnostics.Tracing;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ScrollAggravateMonster : ScrollItemCategory
    {
        public override char Character => '?';
        public override string Name => "Aggravate Monster";

        public override int Chance1 => 1;
        public override string FriendlyName => "Aggravate Monster";
        public override int Level => 5;
        public override int Locale1 => 5;
        public override int? SubCategory => 1;
        public override int Weight => 5;

        public override void Read(ReadScrollEvent eventArgs)
        {
            eventArgs.SaveGame.MsgPrint("There is a high pitched humming noise.");
            eventArgs.SaveGame.AggravateMonsters(1);
            eventArgs.Identified = true;
        }
    }
}
