namespace AngbandOS.Core.CharacterClasses
{
    [Serializable]
    internal class WarriorMageCharacterClass : BaseCharacterClass
    {
        private WarriorMageCharacterClass(SaveGame savedGame) : base(savedGame) { }
        public override int ID => 6;
    }

}
