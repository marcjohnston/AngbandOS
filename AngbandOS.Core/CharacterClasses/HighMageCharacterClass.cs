namespace AngbandOS.Core.CharacterClasses
{
    [Serializable]
    internal class HighMageCharacterClass : BaseCharacterClass
    {
        private HighMageCharacterClass(SaveGame savedGame) : base(savedGame) { }
        public override int ID => 10;
    };

}
