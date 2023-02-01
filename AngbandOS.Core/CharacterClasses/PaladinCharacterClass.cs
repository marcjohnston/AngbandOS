namespace AngbandOS.Core.CharacterClasses
{
    [Serializable]
    internal class PaladinCharacterClass : BaseCharacterClass
    {
        private PaladinCharacterClass(SaveGame savedGame) : base(savedGame) { }
        public override int ID => 5;
    }

}
