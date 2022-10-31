using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ScrollWordOfRecall : ScrollItemCategory
    {
        public override char Character => '?';
        public override string Name => "Word of Recall";

        public override int Chance1 => 1;
        public override int Cost => 150;
        public override string FriendlyName => "Word of Recall";
        public override int Level => 5;
        public override int Locale1 => 5;
        public override int? SubCategory => 11;
        public override int Weight => 5;

        public override void Read(ReadScrollEvent eventArgs)
        {
            eventArgs.SaveGame.Player.ToggleRecall();
            eventArgs.Identified = true;
        }
    }
}
