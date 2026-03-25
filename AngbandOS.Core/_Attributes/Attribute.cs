// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal abstract class Attribute : IGetKey, IIndexedSingletons
{
    /// <summary>
    /// Returns the unique index of the attribute.  This property implements the IIndexedSingletons.
    /// </summary>
    public int Index { get; set; } = -1; // Preset for overwrite detection.

    public abstract string Key { get; }
    public string GetKey => Key;

    protected Game Game { get; }

    public abstract EffectiveAttributeValue CreateEffectiveAttributeValue();

    public void Bind() { }

    protected Attribute(Game game)
    {
        Game = game;
    }
}
