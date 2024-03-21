// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Repositories;

[Serializable]
internal class SpellsRepository : DictionaryRepository<Spell>
{
    public SpellsRepository(Game game) : base(game) { }
    public override void Load()
    {
        if (Game.Configuration.Spells == null)
        {
            base.Load();
        }
        else
        {
            foreach (SpellDefinition definition in Game.Configuration.Spells)
            {
                Add(new GenericSpell(Game, definition));
            }
        }
    }
}