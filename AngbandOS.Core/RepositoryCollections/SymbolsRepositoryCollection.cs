// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.RepositoryCollections;

[Serializable]
internal class SymbolsRepositoryCollection : DictionaryRepositoryCollection<string, Symbol>
{
    public SymbolsRepositoryCollection(SaveGame saveGame) : base(saveGame) { }
    public override void Load()
    {
        if (SaveGame.Configuration.Symbols == null)
        {
            base.Load();
        }
        else
        {
            foreach (SymbolDefinition symbolDefinition in SaveGame.Configuration.Symbols)
            {
                Add(new GenericSymbol(SaveGame, symbolDefinition));
            }
        }
    }
}