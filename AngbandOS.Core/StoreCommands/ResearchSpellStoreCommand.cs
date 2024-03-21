// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using AngbandOS.Core.Scripts;

namespace AngbandOS.Core.StoreCommands;

[Serializable]
internal class ResearchSpellStoreCommand : StoreCommand

{
    private ResearchSpellStoreCommand(Game game) : base(game) { }
    public override char KeyChar => 'r';

    public override string Description => "Research a spell";

    protected override string[]? ValidStoreFactoryNames => new string[] {
        nameof(LibraryStoreFactory)
    };

    protected override string ExecuteScriptName => nameof(ResearchSpellScript);
}
