using Cthangband.Enumerations;
using System;
using static Cthangband.Extensions;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal abstract class FolkBookItemCategory : BookItemCategory
    {
        public override ItemCategory CategoryEnum => ItemCategory.FolkBook;
        public override string GetDescription(Item item, bool includeCountPrefix)
        {
            string name = SaveGame.Instance.Player.Spellcasting.Type == CastingType.Divine ? $"{Pluralize("Book", item.Count)} of Folk Magic" : $"Folk {Pluralize("Spellbook", item.Count)}";
            name = $"{name} {item.ItemType.Name}";
            return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
        }
        public override bool HatesFire => true;
        public override Colour Colour => Colour.BrightPurple;
        //public override Realm SpellBookToToRealm => Realm.Folk;

    }

}
