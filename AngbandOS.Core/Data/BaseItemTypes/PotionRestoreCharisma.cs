using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PotionRestoreCharisma : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Restore Charisma";

        public override int Chance1 => 1;
        public override int Cost => 300;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Restore Charisma";
        public override int Level => 20;
        public override int Locale1 => 20;
        public override int? SubCategory => 47;
        public override int Weight => 4;
    }
}
