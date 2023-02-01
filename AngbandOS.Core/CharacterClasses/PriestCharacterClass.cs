namespace AngbandOS.Core.CharacterClasses
{
    [Serializable]
    internal class PriestCharacterClass : BaseCharacterClass
    {
        private PriestCharacterClass(SaveGame savedGame) : base(savedGame) { }
        public override int ID => 2;
    }

}
