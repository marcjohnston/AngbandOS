namespace AngbandOS.Core.CharacterClasses
{
    [Serializable]
    internal class DruidCharacterClass : BaseCharacterClass
    {
        private DruidCharacterClass(SaveGame savedGame) : base(savedGame) { }
        public override int ID => 11;
    }

}
