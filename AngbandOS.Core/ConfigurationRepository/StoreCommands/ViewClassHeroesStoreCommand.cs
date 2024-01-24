// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.StoreCommands;

[Serializable]
internal class ViewClassHeroesStoreCommand : StoreCommand
{
    private ViewClassHeroesStoreCommand(SaveGame saveGame) : base(saveGame) { }
    public override char KeyChar => 'c';

    public override string Description => "view Class heroes";

    protected override string[]? ValidStoreNames => new string[] {
        nameof(HallStoreFactory),
    };

    protected override string ExecuteScriptName => nameof(NoopScript);
}
