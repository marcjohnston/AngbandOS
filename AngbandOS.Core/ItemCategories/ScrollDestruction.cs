using AngbandOS.Core.EventArgs;
using AngbandOS.Enumerations;
using System;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ScrollDestruction : ScrollItemClass
    {
        public override char Character => '?';
        public override string Name => "*Destruction*";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 250;
        public override string FriendlyName => "*Destruction*";
        public override int Level => 40;
        public override int[] Locale => new int[] { 40, 0, 0, 0 };
        public override int? SubCategory => 41;
        public override int Weight => 5;
        public override void Read(ReadScrollEvent eventArgs)
        {
            eventArgs.SaveGame.DestroyArea(eventArgs.SaveGame.Player.MapY, eventArgs.SaveGame.Player.MapX, 15);
            eventArgs.Identified = true;
        }
    }
}