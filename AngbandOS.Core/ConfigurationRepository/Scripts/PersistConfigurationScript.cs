// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class PersistConfigurationScript : Script, IScript
{
    private PersistConfigurationScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (SaveGame.CorePersistentStorage == null)
        {
            SaveGame.MsgPrint("No persistance interface was provided to save the configuration.");
            return;
        }

        try
        {
            // List repositories.
            SaveGame.SingletonRepository.ElvishText.PersistEntities();
            SaveGame.SingletonRepository.FindQuests.PersistEntities();
            SaveGame.SingletonRepository.FunnyComments.PersistEntities();
            SaveGame.SingletonRepository.FunnyDescriptions.PersistEntities();
            SaveGame.SingletonRepository.HorrificDescriptions.PersistEntities();
            SaveGame.SingletonRepository.InsultPlayerAttacks.PersistEntities();
            SaveGame.SingletonRepository.MoanPlayerAttacks.PersistEntities();
            SaveGame.SingletonRepository.ShopkeeperAcceptedComments.PersistEntities();
            SaveGame.SingletonRepository.ShopkeeperBargainComments.PersistEntities();
            SaveGame.SingletonRepository.ShopkeeperGoodComments.PersistEntities();
            SaveGame.SingletonRepository.ShopkeeperLessThanGuessComments.PersistEntities();
            SaveGame.SingletonRepository.ShopkeeperWorthlessComments.PersistEntities();
            SaveGame.SingletonRepository.SingingPlayerAttacks.PersistEntities();
            SaveGame.SingletonRepository.WorshipPlayerAttacks.PersistEntities();

            // Dictionary repositories.
            SaveGame.SingletonRepository.Activations.PersistEntities();
            SaveGame.SingletonRepository.AlterActions.PersistEntities();
            SaveGame.SingletonRepository.AmuletFlavours.PersistEntities();
            SaveGame.SingletonRepository.Animations.PersistEntities();
            SaveGame.SingletonRepository.ArtifactBiases.PersistEntities();
            SaveGame.SingletonRepository.AttackEffects.PersistEntities();
            SaveGame.SingletonRepository.Attacks.PersistEntities();
            SaveGame.SingletonRepository.BirthStages.PersistEntities();
            SaveGame.SingletonRepository.CastingTypes.PersistEntities();
            SaveGame.SingletonRepository.CharacterClasses.PersistEntities();
            SaveGame.SingletonRepository.ChestTrapConfigurations.PersistEntities();
            SaveGame.SingletonRepository.ChestTraps.PersistEntities();
            SaveGame.SingletonRepository.ClassSpells.PersistEntities();
            SaveGame.SingletonRepository.DungeonGuardians.PersistEntities();
            SaveGame.SingletonRepository.Dungeons.PersistEntities();
            SaveGame.SingletonRepository.FixedArtifacts.PersistEntities();
            SaveGame.SingletonRepository.GameCommands.PersistEntities();
            SaveGame.SingletonRepository.Genders.PersistEntities();
            SaveGame.SingletonRepository.HelpGroups.PersistEntities();
            SaveGame.SingletonRepository.InventorySlots.PersistEntities();
            SaveGame.SingletonRepository.ItemClasses.PersistEntities();
            SaveGame.SingletonRepository.ItemFactories.PersistEntities();
            SaveGame.SingletonRepository.MartialArtsAttacks.PersistEntities();
            SaveGame.SingletonRepository.MonsterFilters.PersistEntities();
            SaveGame.SingletonRepository.MonsterRaces.PersistEntities();
            SaveGame.SingletonRepository.MonsterSpells.PersistEntities();
            SaveGame.SingletonRepository.MushroomFlavours.PersistEntities();
            SaveGame.SingletonRepository.Mutations.PersistEntities();
            SaveGame.SingletonRepository.Patrons.PersistEntities();
            SaveGame.SingletonRepository.PotionFlavours.PersistEntities();
            SaveGame.SingletonRepository.ProjectileGraphics.PersistEntities();
            SaveGame.SingletonRepository.Projectiles.PersistEntities();
            SaveGame.SingletonRepository.Races.PersistEntities();
            SaveGame.SingletonRepository.RareItems.PersistEntities();
            SaveGame.SingletonRepository.Realms.PersistEntities();
            SaveGame.SingletonRepository.Rewards.PersistEntities();
            SaveGame.SingletonRepository.RingFlavours.PersistEntities();
            SaveGame.SingletonRepository.RodFlavours.PersistEntities();
            SaveGame.SingletonRepository.RoomLayouts.PersistEntities();
            SaveGame.SingletonRepository.Scripts.PersistEntities();
            SaveGame.SingletonRepository.ScrollFlavours.PersistEntities();
            SaveGame.SingletonRepository.Shopkeepers.PersistEntities();
            SaveGame.SingletonRepository.SpellResistantDetections.PersistEntities();
            SaveGame.SingletonRepository.Spells.PersistEntities();
            SaveGame.SingletonRepository.StaffFlavours.PersistEntities();
            SaveGame.SingletonRepository.StoreCommands.PersistEntities();
            SaveGame.SingletonRepository.StoreFactories.PersistEntities();
            SaveGame.SingletonRepository.Symbols.PersistEntities();
            SaveGame.SingletonRepository.Talents.PersistEntities();
            SaveGame.SingletonRepository.Tiles.PersistEntities();
            SaveGame.SingletonRepository.TimedActions.PersistEntities();
            SaveGame.SingletonRepository.Towns.PersistEntities();
            SaveGame.SingletonRepository.Vaults.PersistEntities();
            SaveGame.SingletonRepository.WandFlavours.PersistEntities();
            SaveGame.SingletonRepository.WizardCommands.PersistEntities();
        }
        catch (NotImplementedException)
        {
            SaveGame.MsgPrint("The persistance interface does not support entity persistance.");
            return;
        }
        catch
        {
            SaveGame.MsgPrint("The persistance interface failed to save the configuration.");
            return;
        }
    }
}
