namespace AngbandOS.Core.CharacterClasses
{
    [Serializable]
    internal class CultistCharacterClass : BaseCharacterClass
    {
        private CultistCharacterClass(SaveGame savedGame) : base(savedGame) { }
        public override int ID => 12;
    }

}
