﻿using AngbandOS.Enumerations;
using System;

namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class GoldItemClass : ItemClass
    {
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Gold;
        //public override bool IgnoredByMonsters => true;
        public override int? SubCategory => null; // No longer used by gold.
    }

}