// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”


using Timer = AngbandOS.Core.Timers.Timer;

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class PersistConfigurationScript : Script, IScript
{
    private PersistConfigurationScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (Game.CorePersistentStorage == null)
        {
            Game.MsgPrint("No persistance interface was provided to save the configuration.");
            return;
        }

        try
        {
            // List repositories.
            Game.SingletonRepository.ElvishText.PersistEntities();
            Game.SingletonRepository.FindQuests.PersistEntities();
            Game.SingletonRepository.FunnyComments.PersistEntities();
            Game.SingletonRepository.FunnyDescriptions.PersistEntities();
            Game.SingletonRepository.HorrificDescriptions.PersistEntities();
            Game.SingletonRepository.InsultPlayerAttacks.PersistEntities();
            Game.SingletonRepository.MoanPlayerAttacks.PersistEntities();
            Game.SingletonRepository.UnreadableFlavorSyllables.PersistEntities();
            Game.SingletonRepository.ShopkeeperAcceptedComments.PersistEntities();
            Game.SingletonRepository.ShopkeeperBargainComments.PersistEntities();
            Game.SingletonRepository.ShopkeeperGoodComments.PersistEntities();
            Game.SingletonRepository.ShopkeeperLessThanGuessComments.PersistEntities();
            Game.SingletonRepository.ShopkeeperWorthlessComments.PersistEntities();
            Game.SingletonRepository.SingingPlayerAttacks.PersistEntities();
            Game.SingletonRepository.WorshipPlayerAttacks.PersistEntities();

            // Dictionary repositories.
            Game.SingletonRepository.PersistEntities<Activation>();
            Game.SingletonRepository.PersistEntities<AlterAction>();
            Game.SingletonRepository.PersistEntities<AmuletReadableFlavor>();
            Game.SingletonRepository.PersistEntities<Animation>();
            Game.SingletonRepository.ArtifactBiases.PersistEntities();
            Game.SingletonRepository.AttackEffects.PersistEntities();
            Game.SingletonRepository.PersistEntities<Attack>();
            Game.SingletonRepository.BirthStages.PersistEntities();
            Game.SingletonRepository.CharacterClasses.PersistEntities();
            Game.SingletonRepository.ChestTrapConfigurations.PersistEntities();
            Game.SingletonRepository.ChestTraps.PersistEntities();
            Game.SingletonRepository.PersistEntities<ClassSpell>();
            Game.SingletonRepository.PersistEntities<DungeonGuardian>();
            Game.SingletonRepository.PersistEntities<Dungeon>();
            Game.SingletonRepository.FixedArtifacts.PersistEntities();
            Game.SingletonRepository.PersistEntities<GameCommand>();
            Game.SingletonRepository.Genders.PersistEntities();
            Game.SingletonRepository.PersistEntities<God>();
            Game.SingletonRepository.PersistEntities<HelpGroup>();
            Game.SingletonRepository.InventorySlots.PersistEntities();
            Game.SingletonRepository.ItemClasses.PersistEntities();
            Game.SingletonRepository.ItemFactories.PersistEntities();
            Game.SingletonRepository.MartialArtsAttacks.PersistEntities();
            Game.SingletonRepository.MonsterFilters.PersistEntities();
            Game.SingletonRepository.PersistEntities<MonsterRace>();
            Game.SingletonRepository.MonsterSpells.PersistEntities();
            Game.SingletonRepository.PersistEntities<MushroomReadableFlavor>();
            Game.SingletonRepository.Mutations.PersistEntities();
            Game.SingletonRepository.Patrons.PersistEntities();
            Game.SingletonRepository.PersistEntities<Plural>();
            Game.SingletonRepository.PersistEntities<PotionReadableFlavor>();
            Game.SingletonRepository.PersistEntities<ProjectileGraphic>();
            Game.SingletonRepository.Projectiles.PersistEntities();
            Game.SingletonRepository.Races.PersistEntities();
            Game.SingletonRepository.RareItems.PersistEntities();
            Game.SingletonRepository.Realms.PersistEntities();
            Game.SingletonRepository.Rewards.PersistEntities();
            Game.SingletonRepository.RingReadableFlavors.PersistEntities();
            Game.SingletonRepository.RodReadableFlavors.PersistEntities();
            Game.SingletonRepository.RoomLayouts.PersistEntities();
            Game.SingletonRepository.Scripts.PersistEntities();
            Game.SingletonRepository.ScrollReadableFlavors.PersistEntities();
            Game.SingletonRepository.Shopkeepers.PersistEntities();
            Game.SingletonRepository.SpellResistantDetections.PersistEntities();
            Game.SingletonRepository.Spells.PersistEntities();
            Game.SingletonRepository.StaffReadableFlavors.PersistEntities();
            Game.SingletonRepository.StoreCommands.PersistEntities();
            Game.SingletonRepository.StoreFactories.PersistEntities();
            Game.SingletonRepository.Symbols.PersistEntities();
            Game.SingletonRepository.Talents.PersistEntities();
            Game.SingletonRepository.Tiles.PersistEntities();
            Game.SingletonRepository.PersistEntities<Timer>();
            Game.SingletonRepository.Towns.PersistEntities();
            Game.SingletonRepository.Vaults.PersistEntities();
            Game.SingletonRepository.WandReadableFlavors.PersistEntities();
            Game.SingletonRepository.WizardCommands.PersistEntities();
        }
        catch (NotImplementedException)
        {
            Game.MsgPrint("The persistance interface does not support entity persistance.");
            return;
        }
        catch (Exception ex)
        {
            Game.MsgPrint("The persistance interface failed to save the configuration.");
            return;
        }
    }
}
