using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using System;
using static AngbandOS.Extensions;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal abstract class FolkBookItemCategory : BookItemCategory
    {
        public override ItemCategory CategoryEnum => ItemCategory.FolkBook;
        public override string GetDescription(Item item, bool includeCountPrefix)
        {
            string name = item.SaveGame.Player.Spellcasting.Type == CastingType.Divine ? $"{Pluralize("Book", item.Count)} of Folk Magic" : $"Folk {Pluralize("Spellbook", item.Count)}";
            name = $"{name} {item.ItemType.BaseItemCategory.FriendlyName}";
            return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
        }
        public override bool HatesFire => true;
        public override Colour Colour => Colour.BrightPurple;
        public override Realm SpellBookToToRealm => Realm.Folk;
    }
}
