namespace AngbandOS.Core.CharacterClasses
{
    [Serializable]
    internal class MindcrafterCharacterClass : BaseCharacterClass
    {
        private MindcrafterCharacterClass(SaveGame savedGame) : base(savedGame) { }
        public override int ID => 9;
    }

}
