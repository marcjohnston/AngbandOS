namespace AngbandOS.Core.CharacterClasses
{
    [Serializable]
    internal class MysticCharacterClass : BaseCharacterClass
    {
        private MysticCharacterClass(SaveGame savedGame) : base(savedGame) { }
        public override int ID => 15;
    }

}
