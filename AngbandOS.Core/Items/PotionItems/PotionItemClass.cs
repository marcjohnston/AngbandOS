﻿namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class PotionItemClass : ItemFactory
    {
        public PotionItemClass(SaveGame saveGame) : base(saveGame) { }
        public override bool EasyKnow => true;
        public override int PackSort => 11;
        /// <summary>
        /// Have a potion affect the player.  Activates the potion effect.
        /// </summary>
        /// <returns> True, if drinking the potion identified it; false, to keep the potion as unidentified.</returns>
        public abstract bool Quaff(SaveGame saveGame);

        public static bool IsPotion(ItemFactory itemClass)
        {
            return typeof(PotionItemClass).IsAssignableFrom(itemClass.GetType());
        }
        public override bool HasFlavor => true;
        /// <summary>
        /// Perform a smash effect for the potion.
        /// </summary>
        /// <param name="saveGame"></param>
        /// <param name="who"></param>
        /// <param name="y"></param>
        /// <param name="x"></param>
        /// <returns>Returns whether or not the action causes pets to become angry and turn against their owner.  Returns false, by default.</returns>
        public virtual bool Smash(SaveGame saveGame, int who, int y, int x)
        {
            return false;
        }

        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Potion;
        public override int BaseValue => 20;
        public override bool HatesCold => true;
        public override Colour Colour => Colour.Blue;

    }
}