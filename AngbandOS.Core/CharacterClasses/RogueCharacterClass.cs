namespace AngbandOS.Core.CharacterClasses
{
    [Serializable]
    internal class RogueCharacterClass : BaseCharacterClass
    {
        private RogueCharacterClass(SaveGame savedGame) : base(savedGame) { }
        public override int ID => 3;
    }

}
