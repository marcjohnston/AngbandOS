using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ScrollObjectDetection : ScrollItemCategory
    {
        public override char Character => '?';
        public override string Name => "Scroll:Object Detection";

        public override int Chance1 => 1;
        public override int Cost => 15;
        public override string FriendlyName => "Object Detection";
        public override int? SubCategory => 27;
        public override int Weight => 5;
    }
}
