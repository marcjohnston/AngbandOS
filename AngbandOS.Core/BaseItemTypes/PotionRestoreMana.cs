using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PotionRestoreMana : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Restore Mana";

        public override int Chance1 => 1;
        public override int Cost => 350;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Restore Mana";
        public override int Level => 25;
        public override int Locale1 => 25;
        public override int? SubCategory => (int)PotionType.RestoreMana;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            // Restore mana restores your to maximum mana
            if (saveGame.Player.Mana < saveGame.Player.MaxMana)
            {
                saveGame.Player.Mana = saveGame.Player.MaxMana;
                saveGame.Player.FractionalMana = 0;
                saveGame.MsgPrint("Your feel your head clear.");
                saveGame.Player.RedrawNeeded.Set(RedrawFlag.PrMana);
                return true;
            }
            return false;
        }
    }
}
