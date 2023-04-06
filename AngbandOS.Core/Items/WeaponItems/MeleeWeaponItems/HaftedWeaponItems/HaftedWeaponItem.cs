namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class HaftedWeaponItem : MeleeWeaponItem
    {
        public HaftedWeaponItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
        public override int PackSort => 30;
    }
}