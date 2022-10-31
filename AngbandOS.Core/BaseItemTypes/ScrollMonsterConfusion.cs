using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ScrollMonsterConfusion : ScrollItemCategory
    {
        public override char Character => '?';
        public override string Name => "Monster Confusion";

        public override int Chance1 => 1;
        public override int Cost => 30;
        public override string FriendlyName => "Monster Confusion";
        public override int Level => 5;
        public override int Locale1 => 5;
        public override int? SubCategory => 36;
        public override int Weight => 5;

        public override void Read(ReadScrollEvent eventArgs)
        {
            if (!eventArgs.SaveGame.Player.HasConfusingTouch)
            {
                eventArgs.SaveGame.MsgPrint("Your hands begin to glow.");
                eventArgs.SaveGame.Player.HasConfusingTouch = true;
                eventArgs.Identified = true;
            }
        }
    }
}
