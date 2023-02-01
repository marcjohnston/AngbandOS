namespace AngbandOS.Core.CharacterClasses
{
    [Serializable]
    internal class WarriorCharacterClass : BaseCharacterClass
    {
        private WarriorCharacterClass(SaveGame savedGame) : base(savedGame) { }
        public override int ID => 0;
    }

}
