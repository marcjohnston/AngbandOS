using AngbandOS.Core.EventArgs;
using AngbandOS.Enumerations;
using System;
using System.Diagnostics.Tracing;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ScrollAggravateMonster : ScrollItemClass
    {
        public override char Character => '?';
        public override string Name => "Aggravate Monster";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override string FriendlyName => "Aggravate Monster";
        public override int Level => 5;
        public override int[] Locale => new int[] { 5, 0, 0, 0 };
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