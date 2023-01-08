namespace AngbandOS.Commands
{
    /// <summary>
    /// Activate an artifact or similar
    /// </summary>
    /// <param name="itemIndex">
    /// The inventory index of the item to be activated, or -999 to select item
    /// </param>
    [Serializable]
    internal class ActivateCommand : ICommand
    {
        private ActivateCommand(SaveGame saveGame) { } // This object is a singleton.

        public char Key => 'A';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            int itemIndex = -999;
            if (itemIndex == -999)
            {
                // No item passed in, so get one; filtering to activatable items only
                if (!saveGame.GetItem(out itemIndex, "Activate which item? ", true, false, false, new ActivatableItemFilter()))
                {
                    if (itemIndex == -2)
                    {
                        saveGame.MsgPrint("You have nothing to activate.");
                    }
                    return;
                }
            }
            // Get the item from the index
            Item item = itemIndex >= 0 ? saveGame.Player.Inventory[itemIndex] : saveGame.Level.Items[0 - itemIndex];
            // Check if the item is activatable
            if (!saveGame.Player.ItemMatchesFilter(item, new ActivatableItemFilter()))
            {
                saveGame.MsgPrint("You can't activate that!");
                return;
            }
            // Activating an item uses 100 energy
            saveGame.EnergyUse = 100;
            // Get the level of the item
            int itemLevel = item.BaseItemCategory.Level;
            if (item.FixedArtifact != null && item.IsFixedArtifact())
            {
                itemLevel = item.FixedArtifact.Level;
            }
            // Work out the chance of using the item successfully based on its level and the
            // player's skill
            int chance = saveGame.Player.SkillUseDevice;
            if (saveGame.Player.TimedConfusion.TimeRemaining != 0)
            {
                chance /= 2;
            }
            chance -= itemLevel > 50 ? 50 : itemLevel;
            // Always give a slight chance of success
            if (chance < Constants.UseDevice && Program.Rng.RandomLessThan(Constants.UseDevice - chance + 1) == 0)
            {
                chance = Constants.UseDevice;
            }
            // If we fail our use item roll just tell us and quit
            if (chance < Constants.UseDevice || Program.Rng.DieRoll(chance) < Constants.UseDevice)
            {
                saveGame.MsgPrint("You failed to activate it properly.");
                return;
            }
            // If the item is still recharging, then just tell us and quit
            if (item.RechargeTimeLeft != 0)
            {
                saveGame.MsgPrint("It whines, glows and fades...");
                return;
            }
            // We passed the checks, so the item is activated
            saveGame.MsgPrint("You activate it...");
            saveGame.PlaySound(SoundEffect.ActivateArtifact);
            // If it is a random artifact then use its ability and quit
            if (string.IsNullOrEmpty(item.RandartName) == false)
            {
                saveGame.ActivateRandomArtifact(item);
                return;
            }
            // If it's a fixed artifact then use its ability
            if (item.FixedArtifact != null && typeof(IActivatible).IsAssignableFrom(item.FixedArtifact.BaseFixedArtifact.GetType()))
            {
                IActivatible activatibleFixedArtifact = (IActivatible)item.FixedArtifact.BaseFixedArtifact;
                activatibleFixedArtifact.ActivateItem(saveGame, item);
                return;
            }
            // If it wasn't an artifact, then check the other types of activatable item Planar
            // weapon teleports you
            if (item.RareItemTypeIndex == Enumerations.RareItemType.WeaponPlanarWeapon)
            {
                saveGame.TeleportPlayer(100);
                item.RechargeTimeLeft = 50 + Program.Rng.DieRoll(50);
                return;
            }
            // Dragon armour gives you a ball of the relevant damage type
            if (item.Category == ItemTypeEnum.DragArmor)
            {
                if (!saveGame.GetDirectionWithAim(out int dir))
                {
                    return;
                }
                switch (item.ItemSubCategory)
                {
                    case DragonArmour.SvDragonBlue:
                        {
                            saveGame.MsgPrint("You breathe lightning.");
                            saveGame.FireBall(new ProjectElec(saveGame), dir, 100, -2);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(450) + 450;
                            break;
                        }
                    case DragonArmour.SvDragonWhite:
                        {
                            saveGame.MsgPrint("You breathe frost.");
                            saveGame.FireBall(new ProjectCold(saveGame), dir, 110, -2);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(450) + 450;
                            break;
                        }
                    case DragonArmour.SvDragonBlack:
                        {
                            saveGame.MsgPrint("You breathe acid.");
                            saveGame.FireBall(new ProjectAcid(saveGame), dir, 130, -2);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(450) + 450;
                            break;
                        }
                    case DragonArmour.SvDragonGreen:
                        {
                            saveGame.MsgPrint("You breathe poison gas.");
                            saveGame.FireBall(new ProjectPois(saveGame), dir, 150, -2);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(450) + 450;
                            break;
                        }
                    case DragonArmour.SvDragonRed:
                        {
                            saveGame.MsgPrint("You breathe fire.");
                            saveGame.FireBall(new ProjectFire(saveGame), dir, 200, -2);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(450) + 450;
                            break;
                        }
                    case DragonArmour.SvDragonMultihued:
                        {
                            chance = Program.Rng.RandomLessThan(5);
                            string element = chance == 1
                                ? "lightning"
                                : (chance == 2 ? "frost" : (chance == 3 ? "acid" : (chance == 4 ? "poison gas" : "fire")));
                            saveGame.MsgPrint($"You breathe {element}.");
                            switch (chance)
                            {
                                case 0:
                                    saveGame.FireBall(new ProjectFire(saveGame),
                                        dir, 250, -2);
                                    break;

                                case 1:
                                    saveGame.FireBall(new ProjectElec(saveGame),
                                        dir, 250, -2);
                                    break;

                                case 2:
                                    saveGame.FireBall(new ProjectCold(saveGame),
                                        dir, 250, -2);
                                    break;

                                case 3:
                                    saveGame.FireBall(new ProjectAcid(saveGame),
                                        dir, 250, -2);
                                    break;

                                case 4:
                                    saveGame.FireBall(new ProjectPois(saveGame),
                                        dir, 250, -2);
                                    break;
                            }
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(225) + 225;
                            break;
                        }
                    case DragonArmour.SvDragonBronze:
                        {
                            saveGame.MsgPrint("You breathe confusion.");
                            saveGame.FireBall(new ProjectConfusion(saveGame), dir, 120, -2);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(450) + 450;
                            break;
                        }
                    case DragonArmour.SvDragonGold:
                        {
                            saveGame.MsgPrint("You breathe sound.");
                            saveGame.FireBall(new ProjectSound(saveGame), dir, 130, -2);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(450) + 450;
                            break;
                        }
                    case DragonArmour.SvDragonChaos:
                        {
                            chance = Program.Rng.RandomLessThan(2);
                            string element = chance == 1 ? "chaos" : "disenchantment";
                            saveGame.MsgPrint($"You breathe {element}.");
                            saveGame.FireBall(
                                projectile: chance == 1 ? (Projectile)new ProjectChaos(saveGame) : new ProjectDisenchant(saveGame), dir: dir, dam: 220, rad: -2);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(300) + 300;
                            break;
                        }
                    case DragonArmour.SvDragonLaw:
                        {
                            chance = Program.Rng.RandomLessThan(2);
                            string element = chance == 1 ? "sound" : "shards";
                            saveGame.MsgPrint($"You breathe {element}.");
                            saveGame.FireBall(
                                chance == 1 ? (Projectile)new ProjectSound(saveGame) : new ProjectExplode(saveGame), dir, 230, -2);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(300) + 300;
                            break;
                        }
                    case DragonArmour.SvDragonBalance:
                        {
                            chance = Program.Rng.RandomLessThan(4);
                            string element = chance == 1
                                ? "chaos"
                                : (chance == 2 ? "disenchantment" : (chance == 3 ? "sound" : "shards"));
                            saveGame.MsgPrint($"You breathe {element}.");
                            saveGame.FireBall(
                                chance == 1
                                    ? new ProjectChaos(saveGame)
                                    : (chance == 2
                                        ? new ProjectDisenchant(saveGame)
                                        : (chance == 3 ? (Projectile)new ProjectSound(saveGame) : new ProjectExplode(saveGame))), dir, 250, -2);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(300) + 300;
                            break;
                        }
                    case DragonArmour.SvDragonShining:
                        {
                            chance = Program.Rng.RandomLessThan(2);
                            string element = chance == 0 ? "light" : "darkness";
                            saveGame.MsgPrint($"You breathe {element}.");
                            saveGame.FireBall(
                                chance == 0 ? (Projectile)new ProjectLight(saveGame) : new ProjectDark(saveGame), dir, 200, -2);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(300) + 300;
                            break;
                        }
                    case DragonArmour.SvDragonPower:
                        {
                            saveGame.MsgPrint("You breathe the elements.");
                            saveGame.FireBall(new ProjectMissile(saveGame), dir, 300, -3);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(300) + 300;
                            break;
                        }
                }
                return;
            }
            // Elemental rings give you a ball of the appropriate element
            if (item.Category == ItemTypeEnum.Ring)
            {
                if (!saveGame.GetDirectionWithAim(out int dir))
                {
                    return;
                }
                switch (item.ItemSubCategory)
                {
                    case RingType.Acid:
                        {
                            saveGame.FireBall(new ProjectAcid(saveGame), dir, 50, 2);
                            saveGame.Player.TimedAcidResistance.SetTimer(saveGame.Player.TimedAcidResistance.TimeRemaining + Program.Rng.DieRoll(20) + 20);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(50) + 50;
                            break;
                        }
                    case RingType.Ice:
                        {
                            saveGame.FireBall(new ProjectCold(saveGame), dir, 50, 2);
                            saveGame.Player.TimedColdResistance.SetTimer(saveGame.Player.TimedColdResistance.TimeRemaining + Program.Rng.DieRoll(20) + 20);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(50) + 50;
                            break;
                        }
                    case RingType.Flames:
                        {
                            saveGame.FireBall(new ProjectFire(saveGame), dir, 50, 2);
                            saveGame.Player.TimedFireResistance.SetTimer(saveGame.Player.TimedFireResistance.TimeRemaining + Program.Rng.DieRoll(20) + 20);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(50) + 50;
                            break;
                        }
                }
                return;
            }
            // We ran out of item types
            saveGame.MsgPrint("Oops. That object cannot be activated.");
        }
    }
}
