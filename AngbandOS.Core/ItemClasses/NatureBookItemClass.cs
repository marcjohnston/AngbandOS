using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using System;
using static AngbandOS.Extensions;

namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class NatureBookItemClass : BookItemClass
    {
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.NatureBook;
        public override string GetDescription(Item item, bool includeCountPrefix)
        {
            string name = item.SaveGame.Player.Spellcasting.Type == CastingType.Divine ? $"{Pluralize("Book", item.Count)} of Nature Magic" : $"Nature {Pluralize("Spellbook", item.Count)}";
            name = $"{name} {item.BaseItemCategory.FriendlyName}";
            return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
        }

        public override bool HatesFire => true;
        public override Colour Colour => Colour.BrightGreen;
        public override Realm SpellBookToToRealm => Realm.Nature;
    }
}
