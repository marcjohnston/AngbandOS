using AngbandOS.Interface;
using Cthangband.Enumerations;
using System;
using static Cthangband.Extensions;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal abstract class SorceryBookItemCategory : BookItemCategory
    {
        public override ItemCategory CategoryEnum => ItemCategory.SorceryBook;
        public override string GetDescription(Item item, bool includeCountPrefix)
        {
            string name = item.SaveGame.Player.Spellcasting.Type == CastingType.Divine ? $"{Pluralize("Book", item.Count)} of Sorcery" : $"Sorcery {Pluralize("Spellbook", item.Count)}";
            name = $"{name} {item.ItemType.Name}";
            return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
        }
        public override bool HatesFire => true;
        public override Colour Colour => Colour.BrightBlue;
        public override Realm SpellBookToToRealm => Realm.Sorcery;
    }
}
