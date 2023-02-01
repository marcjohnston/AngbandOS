namespace AngbandOS.Core.CharacterClasses
{
    [Serializable]
    internal class ChannelerCharacterClass : BaseCharacterClass
    {
        private ChannelerCharacterClass(SaveGame savedGame) : base(savedGame) { }
        public override int ID => 13;
    }

}
