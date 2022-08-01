using Cthangband.Enumerations;

namespace Cthangband.ItemCategories
{
    internal class DeathBookItemCategory : BaseItemCategory
    {
        //public override string GetDescription(Item item, bool includeCountPrefix)
        //{
        //    string name = SaveGame.Instance.Player.Spellcasting.Type == CastingType.Divine ? $"{Pluralize("Book", item.Count)} of Death Magic" : $"Death {Pluralize("Spellbook", item.Count)}";
        //    name = $"{name} {item.ItemType.Name}";
        //    return includeCountPrefix ? GetPrefixCount(true, name, item.Count) : name;
        //}
        //public override bool HatesFire => true;
        //public override Colour Colour => Colour.Black;
        //public override Realm SpellBookToToRealm => Realm.Death;

    }

}
