using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ScrollArtifactCreation : ScrollItemCategory
    {
        public override char Character => '?';
        public override string Name => "Artifact Creation";

        public override int Chance1 => 16;
        public override int Cost => 200000;
        public override string FriendlyName => "Artifact Creation";
        public override int Level => 70;
        public override int Locale1 => 70;
        public override int? SubCategory => 52;
        public override int Weight => 5;

        public override void Read(ReadScrollEvent eventArgs)
        {
            eventArgs.SaveGame.ArtifactScroll();
            eventArgs.Identified = true;
        }
    }
}
