﻿namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class PolearmItemClass : MeleeWeaponItemClass
    {
        public PolearmItemClass(SaveGame saveGame) : base(saveGame) { }
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Polearm;
        public override bool HatesFire => true;
        public override int PackSort => 29;
        public override bool HatesAcid => true;

        public override Colour Colour => Colour.BrightWhite;

    }
}