using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ScrollAcquirement : ScrollItemCategory
    {
        public override char Character => '?';
        public override string Name => "Acquirement";

        public override int Chance1 => 8;
        public override int Cost => 100000;
        public override string FriendlyName => "Acquirement";
        public override int Level => 20;
        public override int Locale1 => 20;
        public override int? SubCategory => 46;
        public override int Weight => 5;

        public override void Read(ReadScrollEvent eventArgs)
        {
            eventArgs.SaveGame.Level.Acquirement(eventArgs.SaveGame.Player.MapY, eventArgs.SaveGame.Player.MapX, 1, true);
            eventArgs.Identified = true;
        }
    }
}
