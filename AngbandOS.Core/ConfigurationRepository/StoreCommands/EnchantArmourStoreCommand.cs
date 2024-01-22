// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.StoreCommands;

[Serializable]
internal class EnchantArmorStoreCommand : StoreCommand
{
    private EnchantArmorStoreCommand(SaveGame saveGame) : base(saveGame) { }
    public override char KeyChar => 'r';

    public override string Description => "Enchant your armour";

    protected override string[]? ValidStoreNames => new string[] {
        nameof(ArmouryStoreFactory)
    };

    public override void Execute(StoreCommandEvent storeCommandEvent)
    {
        storeCommandEvent.Store.EnchantArmour();
    }
}
