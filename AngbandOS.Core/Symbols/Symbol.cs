﻿namespace AngbandOS.Core.Symbols;

[Serializable]
internal abstract class Symbol
{
    protected readonly SaveGame SaveGame;
    protected Symbol(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }
    public abstract char Character { get; }
    public virtual char QueryCharacter => Character;
    public abstract string Name { get; }
}