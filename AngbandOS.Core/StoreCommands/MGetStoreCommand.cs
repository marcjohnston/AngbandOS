﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.StoreCommands;

[Serializable]
internal class MGetStoreCommand : StoreCommand
{
    private MGetStoreCommand(Game game) : base(game) { }
    public override char KeyChar => 'm';

    public override string Description => "";

    protected override string[]? ValidStoreFactoryNames => new string[] {
        nameof(AlchemistStoreFactory),
        nameof(ArmoryStoreFactory),
        nameof(BlackMarketStoreFactory),
        nameof(GeneralStoreFactory),
        nameof(HomeStoreFactory),
        nameof(InnStoreFactory),
        nameof(LibraryStoreFactory),
        nameof(MagicStoreFactory),
        nameof(PawnStoreFactory),
        nameof(TempleStoreFactory),
        nameof(WeaponStoreFactory)
    };

    protected override string ExecuteScriptName => nameof(PurchaseStoreItemScript);
}
