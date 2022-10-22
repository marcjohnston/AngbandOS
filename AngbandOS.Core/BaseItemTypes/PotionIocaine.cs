using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PotionIocaine : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Iocaine";

        public override int Chance1 => 4;
        public override int Dd => 20;
        public override int Ds => 20;
        public override string FriendlyName => "Iocaine";
        public override int Level => 55;
        public override int Locale1 => 55;
        public override int? SubCategory => (int)PotionType.Death;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            // Iocaine simply does 5000 damage
            saveGame.MsgPrint("A feeling of Death flows through your body.");
            saveGame.Player.TakeHit(5000, "a potion of Death");
            return true;
        }
    }
}
