// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SelfKnowledgeScript : Script, IScript
{
    private SelfKnowledgeScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        int infoCount = 0;
        string[] info = new string[128];
        ItemCharacteristics inventoryCharacteristics = new ItemCharacteristics();
        for (int k = InventorySlot.MeleeWeapon; k < InventorySlot.Total; k++)
        {
            Item? oPtr = SaveGame.GetInventoryItem(k);
            if (oPtr != null)
            {
                oPtr.RefreshFlagBasedProperties();
                inventoryCharacteristics.Merge(oPtr.Characteristics);
            }
        }
        string[]? selfKnowledgeInfo = SaveGame.Race.SelfKnowledge(SaveGame.ExperienceLevel);
        if (selfKnowledgeInfo != null)
        {
            foreach (string infoLine in selfKnowledgeInfo)
            {
                info[infoCount++] = infoLine;
            }
        }
        string[] mutations = SaveGame.Dna.GetMutationList();
        if (mutations.Length > 0)
        {
            foreach (string m in mutations)
            {
                info[infoCount++] = m;
            }
        }
        if (SaveGame.TimedBlindness.TurnsRemaining != 0)
        {
            info[infoCount++] = "You cannot see.";
        }
        if (SaveGame.TimedConfusion.TurnsRemaining != 0)
        {
            info[infoCount++] = "You are confused.";
        }
        if (SaveGame.TimedFear.TurnsRemaining != 0)
        {
            info[infoCount++] = "You are terrified.";
        }
        if (SaveGame.TimedBleeding.TurnsRemaining != 0)
        {
            info[infoCount++] = "You are bleeding.";
        }
        if (SaveGame.TimedStun.TurnsRemaining != 0)
        {
            info[infoCount++] = "You are stunned.";
        }
        if (SaveGame.TimedPoison.TurnsRemaining != 0)
        {
            info[infoCount++] = "You are poisoned.";
        }
        if (SaveGame.TimedHallucinations.TurnsRemaining != 0)
        {
            info[infoCount++] = "You are hallucinating.";
        }
        if (SaveGame.HasAggravation)
        {
            info[infoCount++] = "You aggravate monsters.";
        }
        if (SaveGame.HasRandomTeleport)
        {
            info[infoCount++] = "Your position is very uncertain.";
        }
        if (SaveGame.TimedBlessing.TurnsRemaining != 0)
        {
            info[infoCount++] = "You feel rightous.";
        }
        if (SaveGame.TimedHeroism.TurnsRemaining != 0)
        {
            info[infoCount++] = "You feel heroic.";
        }
        if (SaveGame.TimedSuperheroism.TurnsRemaining != 0)
        {
            info[infoCount++] = "You are in a battle rage.";
        }
        if (SaveGame.TimedProtectionFromEvil.TurnsRemaining != 0)
        {
            info[infoCount++] = "You are protected from evil.";
        }
        if (SaveGame.TimedStoneskin.TurnsRemaining != 0)
        {
            info[infoCount++] = "You are protected by a mystic shield.";
        }
        if (SaveGame.TimedInvulnerability.TurnsRemaining != 0)
        {
            info[infoCount++] = "You are temporarily invulnerable.";
        }
        if (SaveGame.TimedEtherealness.TurnsRemaining != 0)
        {
            info[infoCount++] = "You are temporarily incorporeal.";
        }
        if (SaveGame.HasConfusingTouch)
        {
            info[infoCount++] = "Your hands are glowing dull red.";
        }
        if (SaveGame.IsSearching)
        {
            info[infoCount++] = "You are looking around very carefully.";
        }
        if (SaveGame.SpareSpellSlots != 0)
        {
            info[infoCount++] = "You can learn some spells/prayers.";
        }
        if (SaveGame.WordOfRecallDelay != 0)
        {
            info[infoCount++] = "You will soon be recalled.";
        }
        if (SaveGame.InfravisionRange != 0)
        {
            info[infoCount++] = "Your eyes are sensitive to infrared light.";
        }
        if (SaveGame.HasSeeInvisibility)
        {
            info[infoCount++] = "You can see invisible creatures.";
        }
        if (SaveGame.HasFeatherFall)
        {
            info[infoCount++] = "You can fly.";
        }
        if (SaveGame.HasFreeAction)
        {
            info[infoCount++] = "You have free action.";
        }
        if (SaveGame.HasRegeneration)
        {
            info[infoCount++] = "You regenerate quickly.";
        }
        if (SaveGame.HasSlowDigestion)
        {
            info[infoCount++] = "Your appetite is small.";
        }
        if (SaveGame.HasTelepathy)
        {
            info[infoCount++] = "You have ESP.";
        }
        if (SaveGame.HasHoldLife)
        {
            info[infoCount++] = "You have a firm hold on your life force.";
        }
        if (SaveGame.HasReflection)
        {
            info[infoCount++] = "You reflect arrows and bolts.";
        }
        if (SaveGame.HasFireShield)
        {
            info[infoCount++] = "You are surrounded with a fiery aura.";
        }
        if (SaveGame.HasLightningShield)
        {
            info[infoCount++] = "You are surrounded with electricity.";
        }
        if (SaveGame.HasAntiMagic)
        {
            info[infoCount++] = "You are surrounded by an anti-magic shell.";
        }
        if (SaveGame.HasAntiTeleport)
        {
            info[infoCount++] = "You cannot teleport.";
        }
        if (SaveGame.HasGlow)
        {
            info[infoCount++] = "You are carrying a permanent light.";
        }
        if (SaveGame.HasAcidImmunity)
        {
            info[infoCount++] = "You are completely immune to acid.";
        }
        else if (SaveGame.HasAcidResistance && SaveGame.TimedAcidResistance.TurnsRemaining != 0)
        {
            info[infoCount++] = "You resist acid exceptionally well.";
        }
        else if (SaveGame.HasAcidResistance || SaveGame.TimedAcidResistance.TurnsRemaining != 0)
        {
            info[infoCount++] = "You are resistant to acid.";
        }
        if (SaveGame.HasLightningImmunity)
        {
            info[infoCount++] = "You are completely immune to lightning.";
        }
        else if (SaveGame.HasLightningResistance && SaveGame.TimedLightningResistance.TurnsRemaining != 0)
        {
            info[infoCount++] = "You resist lightning exceptionally well.";
        }
        else if (SaveGame.HasLightningResistance || SaveGame.TimedLightningResistance.TurnsRemaining != 0)
        {
            info[infoCount++] = "You are resistant to lightning.";
        }
        if (SaveGame.HasFireImmunity)
        {
            info[infoCount++] = "You are completely immune to fire.";
        }
        else if (SaveGame.HasFireResistance && SaveGame.TimedFireResistance.TurnsRemaining != 0)
        {
            info[infoCount++] = "You resist fire exceptionally well.";
        }
        else if (SaveGame.HasFireResistance || SaveGame.TimedFireResistance.TurnsRemaining != 0)
        {
            info[infoCount++] = "You are resistant to fire.";
        }
        if (SaveGame.HasColdImmunity)
        {
            info[infoCount++] = "You are completely immune to cold.";
        }
        else if (SaveGame.HasColdResistance && SaveGame.TimedColdResistance.TurnsRemaining != 0)
        {
            info[infoCount++] = "You resist cold exceptionally well.";
        }
        else if (SaveGame.HasColdResistance || SaveGame.TimedColdResistance.TurnsRemaining != 0)
        {
            info[infoCount++] = "You are resistant to cold.";
        }
        if (SaveGame.HasPoisonResistance && SaveGame.TimedPoisonResistance.TurnsRemaining != 0)
        {
            info[infoCount++] = "You resist poison exceptionally well.";
        }
        else if (SaveGame.HasPoisonResistance || SaveGame.TimedPoisonResistance.TurnsRemaining != 0)
        {
            info[infoCount++] = "You are resistant to poison.";
        }
        if (SaveGame.HasLightResistance)
        {
            info[infoCount++] = "You are resistant to bright light.";
        }
        if (SaveGame.HasDarkResistance)
        {
            info[infoCount++] = "You are resistant to darkness.";
        }
        if (SaveGame.HasConfusionResistance)
        {
            info[infoCount++] = "You are resistant to confusion.";
        }
        if (SaveGame.HasSoundResistance)
        {
            info[infoCount++] = "You are resistant to sonic attacks.";
        }
        if (SaveGame.HasDisenchantResistance)
        {
            info[infoCount++] = "You are resistant to disenchantment.";
        }
        if (SaveGame.HasChaosResistance)
        {
            info[infoCount++] = "You are resistant to chaos.";
        }
        if (SaveGame.HasShardResistance)
        {
            info[infoCount++] = "You are resistant to blasts of shards.";
        }
        if (SaveGame.HasNexusResistance)
        {
            info[infoCount++] = "You are resistant to nexus attacks.";
        }
        if (SaveGame.HasNetherResistance)
        {
            info[infoCount++] = "You are resistant to nether forces.";
        }
        if (SaveGame.HasFearResistance)
        {
            info[infoCount++] = "You are completely fearless.";
        }
        if (SaveGame.HasBlindnessResistance)
        {
            info[infoCount++] = "Your eyes are resistant to blindness.";
        }
        if (SaveGame.HasSustainStrength)
        {
            info[infoCount++] = "Your strength is sustained.";
        }
        if (SaveGame.HasSustainIntelligence)
        {
            info[infoCount++] = "Your intelligence is sustained.";
        }
        if (SaveGame.HasSustainWisdom)
        {
            info[infoCount++] = "Your wisdom is sustained.";
        }
        if (SaveGame.HasSustainConstitution)
        {
            info[infoCount++] = "Your constitution is sustained.";
        }
        if (SaveGame.HasSustainDexterity)
        {
            info[infoCount++] = "Your dexterity is sustained.";
        }
        if (SaveGame.HasSustainCharisma)
        {
            info[infoCount++] = "Your charisma is sustained.";
        }
        if (inventoryCharacteristics.Str)
        {
            info[infoCount++] = "Your strength is affected by your equipment.";
        }
        if (inventoryCharacteristics.Int)
        {
            info[infoCount++] = "Your intelligence is affected by your equipment.";
        }
        if (inventoryCharacteristics.Wis)
        {
            info[infoCount++] = "Your wisdom is affected by your equipment.";
        }
        if (inventoryCharacteristics.Dex)
        {
            info[infoCount++] = "Your dexterity is affected by your equipment.";
        }
        if (inventoryCharacteristics.Con)
        {
            info[infoCount++] = "Your constitution is affected by your equipment.";
        }
        if (inventoryCharacteristics.Cha)
        {
            info[infoCount++] = "Your charisma is affected by your equipment.";
        }
        if (inventoryCharacteristics.Stealth)
        {
            info[infoCount++] = "Your stealth is affected by your equipment.";
        }
        if (inventoryCharacteristics.Search)
        {
            info[infoCount++] = "Your searching ability is affected by your equipment.";
        }
        if (inventoryCharacteristics.Infra)
        {
            info[infoCount++] = "Your infravision is affected by your equipment.";
        }
        if (inventoryCharacteristics.Tunnel)
        {
            info[infoCount++] = "Your digging ability is affected by your equipment.";
        }
        if (inventoryCharacteristics.Speed)
        {
            info[infoCount++] = "Your speed is affected by your equipment.";
        }
        if (inventoryCharacteristics.Blows)
        {
            info[infoCount++] = "Your attack speed is affected by your equipment.";
        }
        Item? meleeItem = SaveGame.GetInventoryItem(InventorySlot.MeleeWeapon);
        if (meleeItem != null)
        {
            meleeItem.RefreshFlagBasedProperties();
            if (meleeItem.Characteristics.Blessed)
            {
                info[infoCount++] = "Your weapon has been blessed by the gods.";
            }
            if (meleeItem.Characteristics.Chaotic)
            {
                info[infoCount++] = "Your weapon is branded with the Yellow Sign.";
            }
            if (meleeItem.Characteristics.Impact)
            {
                info[infoCount++] = "The impact of your weapon can cause earthquakes.";
            }
            if (meleeItem.Characteristics.Vorpal)
            {
                info[infoCount++] = "Your weapon is very sharp.";
            }
            if (meleeItem.Characteristics.Vampiric)
            {
                info[infoCount++] = "Your weapon drains life from your foes.";
            }
            if (meleeItem.Characteristics.BrandAcid)
            {
                info[infoCount++] = "Your weapon melts your foes.";
            }
            if (meleeItem.Characteristics.BrandElec)
            {
                info[infoCount++] = "Your weapon shocks your foes.";
            }
            if (meleeItem.Characteristics.BrandFire)
            {
                info[infoCount++] = "Your weapon burns your foes.";
            }
            if (meleeItem.Characteristics.BrandCold)
            {
                info[infoCount++] = "Your weapon freezes your foes.";
            }
            if (meleeItem.Characteristics.BrandPois)
            {
                info[infoCount++] = "Your weapon poisons your foes.";
            }
            if (meleeItem.Characteristics.SlayAnimal)
            {
                info[infoCount++] = "Your weapon strikes at animals with extra force.";
            }
            if (meleeItem.Characteristics.SlayEvil)
            {
                info[infoCount++] = "Your weapon strikes at evil with extra force.";
            }
            if (meleeItem.Characteristics.SlayUndead)
            {
                info[infoCount++] = "Your weapon strikes at undead with holy wrath.";
            }
            if (meleeItem.Characteristics.SlayDemon)
            {
                info[infoCount++] = "Your weapon strikes at demons with holy wrath.";
            }
            if (meleeItem.Characteristics.SlayOrc)
            {
                info[infoCount++] = "Your weapon is especially deadly against orcs.";
            }
            if (meleeItem.Characteristics.SlayTroll)
            {
                info[infoCount++] = "Your weapon is especially deadly against trolls.";
            }
            if (meleeItem.Characteristics.SlayGiant)
            {
                info[infoCount++] = "Your weapon is especially deadly against giants.";
            }
            if (meleeItem.Characteristics.SlayDragon)
            {
                info[infoCount++] = "Your weapon is especially deadly against dragons.";
            }
            if (meleeItem.Characteristics.KillDragon)
            {
                info[infoCount++] = "Your weapon is a great bane of dragons.";
            }
        }
        ScreenBuffer savedScreen = SaveGame.Screen.Clone();
        for (int k = 1; k < 24; k++)
        {
            SaveGame.Screen.PrintLine("", k, 13);
        }
        SaveGame.Screen.PrintLine("     Your Attributes:", 1, 15);
        int row, infoIndex;
        for (row = 2, infoIndex = 0; infoIndex < infoCount; infoIndex++)
        {
            SaveGame.Screen.PrintLine(info[infoIndex], row++, 15);
            if (row == 22 && infoIndex + 1 < infoCount)
            {
                SaveGame.Screen.PrintLine("-- more --", row, 15);
                SaveGame.Inkey();
                for (; row > 2; row--)
                {
                    SaveGame.Screen.PrintLine("", row, 15);
                }
            }
        }
        SaveGame.Screen.PrintLine("[Press any key to continue]", row, 13);
        SaveGame.Inkey();
        SaveGame.Screen.Restore(savedScreen);
    }
}
