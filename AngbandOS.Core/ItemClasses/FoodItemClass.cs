﻿using AngbandOS.Core;
using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using System;
using static AngbandOS.Extensions;

namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class FoodItemClass : ItemClass
    {
        public override bool EasyKnow => true;
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Food;
        public override bool CanAbsorb(Item item, Item other)
        {
            return true;
        }

        public override string GetDescription(Item item, bool includeCountPrefix)
        {
            if (item.ItemSubCategory >= FoodType.MinFood)
            {
                return base.GetDescription(item, includeCountPrefix);
            }
            string flavour = item.IdentStoreb ? "" : $"{item.SaveGame.MushroomFlavours[item.ItemSubCategory].Name} ";
            string ofName = item.IsFlavourAware() ? $" of {item.BaseItemCategory.FriendlyName}" : "";
            string name = $"{flavour}{Pluralize("Mushroom", item.Count)}{ofName}";
            return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
        }
        public override int BaseValue => 5;
        //public override bool CanBeConsumed => true;
        public override Colour Colour => Colour.Green;
        public override int PercentageBreakageChance => 100;

        public override int GetAdditionalMassProduceCount(Item item)
        {
            int cost = item.Value();
            if (cost <= 5)
            {
                return MassRoll(3, 5);
            }
            if (cost <= 20)
            {
                return MassRoll(3, 5);
            }
            return 0;
        }

        public abstract bool Eat(SaveGame saveGame);
    }
}