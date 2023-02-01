namespace AngbandOS.Core.CharacterClasses
{
    [Serializable]
    internal class MageCharacterClass : BaseCharacterClass
    {
        private MageCharacterClass(SaveGame savedGame) : base(savedGame) { }
        public override int ID => 1;
    }

}
