namespace AngbandOS.Core.CharacterClasses
{
    [Serializable]
    internal class ChosenOneCharacterClass : BaseCharacterClass
    {
        private ChosenOneCharacterClass(SaveGame savedGame) : base(savedGame) { }
        public override int ID => 14;
    }

}
