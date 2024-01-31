// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.JsonModels;

[Serializable]
internal class JsonSymbol : IJsonModel<SymbolDefinition>
{
    public virtual char? Character { get; set; }
    public virtual char? QueryCharacter { get; set; } = null;
    public virtual string? Name { get; set; }

    public virtual string? Key { get; set; }
    public SymbolDefinition? ToDefinition()
    {
        if (Key == null || Character == null || Name == null)
            return null;

        return new SymbolDefinition()
        {
            Key = Key,
            Name = Name,
            Character = Character.Value,
            QueryCharacter = QueryCharacter
        };
    }
}
