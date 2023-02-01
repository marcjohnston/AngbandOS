namespace AngbandOS.Core.CharacterClasses
{
    [Serializable]
    internal class RangerCharacterClass : BaseCharacterClass
    {
        private RangerCharacterClass(SaveGame savedGame) : base(savedGame) { }
        public override int ID => 4;
    }

}
