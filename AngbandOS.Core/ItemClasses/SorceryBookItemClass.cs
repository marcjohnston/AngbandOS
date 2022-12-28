using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using static AngbandOS.Extensions;

namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class SorceryBookItemClass : BookItemClass
    {
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.SorceryBook;
        public override string GetDescription(Item item, bool includeCountPrefix)
        {
            string name = item.SaveGame.Player.Spellcasting.Type == CastingType.Divine ? $"{Pluralize("Book", item.Count)} of Sorcery" : $"Sorcery {Pluralize("Spellbook", item.Count)}";
            name = $"{name} {item.BaseItemCategory.FriendlyName}";
            return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
        }
        public override bool HatesFire => true;
        public override Colour Colour => Colour.BrightBlue;
        public override Realm SpellBookToToRealm => Realm.Sorcery;
    }
}
