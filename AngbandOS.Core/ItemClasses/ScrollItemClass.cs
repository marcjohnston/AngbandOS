﻿using AngbandOS.Core;
using AngbandOS.Core.EventArgs;
using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using System;
using static AngbandOS.Extensions;

namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class ScrollItemClass : ItemClass
    {
        public override bool EasyKnow => true;
        public override bool HasFlavor => true;
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Scroll;
        public override bool CanAbsorb(Item item, Item other)
        {
            return true;
        }
        public override string GetDescription(Item item, bool includeCountPrefix)
        {
            string flavour = item.IdentStoreb ? "" : $" titled \"{item.SaveGame.ScrollFlavours[item.ItemSubCategory].Name}\"";
            string ofName = item.IsFlavourAware() ? $" of {item.BaseItemCategory.FriendlyName}" : "";
            string name = $"{Pluralize("Scroll", item.Count)}{flavour}{ofName}";
            return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
        }
        public override int BaseValue => 20;
        public override bool HatesFire => true;
        public override bool HatesAcid => true;

        public override Colour Colour => Colour.BrightBeige;
        public override int PercentageBreakageChance => 50;
        public override int GetAdditionalMassProduceCount(Item item)
        {
            int cost = item.Value();
            if (cost <= 60)
            {
                return MassRoll(3, 5);
            }
            if (cost <= 240)
            {
                return MassRoll(1, 5);
            }
            return 0;
        }

        public abstract void Read(ReadScrollEvent eventArgs);
    }
}