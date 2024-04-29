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
            Game.SingletonRepository.PersistEntities<ArtifactBias>();
            Game.SingletonRepository.PersistEntities<AttackEffect>();
            Game.SingletonRepository.PersistEntities<Attack>();
            Game.SingletonRepository.PersistEntities<BirthStage>();
            Game.SingletonRepository.PersistEntities<BaseCharacterClass>();
            Game.SingletonRepository.PersistEntities<ChestTrapConfiguration>();
            Game.SingletonRepository.PersistEntities<ChestTrap>();
            Game.SingletonRepository.PersistEntities<ClassSpell>();
            Game.SingletonRepository.PersistEntities<DungeonGuardian>();
            Game.SingletonRepository.PersistEntities<Dungeon>();
            Game.SingletonRepository.PersistEntities<FixedArtifact>();
            Game.SingletonRepository.PersistEntities<GameCommand>();
            Game.SingletonRepository.PersistEntities<Gender>();
            Game.SingletonRepository.PersistEntities<God>();
            Game.SingletonRepository.PersistEntities<HelpGroup>();
            Game.SingletonRepository.PersistEntities<BaseInventorySlot>();
            Game.SingletonRepository.PersistEntities<ItemClass>();
            Game.SingletonRepository.PersistEntities<ItemFactory>();
            Game.SingletonRepository.PersistEntities<MartialArtsAttack>();
            Game.SingletonRepository.PersistEntities<MonsterFilter>();
            Game.SingletonRepository.PersistEntities<MonsterRace>();
            Game.SingletonRepository.PersistEntities<MonsterSpell>();
            Game.SingletonRepository.PersistEntities<MushroomReadableFlavor>();
            Game.SingletonRepository.PersistEntities<Mutation>();
            Game.SingletonRepository.PersistEntities<Patron>();
            Game.SingletonRepository.PersistEntities<Plural>();
            Game.SingletonRepository.PersistEntities<PotionReadableFlavor>();
            Game.SingletonRepository.PersistEntities<ProjectileGraphic>();
            Game.SingletonRepository.PersistEntities<Projectile>();
            Game.SingletonRepository.PersistEntities<Race>();
            Game.SingletonRepository.PersistEntities<RareItem>();
            Game.SingletonRepository.PersistEntities<Realm>();
            Game.SingletonRepository.PersistEntities<Reward>();
            Game.SingletonRepository.PersistEntities<RingReadableFlavor>();
            Game.SingletonRepository.PersistEntities<RodReadableFlavor>();
            Game.SingletonRepository.PersistEntities<RoomLayout>();
            Game.SingletonRepository.PersistEntities<Script>();
            Game.SingletonRepository.PersistEntities<ScrollReadableFlavor>();
            Game.SingletonRepository.PersistEntities<Shopkeeper>();
            Game.SingletonRepository.PersistEntities<SpellResistantDetection>();
            Game.SingletonRepository.PersistEntities<Spell>();
            Game.SingletonRepository.PersistEntities<StaffReadableFlavor>();
            Game.SingletonRepository.PersistEntities<StoreCommand>();
            Game.SingletonRepository.PersistEntities<StoreFactory>();
            Game.SingletonRepository.PersistEntities<Symbol>();
            Game.SingletonRepository.PersistEntities<Talent>();
            Game.SingletonRepository.PersistEntities<Tile>();
            Game.SingletonRepository.PersistEntities<Timer>();
            Game.SingletonRepository.PersistEntities<Town>();
            Game.SingletonRepository.PersistEntities<Vault>();
            Game.SingletonRepository.PersistEntities<WandReadableFlavor>();
            Game.SingletonRepository.PersistEntities<WizardCommand>();
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
