using AngbandOS.Core.Interface;
using Cthangband.Enumerations;
using System;
using static Cthangband.Extensions;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal abstract class NatureBookItemCategory : BookItemCategory
    {
        public override ItemCategory CategoryEnum => ItemCategory.NatureBook;
        public override string GetDescription(Item item, bool includeCountPrefix)
        {
            string name = item.SaveGame.Player.Spellcasting.Type == CastingType.Divine ? $"{Pluralize("Book", item.Count)} of Nature Magic" : $"Nature {Pluralize("Spellbook", item.Count)}";
            name = $"{name} {item.ItemType.Name}";
            return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
        }

        public override bool HatesFire => true;
        public override Colour Colour => Colour.BrightGreen;
        public override Realm SpellBookToToRealm => Realm.Nature;
    }
}
