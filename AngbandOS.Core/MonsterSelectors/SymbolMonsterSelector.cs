﻿using AngbandOS.Core.MonsterRaces;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterSelectors
{
    [Serializable]
    internal class SymbolMonsterSelector : MonsterSelector
    {
        private char _character;

        public SymbolMonsterSelector(char character)
        {
            character = _character;
        }

        public override bool Matches(SaveGame saveGame, MonsterRace rPtr)
        {
            return rPtr.Character == _character && (rPtr.Flags1 & MonsterFlag1.Unique) == 0;
        }
    }
}