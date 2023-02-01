namespace AngbandOS.Core.CharacterClasses
{
    internal abstract class BaseCharacterClass
    {
        protected SaveGame SavedGame { get; }
        protected BaseCharacterClass(SaveGame savedGame)
        {
            SavedGame = savedGame;
        }

        /// <summary>
        /// Returns the deprecated CharacterClass constant for backwards compatibility.
        /// </summary>
        /// <value>The identifier.</value>
        public abstract int ID { get; }
    }
    internal abstract class ChannelerCharacterClass : BaseCharacterClass
    {
        private ChannelerCharacterClass(SaveGame savedGame) : base(savedGame) { }
        public override int ID => 13;
    }
    internal abstract class ChosenOneCharacterClass : BaseCharacterClass
    {
        private ChosenOneCharacterClass(SaveGame savedGame) : base(savedGame) { }
        public override int ID => 14;
    }
    internal abstract class CultistCharacterClass : BaseCharacterClass
    {
        private CultistCharacterClass(SaveGame savedGame) : base(savedGame) { }
        public override int ID => 12;
    }
    internal abstract class DruidCharacterClass : BaseCharacterClass
    {
        private DruidCharacterClass(SaveGame savedGame) : base(savedGame) { }
        public override int ID => 11;
    }
    internal abstract class FanaticCharacterClass : BaseCharacterClass
    {
        private FanaticCharacterClass(SaveGame savedGame) : base(savedGame) { }
        public override int ID => 7;
    }
    internal abstract class HighMageCharacterClass : BaseCharacterClass
    {
        private HighMageCharacterClass(SaveGame savedGame) : base(savedGame) { }
        public override int ID => 10;
    };
    internal abstract class MageCharacterClass : BaseCharacterClass
    {
        private MageCharacterClass(SaveGame savedGame) : base(savedGame) { }
        public override int ID => 1;
    }
    internal abstract class MindcrafterCharacterClass : BaseCharacterClass
    {
        private MindcrafterCharacterClass(SaveGame savedGame) : base(savedGame) { }
        public override int ID => 9;
    }
    internal abstract class MonkCharacterClass : BaseCharacterClass
    {
        private MonkCharacterClass(SaveGame savedGame) : base(savedGame) { }
        public override int ID => 8;
    }
    internal abstract class MysticCharacterClass : BaseCharacterClass
    {
        private MysticCharacterClass(SaveGame savedGame) : base(savedGame) { }
        public override int ID => 15;
    }
    internal abstract class PaladinCharacterClass : BaseCharacterClass
    {
        private PaladinCharacterClass(SaveGame savedGame) : base(savedGame) { }
        public override int ID => 5;
    }
    internal abstract class PriestCharacterClass : BaseCharacterClass
    {
        private PriestCharacterClass(SaveGame savedGame) : base(savedGame) { }
        public override int ID => 2;
    }
    internal abstract class RangerCharacterClass : BaseCharacterClass
    {
        private RangerCharacterClass(SaveGame savedGame) : base(savedGame) { }
        public override int ID => 4;
    }
    internal abstract class RogueCharacterClass : BaseCharacterClass
    {
        private RogueCharacterClass(SaveGame savedGame) : base(savedGame) { }
        public override int ID => 3;
    }
    internal abstract class WarriorCharacterClass : BaseCharacterClass
    {
        private WarriorCharacterClass(SaveGame savedGame) : base(savedGame) { }
        public override int ID => 0;
    }
    internal abstract class WarriorMageCharacterClass : BaseCharacterClass
    {
        private WarriorMageCharacterClass(SaveGame savedGame) : base(savedGame) { }
        public override int ID => 6;
    }

}
