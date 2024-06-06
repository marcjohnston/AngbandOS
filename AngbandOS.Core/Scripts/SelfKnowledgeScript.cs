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
    private SelfKnowledgeScript(Game game) : base(game) { }

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
            Item? oPtr = Game.GetInventoryItem(k);
            if (oPtr != null)
            {
                ItemCharacteristics characteristics = oPtr.RefreshFlagBasedProperties();
                inventoryCharacteristics.Merge(characteristics);
            }
        }
        string[]? selfKnowledgeInfo = Game.Race.SelfKnowledge(Game.ExperienceLevel.IntValue);
        if (selfKnowledgeInfo != null)
        {
            foreach (string infoLine in selfKnowledgeInfo)
            {
                info[infoCount++] = infoLine;
            }
        }
        string[] mutations = Game.GetMutationList();
        if (mutations.Length > 0)
        {
            foreach (string m in mutations)
            {
                info[infoCount++] = m;
            }
        }
        if (Game.BlindnessTimer.Value != 0)
        {
            info[infoCount++] = "You cannot see.";
        }
        if (Game.ConfusedTimer.Value != 0)
        {
            info[infoCount++] = "You are confused.";
        }
        if (Game.FearTimer.Value != 0)
        {
            info[infoCount++] = "You are terrified.";
        }
        if (Game.BleedingTimer.Value != 0)
        {
            info[infoCount++] = "You are bleeding.";
        }
        if (Game.StunTimer.Value != 0)
        {
            info[infoCount++] = "You are stunned.";
        }
        if (Game.PoisonTimer.Value != 0)
        {
            info[infoCount++] = "You are poisoned.";
        }
        if (Game.HallucinationsTimer.Value != 0)
        {
            info[infoCount++] = "You are hallucinating.";
        }
        if (Game.HasAggravation)
        {
            info[infoCount++] = "You aggravate monsters.";
        }
        if (Game.HasRandomTeleport)
        {
            info[infoCount++] = "Your position is very uncertain.";
        }
        if (Game.BlessingTimer.Value != 0)
        {
            info[infoCount++] = "You feel rightous.";
        }
        if (Game.HeroismTimer.Value != 0)
        {
            info[infoCount++] = "You feel heroic.";
        }
        if (Game.SuperheroismTimer.Value != 0)
        {
            info[infoCount++] = "You are in a battle rage.";
        }
        if (Game.ProtectionFromEvilTimer.Value != 0)
        {
            info[infoCount++] = "You are protected from evil.";
        }
        if (Game.StoneskinTimer.Value != 0)
        {
            info[infoCount++] = "You are protected by a mystic shield.";
        }
        if (Game.InvulnerabilityTimer.Value != 0)
        {
            info[infoCount++] = "You are temporarily invulnerable.";
        }
        if (Game.EtherealnessTimer.Value != 0)
        {
            info[infoCount++] = "You are temporarily incorporeal.";
        }
        if (Game.HasConfusingTouch)
        {
            info[infoCount++] = "Your hands are glowing dull red.";
        }
        if (Game.IsSearching)
        {
            info[infoCount++] = "You are looking around very carefully.";
        }
        if (Game.SpareSpellSlots.IntValue != 0)
        {
            info[infoCount++] = "You can learn some spells/prayers.";
        }
        if (Game.WordOfRecallDelay != 0)
        {
            info[infoCount++] = "You will soon be recalled.";
        }
        if (Game.InfravisionRange != 0)
        {
            info[infoCount++] = "Your eyes are sensitive to infrared light.";
        }
        if (Game.HasSeeInvisibility)
        {
            info[infoCount++] = "You can see invisible creatures.";
        }
        if (Game.HasFeatherFall)
        {
            info[infoCount++] = "You can fly.";
        }
        if (Game.HasFreeAction)
        {
            info[infoCount++] = "You have free action.";
        }
        if (Game.HasRegeneration)
        {
            info[infoCount++] = "You regenerate quickly.";
        }
        if (Game.HasSlowDigestion)
        {
            info[infoCount++] = "Your appetite is small.";
        }
        if (Game.HasTelepathy)
        {
            info[infoCount++] = "You have ESP.";
        }
        if (Game.HasHoldLife)
        {
            info[infoCount++] = "You have a firm hold on your life force.";
        }
        if (Game.HasReflection)
        {
            info[infoCount++] = "You reflect arrows and bolts.";
        }
        if (Game.HasFireShield)
        {
            info[infoCount++] = "You are surrounded with a fiery aura.";
        }
        if (Game.HasLightningShield)
        {
            info[infoCount++] = "You are surrounded with electricity.";
        }
        if (Game.HasAntiMagic)
        {
            info[infoCount++] = "You are surrounded by an anti-magic shell.";
        }
        if (Game.HasAntiTeleport)
        {
            info[infoCount++] = "You cannot teleport.";
        }
        if (Game.GlowInTheDarkRadius > 0)
        {
            info[infoCount++] = "Your skin glows in the dark.";
        }
        if (Game.HasAcidImmunity)
        {
            info[infoCount++] = "You are completely immune to acid.";
        }
        else if (Game.HasAcidResistance && Game.AcidResistanceTimer.Value != 0)
        {
            info[infoCount++] = "You resist acid exceptionally well.";
        }
        else if (Game.HasAcidResistance || Game.AcidResistanceTimer.Value != 0)
        {
            info[infoCount++] = "You are resistant to acid.";
        }
        if (Game.HasLightningImmunity)
        {
            info[infoCount++] = "You are completely immune to lightning.";
        }
        else if (Game.HasLightningResistance && Game.LightningResistanceTimer.Value != 0)
        {
            info[infoCount++] = "You resist lightning exceptionally well.";
        }
        else if (Game.HasLightningResistance || Game.LightningResistanceTimer.Value != 0)
        {
            info[infoCount++] = "You are resistant to lightning.";
        }
        if (Game.HasFireImmunity)
        {
            info[infoCount++] = "You are completely immune to fire.";
        }
        else if (Game.HasFireResistance && Game.FireResistanceTimer.Value != 0)
        {
            info[infoCount++] = "You resist fire exceptionally well.";
        }
        else if (Game.HasFireResistance || Game.FireResistanceTimer.Value != 0)
        {
            info[infoCount++] = "You are resistant to fire.";
        }
        if (Game.HasColdImmunity)
        {
            info[infoCount++] = "You are completely immune to cold.";
        }
        else if (Game.HasColdResistance && Game.ColdResistanceTimer.Value != 0)
        {
            info[infoCount++] = "You resist cold exceptionally well.";
        }
        else if (Game.HasColdResistance || Game.ColdResistanceTimer.Value != 0)
        {
            info[infoCount++] = "You are resistant to cold.";
        }
        if (Game.HasPoisonResistance && Game.PoisonResistanceTimer.Value != 0)
        {
            info[infoCount++] = "You resist poison exceptionally well.";
        }
        else if (Game.HasPoisonResistance || Game.PoisonResistanceTimer.Value != 0)
        {
            info[infoCount++] = "You are resistant to poison.";
        }
        if (Game.HasLightResistance)
        {
            info[infoCount++] = "You are resistant to bright light.";
        }
        if (Game.HasDarkResistance)
        {
            info[infoCount++] = "You are resistant to darkness.";
        }
        if (Game.HasConfusionResistance)
        {
            info[infoCount++] = "You are resistant to confusion.";
        }
        if (Game.HasSoundResistance)
        {
            info[infoCount++] = "You are resistant to sonic attacks.";
        }
        if (Game.HasDisenchantResistance)
        {
            info[infoCount++] = "You are resistant to disenchantment.";
        }
        if (Game.HasChaosResistance)
        {
            info[infoCount++] = "You are resistant to chaos.";
        }
        if (Game.HasShardResistance)
        {
            info[infoCount++] = "You are resistant to blasts of shards.";
        }
        if (Game.HasNexusResistance)
        {
            info[infoCount++] = "You are resistant to nexus attacks.";
        }
        if (Game.HasNetherResistance)
        {
            info[infoCount++] = "You are resistant to nether forces.";
        }
        if (Game.HasFearResistance)
        {
            info[infoCount++] = "You are completely fearless.";
        }
        if (Game.HasBlindnessResistance)
        {
            info[infoCount++] = "Your eyes are resistant to blindness.";
        }
        if (Game.HasSustainStrength)
        {
            info[infoCount++] = "Your strength is sustained.";
        }
        if (Game.HasSustainIntelligence)
        {
            info[infoCount++] = "Your intelligence is sustained.";
        }
        if (Game.HasSustainWisdom)
        {
            info[infoCount++] = "Your wisdom is sustained.";
        }
        if (Game.HasSustainConstitution)
        {
            info[infoCount++] = "Your constitution is sustained.";
        }
        if (Game.HasSustainDexterity)
        {
            info[infoCount++] = "Your dexterity is sustained.";
        }
        if (Game.HasSustainCharisma)
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
        Item? meleeItem = Game.GetInventoryItem(InventorySlot.MeleeWeapon);
        if (meleeItem != null)
        {
            ItemCharacteristics characteristics = meleeItem.RefreshFlagBasedProperties();
            if (characteristics.Blessed)
            {
                info[infoCount++] = "Your weapon has been blessed by the gods.";
            }
            if (characteristics.Chaotic)
            {
                info[infoCount++] = "Your weapon is branded with the Yellow Sign.";
            }
            if (characteristics.Impact)
            {
                info[infoCount++] = "The impact of your weapon can cause earthquakes.";
            }
            if (characteristics.Vorpal)
            {
                info[infoCount++] = "Your weapon is very sharp.";
            }
            if (characteristics.Vampiric)
            {
                info[infoCount++] = "Your weapon drains life from your foes.";
            }
            if (characteristics.BrandAcid)
            {
                info[infoCount++] = "Your weapon melts your foes.";
            }
            if (characteristics.BrandElec)
            {
                info[infoCount++] = "Your weapon shocks your foes.";
            }
            if (characteristics.BrandFire)
            {
                info[infoCount++] = "Your weapon burns your foes.";
            }
            if (characteristics.BrandCold)
            {
                info[infoCount++] = "Your weapon freezes your foes.";
            }
            if (characteristics.BrandPois)
            {
                info[infoCount++] = "Your weapon poisons your foes.";
            }
            if (characteristics.SlayAnimal)
            {
                info[infoCount++] = "Your weapon strikes at animals with extra force.";
            }
            if (characteristics.SlayEvil)
            {
                info[infoCount++] = "Your weapon strikes at evil with extra force.";
            }
            if (characteristics.SlayUndead)
            {
                info[infoCount++] = "Your weapon strikes at undead with holy wrath.";
            }
            if (characteristics.SlayDemon)
            {
                info[infoCount++] = "Your weapon strikes at demons with holy wrath.";
            }
            if (characteristics.SlayOrc)
            {
                info[infoCount++] = "Your weapon is especially deadly against orcs.";
            }
            if (characteristics.SlayTroll)
            {
                info[infoCount++] = "Your weapon is especially deadly against trolls.";
            }
            if (characteristics.SlayGiant)
            {
                info[infoCount++] = "Your weapon is especially deadly against giants.";
            }
            if (characteristics.SlayDragon)
            {
                info[infoCount++] = "Your weapon is especially deadly against dragons.";
            }
            if (characteristics.KillDragon)
            {
                info[infoCount++] = "Your weapon is a great bane of dragons.";
            }
        }
        ScreenBuffer savedScreen = Game.Screen.Clone();
        for (int k = 1; k < 24; k++)
        {
            Game.Screen.PrintLine("", k, 13);
        }
        Game.Screen.PrintLine("     Your Attributes:", 1, 15);
        int row, infoIndex;
        for (row = 2, infoIndex = 0; infoIndex < infoCount; infoIndex++)
        {
            Game.Screen.PrintLine(info[infoIndex], row++, 15);
            if (row == 22 && infoIndex + 1 < infoCount)
            {
                Game.Screen.PrintLine("-- more --", row, 15);
                Game.Inkey();
                for (; row > 2; row--)
                {
                    Game.Screen.PrintLine("", row, 15);
                }
            }
        }
        Game.Screen.PrintLine("[Press any key to continue]", row, 13);
        Game.Inkey();
        Game.Screen.Restore(savedScreen);
    }
}
