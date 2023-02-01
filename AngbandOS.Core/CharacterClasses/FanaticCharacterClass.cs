namespace AngbandOS.Core.CharacterClasses
{
    [Serializable]
    internal class FanaticCharacterClass : BaseCharacterClass
    {
        private FanaticCharacterClass(SaveGame savedGame) : base(savedGame) { }
        public override int ID => 7;
    }

}
