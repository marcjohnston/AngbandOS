namespace AngbandOS.Core.CharacterClasses
{
    [Serializable]
    internal class MonkCharacterClass : BaseCharacterClass
    {
        private MonkCharacterClass(SaveGame savedGame) : base(savedGame) { }
        public override int ID => 8;
    }

}
