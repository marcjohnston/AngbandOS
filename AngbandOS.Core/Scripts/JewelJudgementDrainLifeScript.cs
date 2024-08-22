// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Reflection.Emit;

namespace AngbandOS.Core.Scripts;

/// <summary>
/// Processes the world turn by draining life from the player, when the player does not have anti-magic, 1 time in 1000.
/// </summary>
[Serializable]
internal class JewelJudgementDrainLifeScript : Script, IScriptItem
{
    private JewelJudgementDrainLifeScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScriptItem(Item item)
    {
        if (Game.DieRoll(999) == 1 && !Game.HasAntiMagic && Game.InvulnerabilityTimer.Value == 0)
        {
            Game.MsgPrint("The Jewel of Judgement drains life from you!");
            Game.TakeHit(Math.Min(Game.ExperienceLevel.IntValue, 50), "the Jewel of Judgement");
        }
    }
}


[Serializable]
internal class GoodBootsEnchantmentScript : Script, IEnhancementScript
{
    private GoodBootsEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusArmorClass += Game.DieRoll(5) + item.GetBonusValue(5, level);
    }
}

[Serializable]
internal class GreatBootsEnchantmentScript : Script, IEnhancementScript
{
    private GreatBootsEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusArmorClass += item.GetBonusValue(10, level);
        if (Game.DieRoll(20) == 1)
        {
            item.CreateRandomArtifact(false);
        }
        else
        {
            switch (Game.DieRoll(24))
            {
                case 1:
                    item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(BootsOfSpeedRareItem));
                    break;
                case 2:
                case 3:
                case 4:
                case 5:
                    item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(BootsOfFreeActionRareItem));
                    break;
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                    item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(BootsOfStealthRareItem));
                    break;
                case 14:
                case 15:
                case 16:
                case 17:
                case 18:
                case 19:
                case 20:
                case 21:
                case 22:
                case 23:
                case 24:
                    item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(BootsWingedRareItem));
                    if (Game.DieRoll(2) == 1)
                    {
                        item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemAdditiveBundleWeightedRandom>(nameof(FixedArtifactItemAdditiveBundleWeightedRandom)));
                    }
                    break;
            }
        }
    }
}

[Serializable]
internal class PoorBootsEnchantmentScript : Script, IEnhancementScript
{
    private PoorBootsEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusArmorClass -= Game.DieRoll(5) + item.GetBonusValue(5, level);
        if (item.BonusArmorClass < 0)
        {
            item.IsCursed = true;
        }
    }
}

[Serializable]
internal class TerribleBootsEnchantmentScript : Script, IEnhancementScript
{
    private TerribleBootsEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusArmorClass -= item.GetBonusValue(10, level);
        switch (Game.DieRoll(3))
        {
            case 1:
                item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(BootsOfNoiseRareItem));
                break;
            case 2:
                item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(BootsOfSlownessRareItem));
                break;
            case 3:
                item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(BootsOfAnnoyanceRareItem));
                break;
        }
        if (item.BonusArmorClass < 0)
        {
            item.IsCursed = true;
        }
    }
}





[Serializable]
internal class GoodCloakEnchantmentScript : Script, IEnhancementScript
{
    private GoodCloakEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusArmorClass += Game.DieRoll(5) + item.GetBonusValue(5, level);
    }
}

[Serializable]
internal class GreatCloakEnchantmentScript : Script, IEnhancementScript
{
    private GreatCloakEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusArmorClass += item.GetBonusValue(10, level);
        if (Game.DieRoll(20) == 1)
        {
            item.CreateRandomArtifact(false);
        }
        else
        {
            item.RareItem = Game.SingletonRepository.Get<RareItemWeightedRandom>(nameof(CloakGoodRareItemWeightedRandom)).ChooseOrDefault();
        }
    }
}

[Serializable]
internal class PoorCloakEnchantmentScript : Script, IEnhancementScript
{
    private PoorCloakEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusArmorClass -= Game.DieRoll(5) + item.GetBonusValue(5, level);
        if (item.BonusArmorClass < 0)
        {
            item.IsCursed = true;
        }
    }
}

[Serializable]
internal class TerribleCloakEnchantmentScript : Script, IEnhancementScript
{
    private TerribleCloakEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusArmorClass -= item.GetBonusValue(10, level);
        item.RareItem = Game.SingletonRepository.Get<RareItemWeightedRandom>(nameof(CloakPoorRareItemWeightedRandom)).ChooseOrDefault();
        if (item.BonusArmorClass < 0)
        {
            item.IsCursed = true;
        }
    }
}






[Serializable]
internal class GoodCrownEnchantmentScript : Script, IEnhancementScript
{
    private GoodCrownEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusArmorClass += Game.DieRoll(5) + item.GetBonusValue(5, level);
    }
}

[Serializable]
internal class GreatCrownEnchantmentScript : Script, IEnhancementScript
{
    private GreatCrownEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusArmorClass += item.GetBonusValue(10, level);
        if (Game.DieRoll(20) == 1)
        {
            item.CreateRandomArtifact(false);
        }
        else
        {
            switch (Game.DieRoll(8))
            {
                case 1:
                    item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(HatOfTheMagiRareItem));
                    item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemAdditiveBundleWeightedRandom>(nameof(FixedArtifactItemAdditiveBundleWeightedRandom)));
                    break;
                case 2:
                    item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(HatOfMightRareItem));
                    item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemAdditiveBundleWeightedRandom>(nameof(FixedArtifactItemAdditiveBundleWeightedRandom)));
                    break;
                case 3:
                    item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(HatOfTelepathyRareItem));
                    break;
                case 4:
                    item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(HatOfRegenerationRareItem));
                    break;
                case 5:
                case 6:
                    item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(HatOfLordlinessRareItem));
                    item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemAdditiveBundleWeightedRandom>(nameof(FixedArtifactItemAdditiveBundleWeightedRandom)));
                    break;
                case 7:
                case 8:
                    item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(HatOfSeeingRareItem));
                    if (Game.DieRoll(3) == 1)
                    {
                        item.Characteristics.Telepathy = true;
                    }
                    break;
            }
        }
    }
}

[Serializable]
internal class PoorCrownEnchantmentScript : Script, IEnhancementScript
{
    private PoorCrownEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusArmorClass -= Game.DieRoll(5) + item.GetBonusValue(5, level);
        if (item.BonusArmorClass < 0)
        {
            item.IsCursed = true;
        }
    }
}

[Serializable]
internal class TerribleCrownEnchantmentScript : Script, IEnhancementScript
{
    private TerribleCrownEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusArmorClass -= item.GetBonusValue(10, level);
        item.RareItem = Game.SingletonRepository.Get<RareItemWeightedRandom>(nameof(CrownPoorRareItemWeightedRandom)).ChooseOrDefault();
        if (item.BonusArmorClass < 0)
        {
            item.IsCursed = true;
        }
    }
}




[Serializable]
internal class GoodDragonScaleMailEnchantmentScript : Script, IEnhancementScript
{
    private GoodDragonScaleMailEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusArmorClass += Game.DieRoll(5) + item.GetBonusValue(5, level);
    }
}

[Serializable]
internal class GreatDragonScaleMailEnchantmentScript : Script, IEnhancementScript
{
    private GreatDragonScaleMailEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusArmorClass += item.GetBonusValue(10, level);
    }
}

[Serializable]
internal class PoorDragonScaleMailEnchantmentScript : Script, IEnhancementScript
{
    private PoorDragonScaleMailEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusArmorClass -= Game.DieRoll(5) + item.GetBonusValue(5, level);
        if (item.BonusArmorClass < 0)
        {
            item.IsCursed = true;
        }
    }
}

[Serializable]
internal class TerribleDragonScaleMailEnchantmentScript : Script, IEnhancementScript
{
    private TerribleDragonScaleMailEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusArmorClass -= item.GetBonusValue(10, level);
        if (item.BonusArmorClass < 0)
        {
            item.IsCursed = true;
        }
    }
}



[Serializable]
internal class GoodGlovesEnchantmentScript : Script, IEnhancementScript
{
    private GoodGlovesEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusArmorClass += Game.DieRoll(5) + item.GetBonusValue(5, level);
    }
}

[Serializable]
internal class GreatGlovesEnchantmentScript : Script, IEnhancementScript
{
    private GreatGlovesEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusArmorClass += item.GetBonusValue(10, level);

        if (Game.DieRoll(20) == 1)
        {
            item.CreateRandomArtifact(false);
        }
        else
        {
            switch (Game.DieRoll(10))
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(GlovesOfFreeActionRareItem));
                    break;
                case 5:
                case 6:
                case 7:
                    item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(GlovesOfSlayingRareItem));
                    break;
                case 8:
                case 9:
                    item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(GlovesOfAgilityRareItem));
                    break;
                case 10:
                    item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(GlovesOfPowerRareItem));
                    item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemAdditiveBundleWeightedRandom>(nameof(FixedArtifactItemAdditiveBundleWeightedRandom)));
                    break;
            }
        }
    }
}

[Serializable]
internal class PoorGlovesEnchantmentScript : Script, IEnhancementScript
{
    private PoorGlovesEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusArmorClass -= Game.DieRoll(5) + item.GetBonusValue(5, level);
        if (item.BonusArmorClass < 0)
        {
            item.IsCursed = true;
        }
    }
}

[Serializable]
internal class TerribleGlovesEnchantmentScript : Script, IEnhancementScript
{
    private TerribleGlovesEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusArmorClass -= item.GetBonusValue(10, level);
        if (item.BonusArmorClass < 0)
        {
            item.IsCursed = true;
        }

        item.RareItem = Game.SingletonRepository.Get<RareItemWeightedRandom>(nameof(GlovesPoorRareItemWeightedRandom)).ChooseOrDefault();
    }
}







[Serializable]
internal class GoodHardArmorEnchantmentScript : Script, IEnhancementScript
{
    private GoodHardArmorEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusArmorClass += Game.DieRoll(5) + item.GetBonusValue(5, level);
    }
}

[Serializable]
internal class GreatHardArmorEnchantmentScript : Script, IEnhancementScript
{
    private GreatHardArmorEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusArmorClass += item.GetBonusValue(10, level);

        switch (Game.DieRoll(21))
        {
            case 1:
            case 2:
            case 3:
            case 4:
                item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ArmorOfResistAcidRareItem));
                break;
            case 5:
            case 6:
            case 7:
            case 8:
                item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ArmorOfResistLightningRareItem));
                break;
            case 9:
            case 10:
            case 11:
            case 12:
                item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ArmorOfResistFireRareItem));
                break;
            case 13:
            case 14:
            case 15:
            case 16:
                item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ArmorOfResistColdRareItem));
                break;
            case 17:
            case 18:
                item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ArmorOfResistanceRareItem));
                if (Game.DieRoll(4) == 1)
                {
                    item.Characteristics.ResPois = true;
                }
                item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemAdditiveBundleWeightedRandom>(nameof(FixedArtifactItemAdditiveBundleWeightedRandom)));
                break;
            case 19:
                item.CreateRandomArtifact(false);
                break;
            case 20:
            case 21:
                item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ArmorOfYithRareItem));
                break;
        }
    }
}

[Serializable]
internal class PoorHardArmorEnchantmentScript : Script, IEnhancementScript
{
    private PoorHardArmorEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusArmorClass -= Game.DieRoll(5) + item.GetBonusValue(5, level);
        if (item.BonusArmorClass < 0)
        {
            item.IsCursed = true;
        }
    }
}

[Serializable]
internal class TerribleHardArmorEnchantmentScript : Script, IEnhancementScript
{
    private TerribleHardArmorEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusArmorClass -= item.GetBonusValue(10, level);
        if (item.BonusArmorClass < 0)
        {
            item.IsCursed = true;
        }
    }
}











[Serializable]
internal class GoodHelmEnchantmentScript : Script, IEnhancementScript
{
    private GoodHelmEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusArmorClass += Game.DieRoll(5) + item.GetBonusValue(5, level);
    }
}

[Serializable]
internal class GreatHelmEnchantmentScript : Script, IEnhancementScript
{
    private GreatHelmEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusArmorClass += item.GetBonusValue(10, level);

        if (Game.DieRoll(20) == 1)
        {
            item.CreateRandomArtifact(false);
        }
        else
        {
            switch (Game.DieRoll(14))
            {
                case 1:
                case 2:
                    item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(HatOfIntelligenceRareItem));
                    break;
                case 3:
                case 4:
                    item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(HatOfWisdomRareItem));
                    break;
                case 5:
                case 6:
                    item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(HatOfBeautyRareItem));
                    break;
                case 7:
                case 8:
                    item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(HatOfSeeingRareItem));
                    if (Game.DieRoll(7) == 1)
                    {
                        item.Characteristics.Telepathy = true;
                    }
                    break;
                case 9:
                case 10:
                    item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(HatOfLightRareItem));
                    break;
                case 11:
                case 12:
                case 13:
                case 14:
                    item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(HatOfInfravisionRareItem));
                    break;
            }
        }
    }
}

[Serializable]
internal class PoorHelmEnchantmentScript : Script, IEnhancementScript
{
    private PoorHelmEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusArmorClass -= Game.DieRoll(5) + item.GetBonusValue(5, level);
        if (item.BonusArmorClass < 0)
        {
            item.IsCursed = true;
        }
    }
}

[Serializable]
internal class TerribleHelmEnchantmentScript : Script, IEnhancementScript
{
    private TerribleHelmEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusArmorClass -= item.GetBonusValue(10, level);
        if (item.BonusArmorClass < 0)
        {
            item.IsCursed = true;
        }

        item.RareItem = Game.SingletonRepository.Get<RareItemWeightedRandom>(nameof(HelmPoorRareItemWeightedRandom)).ChooseOrDefault();
    }
}

[Serializable]
internal class DragonResistanceEnchantmentScript : Script, IEnhancementScript
{
    private DragonResistanceEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        do
        {
            if (Game.DieRoll(4) == 1)
            {
                item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemAdditiveBundleWeightedRandom>(nameof(NaturalAndPoisonResistanceItemAdditiveBundleWeightedRandom)));
            }
            else
            {
                item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemAdditiveBundleWeightedRandom>(nameof(FixedArtifactItemAdditiveBundleWeightedRandom)));
            }
        } while (Game.DieRoll(2) == 1);
    }
}


[Serializable]
internal class GoodShieldEnchantmentScript : Script, IEnhancementScript
{
    private GoodShieldEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusArmorClass += Game.DieRoll(5) + item.GetBonusValue(5, level);
    }
}

[Serializable]
internal class GreatShieldEnchantmentScript : Script, IEnhancementScript
{
    private GreatShieldEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusArmorClass += item.GetBonusValue(10, level);

        switch (Game.DieRoll(23))
        {
            case 1:
            case 11:
                item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ShieldOfResistAcidRareItem));
                break;
            case 2:
            case 3:
            case 4:
            case 12:
            case 13:
            case 14:
                item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ShieldOfResistLightningRareItem));
                break;
            case 5:
            case 6:
            case 15:
            case 16:
                item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ShieldOfResistFireRareItem));
                break;
            case 7:
            case 8:
            case 9:
            case 17:
            case 18:
            case 19:
                item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ShieldOfResistColdRareItem));
                break;
            case 10:
            case 20:
                item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemAdditiveBundleWeightedRandom>(nameof(ResistanceAndBiasItemAdditiveBundleWeightedRandom)));
                if (Game.DieRoll(4) == 1)
                {
                    item.Characteristics.ResPois = true;
                }
                item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ShieldOfResistanceRareItem));
                break;
            case 21:
            case 22:
                item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ShieldOfReflectionRareItem));
                break;
            case 23:
                item.CreateRandomArtifact(false);
                break;
        }
    }
}

[Serializable]
internal class PoorShieldEnchantmentScript : Script, IEnhancementScript
{
    private PoorShieldEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusArmorClass -= Game.DieRoll(5) + item.GetBonusValue(5, level);
        if (item.BonusArmorClass < 0)
        {
            item.IsCursed = true;
        }
    }
}

[Serializable]
internal class TerribleShieldEnchantmentScript : Script, IEnhancementScript
{
    private TerribleShieldEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusArmorClass -= item.GetBonusValue(10, level);
        if (item.BonusArmorClass < 0)
        {
            item.IsCursed = true;
        }
    }
}



[Serializable]
internal class GreatRobeSoftArmorEnchantmentScript : Script, IEnhancementScript
{
    private GreatRobeSoftArmorEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusArmorClass += item.GetBonusValue(10, level);

        // Robes have a chance of having the armor of permanence instead of a random characteristic.
        if (Game.RandomLessThan(100) < 10)
        {
            item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ArmorOfPermanenceRareItem));
        }
        else
        {
            switch (Game.DieRoll(21))
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ArmorOfResistAcidRareItem));
                    break;
                case 5:
                case 6:
                case 7:
                case 8:
                    item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ArmorOfResistLightningRareItem));
                    break;
                case 9:
                case 10:
                case 11:
                case 12:
                    item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ArmorOfResistFireRareItem));
                    break;
                case 13:
                case 14:
                case 15:
                case 16:
                    item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ArmorOfResistColdRareItem));
                    break;
                case 17:
                case 18:
                    item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ArmorOfResistanceRareItem));
                    if (Game.DieRoll(4) == 1)
                    {
                        item.Characteristics.ResPois = true;
                    }
                    item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemAdditiveBundleWeightedRandom>(nameof(FixedArtifactItemAdditiveBundleWeightedRandom)));
                    break;
                case 19:
                    item.CreateRandomArtifact(false);
                    break;
                case 20:
                case 21:
                    item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ArmorOfYithRareItem));
                    break;
            }
        }
    }
}

[Serializable]
internal class GoodSoftArmorEnchantmentScript : Script, IEnhancementScript
{
    private GoodSoftArmorEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusArmorClass += Game.DieRoll(5) + item.GetBonusValue(5, level);
    }
}

[Serializable]
internal class GreatSoftArmorEnchantmentScript : Script, IEnhancementScript
{
    private GreatSoftArmorEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusArmorClass += item.GetBonusValue(10, level);

        switch (Game.DieRoll(21))
        {
            case 1:
            case 2:
            case 3:
            case 4:
                item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ArmorOfResistAcidRareItem));
                break;
            case 5:
            case 6:
            case 7:
            case 8:
                item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ArmorOfResistLightningRareItem));
                break;
            case 9:
            case 10:
            case 11:
            case 12:
                item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ArmorOfResistFireRareItem));
                break;
            case 13:
            case 14:
            case 15:
            case 16:
                item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ArmorOfResistColdRareItem));
                break;
            case 17:
            case 18:
                item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ArmorOfResistanceRareItem));
                if (Game.DieRoll(4) == 1)
                {
                    item.Characteristics.ResPois = true;
                }
                item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemAdditiveBundleWeightedRandom>(nameof(FixedArtifactItemAdditiveBundleWeightedRandom)));
                break;
            case 19:
                item.CreateRandomArtifact(false);
                break;
            case 20:
            case 21:
                item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(ArmorOfYithRareItem));
                break;
        }
    }
}

[Serializable]
internal class PoorSoftArmorEnchantmentScript : Script, IEnhancementScript
{
    private PoorSoftArmorEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusArmorClass -= Game.DieRoll(5) + item.GetBonusValue(5, level);
        if (item.BonusArmorClass < 0)
        {
            item.IsCursed = true;
        }
    }
}

[Serializable]
internal class TerribleSoftArmorEnchantmentScript : Script, IEnhancementScript
{
    private TerribleSoftArmorEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusArmorClass -= item.GetBonusValue(10, level);
        if (item.BonusArmorClass < 0)
        {
            item.IsCursed = true;
        }
    }
}


[Serializable]
internal class ChestEnchantmentScript : Script, IEnhancementScript
{
    private ChestEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// Logic:
    /// If the chest is on the town level (level == 0 [not sure where the wilderness is]), it is not trapped (default TypeSpecificValue).
    /// A die roll from 1 to the level of the chest is made.  Any value >55 will convert to a random chest trap between 55 and 63.
    /// </remarks>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        if (item.LevelNormallyFound > 0)
        {
            int chestType = Game.DieRoll(item.LevelNormallyFound);
            item.ContainerIsOpen = false;
            int chestTrapConfigurationCount = Game.SingletonRepository.Count<ChestTrapConfiguration>();
            int eightFivePercent = chestTrapConfigurationCount * 100 / 85;
            if (chestType > eightFivePercent)
            {
                int randomRemaining = chestTrapConfigurationCount - eightFivePercent;
                chestType = eightFivePercent + Game.RandomLessThan(randomRemaining);
            }
            item.ContainerTraps = Game.SingletonRepository.Get<ChestTrapConfiguration>(chestType).Traps;
            item.LevelOfObjectsInContainer = chestType;
        }
    }
}




[Serializable]
internal class CursedEnchantmentScript : Script, IEnhancementScript
{
    private CursedEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// Logic:
    /// If the chest is on the town level (level == 0 [not sure where the wilderness is]), it is not trapped (default TypeSpecificValue).
    /// A die roll from 1 to the level of the chest is made.  Any value >55 will convert to a random chest trap between 55 and 63.
    /// </remarks>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.IsCursed = true;
    }
}


[Serializable]
internal class BrokenAndCursedEnchantmentScript : Script, IEnhancementScript
{
    private BrokenAndCursedEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// Logic:
    /// If the chest is on the town level (level == 0 [not sure where the wilderness is]), it is not trapped (default TypeSpecificValue).
    /// A die roll from 1 to the level of the chest is made.  Any value >55 will convert to a random chest trap between 55 and 63.
    /// </remarks>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.IsBroken = true;
        item.IsCursed = true;
    }
}

[Serializable]
internal class BonusCharismaEnchantmentScript : Script, IEnhancementScript
{
    private BonusCharismaEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// Logic:
    /// If the chest is on the town level (level == 0 [not sure where the wilderness is]), it is not trapped (default TypeSpecificValue).
    /// A die roll from 1 to the level of the chest is made.  Any value >55 will convert to a random chest trap between 55 and 63.
    /// </remarks>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusCharisma = 1 + item.GetBonusValue(5, level);
    }
}

[Serializable]
internal class PoorCharismaEnchantmentScript : Script, IEnhancementScript
{
    private PoorCharismaEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// Logic:
    /// If the chest is on the town level (level == 0 [not sure where the wilderness is]), it is not trapped (default TypeSpecificValue).
    /// A die roll from 1 to the level of the chest is made.  Any value >55 will convert to a random chest trap between 55 and 63.
    /// </remarks>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusCharisma = 0 - (1 + item.GetBonusValue(5, level));
    }
}


[Serializable]
internal class BonusWisdomEnchantmentScript : Script, IEnhancementScript
{
    private BonusWisdomEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// Logic:
    /// If the chest is on the town level (level == 0 [not sure where the wilderness is]), it is not trapped (default TypeSpecificValue).
    /// A die roll from 1 to the level of the chest is made.  Any value >55 will convert to a random chest trap between 55 and 63.
    /// </remarks>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusWisdom = 1 + item.GetBonusValue(5, level);
    }
}

[Serializable]
internal class PoorWisdomEnchantmentScript : Script, IEnhancementScript
{
    private PoorWisdomEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// Logic:
    /// If the chest is on the town level (level == 0 [not sure where the wilderness is]), it is not trapped (default TypeSpecificValue).
    /// A die roll from 1 to the level of the chest is made.  Any value >55 will convert to a random chest trap between 55 and 63.
    /// </remarks>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusWisdom = 0 - (1 + item.GetBonusValue(5, level));
    }
}



[Serializable]
internal class PoorStatsEnchantmentScript : Script, IEnhancementScript
{
    private PoorStatsEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// Logic:
    /// If the chest is on the town level (level == 0 [not sure where the wilderness is]), it is not trapped (default TypeSpecificValue).
    /// A die roll from 1 to the level of the chest is made.  Any value >55 will convert to a random chest trap between 55 and 63.
    /// </remarks>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusCharisma = 0 - (Game.DieRoll(5) + item.GetBonusValue(5, level));
        item.BonusConstitution = item.BonusCharisma;
        item.BonusDexterity = item.BonusCharisma;
        item.BonusStrength = item.BonusCharisma;
        item.BonusIntelligence = item.BonusCharisma;
        item.BonusWisdom = item.BonusCharisma;
    }
}

[Serializable]
internal class BonusArmorClass1D5P5BEnchantmentScript : Script, IEnhancementScript
{
    private BonusArmorClass1D5P5BEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// Logic:
    /// If the chest is on the town level (level == 0 [not sure where the wilderness is]), it is not trapped (default TypeSpecificValue).
    /// A die roll from 1 to the level of the chest is made.  Any value >55 will convert to a random chest trap between 55 and 63.
    /// </remarks>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusArmorClass = Game.DieRoll(5) + item.GetBonusValue(5, level);
    }
}

[Serializable]
internal class PoorArmorClass1D5B5EnchantmentScript : Script, IEnhancementScript
{
    private PoorArmorClass1D5B5EnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// Logic:
    /// If the chest is on the town level (level == 0 [not sure where the wilderness is]), it is not trapped (default TypeSpecificValue).
    /// A die roll from 1 to the level of the chest is made.  Any value >55 will convert to a random chest trap between 55 and 63.
    /// </remarks>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusArmorClass = 0 - (Game.DieRoll(5) + item.GetBonusValue(5, level));
    }
}

[Serializable]
internal class BonusSearchEnchantmentScript : Script, IEnhancementScript
{
    private BonusSearchEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// Logic:
    /// If the chest is on the town level (level == 0 [not sure where the wilderness is]), it is not trapped (default TypeSpecificValue).
    /// A die roll from 1 to the level of the chest is made.  Any value >55 will convert to a random chest trap between 55 and 63.
    /// </remarks>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusSearch = Game.DieRoll(5) + item.GetBonusValue(5, level);
    }
}

[Serializable]
internal class PoorSearchEnchantmentScript : Script, IEnhancementScript
{
    private PoorSearchEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// Logic:
    /// If the chest is on the town level (level == 0 [not sure where the wilderness is]), it is not trapped (default TypeSpecificValue).
    /// A die roll from 1 to the level of the chest is made.  Any value >55 will convert to a random chest trap between 55 and 63.
    /// </remarks>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusSearch = 0 - (Game.DieRoll(5) + item.GetBonusValue(5, level));
    }
}


[Serializable]
internal class BonusSlowDigest1In3EnchantmentScript : Script, IEnhancementScript
{
    private BonusSlowDigest1In3EnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// Logic:
    /// If the chest is on the town level (level == 0 [not sure where the wilderness is]), it is not trapped (default TypeSpecificValue).
    /// A die roll from 1 to the level of the chest is made.  Any value >55 will convert to a random chest trap between 55 and 63.
    /// </remarks>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        if (Game.DieRoll(3) == 1)
        {
            item.Characteristics.SlowDigest = true;
        }
    }
}


[Serializable]
internal class RandomResistance1In3EnchantmentScript : Script, IEnhancementScript
{
    private RandomResistance1In3EnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// Logic:
    /// If the chest is on the town level (level == 0 [not sure where the wilderness is]), it is not trapped (default TypeSpecificValue).
    /// A die roll from 1 to the level of the chest is made.  Any value >55 will convert to a random chest trap between 55 and 63.
    /// </remarks>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        if (Game.DieRoll(3) == 1)
        {
            item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemAdditiveBundleWeightedRandom>(nameof(ResistanceAndBiasItemAdditiveBundleWeightedRandom)));
        }
    }
}


[Serializable]
internal class ResistPoisonIn5EnchantmentScript : Script, IEnhancementScript
{
    private ResistPoisonIn5EnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// Logic:
    /// If the chest is on the town level (level == 0 [not sure where the wilderness is]), it is not trapped (default TypeSpecificValue).
    /// A die roll from 1 to the level of the chest is made.  Any value >55 will convert to a random chest trap between 55 and 63.
    /// </remarks>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        if (Game.DieRoll(5) == 1)
        {
            item.Characteristics.ResPois = true;
        }
    }
}



[Serializable]
internal class BonusHit1D8P10BP5EnchantmentScript : Script, IEnhancementScript
{
    private BonusHit1D8P10BP5EnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// Logic:
    /// If the chest is on the town level (level == 0 [not sure where the wilderness is]), it is not trapped (default TypeSpecificValue).
    /// A die roll from 1 to the level of the chest is made.  Any value >55 will convert to a random chest trap between 55 and 63.
    /// </remarks>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusHit = 5 + Game.DieRoll(8) + item.GetBonusValue(10, level);
    }
}

[Serializable]
internal class PoorHit1D8P10BP5EnchantmentScript : Script, IEnhancementScript
{
    private PoorHit1D8P10BP5EnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// Logic:
    /// If the chest is on the town level (level == 0 [not sure where the wilderness is]), it is not trapped (default TypeSpecificValue).
    /// A die roll from 1 to the level of the chest is made.  Any value >55 will convert to a random chest trap between 55 and 63.
    /// </remarks>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusHit = 0 - (5 + Game.DieRoll(8) + item.GetBonusValue(10, level));
    }
}


[Serializable]
internal class BonusArmorClass1D5P10BP5EnchantmentScript : Script, IEnhancementScript
{
    private BonusArmorClass1D5P10BP5EnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// Logic:
    /// If the chest is on the town level (level == 0 [not sure where the wilderness is]), it is not trapped (default TypeSpecificValue).
    /// A die roll from 1 to the level of the chest is made.  Any value >55 will convert to a random chest trap between 55 and 63.
    /// </remarks>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusArmorClass = 5 + Game.DieRoll(5) + item.GetBonusValue(10, level);
    }
}

[Serializable]
internal class BonusConstitution5BP1EnchantmentScript : Script, IEnhancementScript
{
    private BonusConstitution5BP1EnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// Logic:
    /// If the chest is on the town level (level == 0 [not sure where the wilderness is]), it is not trapped (default TypeSpecificValue).
    /// A die roll from 1 to the level of the chest is made.  Any value >55 will convert to a random chest trap between 55 and 63.
    /// </remarks>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusConstitution = 1 + item.GetBonusValue(5, level);
    }
}


[Serializable]
internal class PoorConstitution5BP1EnchantmentScript : Script, IEnhancementScript
{
    private PoorConstitution5BP1EnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// Logic:
    /// If the chest is on the town level (level == 0 [not sure where the wilderness is]), it is not trapped (default TypeSpecificValue).
    /// A die roll from 1 to the level of the chest is made.  Any value >55 will convert to a random chest trap between 55 and 63.
    /// </remarks>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusConstitution = 0 - (1 + item.GetBonusValue(5, level));
    }
}

[Serializable]
internal class BonusDamage1D8P10BP5EnchantmentScript : Script, IEnhancementScript
{
    private BonusDamage1D8P10BP5EnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// Logic:
    /// If the chest is on the town level (level == 0 [not sure where the wilderness is]), it is not trapped (default TypeSpecificValue).
    /// A die roll from 1 to the level of the chest is made.  Any value >55 will convert to a random chest trap between 55 and 63.
    /// </remarks>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusDamage = 5 + Game.DieRoll(8) + item.GetBonusValue(10, level);
    }
}

[Serializable]
internal class PoorDamage1D8P10BP5EnchantmentScript : Script, IEnhancementScript
{
    private PoorDamage1D8P10BP5EnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// Logic:
    /// If the chest is on the town level (level == 0 [not sure where the wilderness is]), it is not trapped (default TypeSpecificValue).
    /// A die roll from 1 to the level of the chest is made.  Any value >55 will convert to a random chest trap between 55 and 63.
    /// </remarks>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusDamage = 0 - (5 + Game.DieRoll(8) + item.GetBonusValue(10, level));
    }
}

[Serializable]
internal class BonusDexterity5BP1EnchantmentScript : Script, IEnhancementScript
{
    private BonusDexterity5BP1EnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// Logic:
    /// If the chest is on the town level (level == 0 [not sure where the wilderness is]), it is not trapped (default TypeSpecificValue).
    /// A die roll from 1 to the level of the chest is made.  Any value >55 will convert to a random chest trap between 55 and 63.
    /// </remarks>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusDexterity = 1 + item.GetBonusValue(5, level);
    }
}

[Serializable]
internal class PoorDexterity5BP1EnchantmentScript : Script, IEnhancementScript
{
    private PoorDexterity5BP1EnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// Logic:
    /// If the chest is on the town level (level == 0 [not sure where the wilderness is]), it is not trapped (default TypeSpecificValue).
    /// A die roll from 1 to the level of the chest is made.  Any value >55 will convert to a random chest trap between 55 and 63.
    /// </remarks>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusDexterity = 0 - (1 + item.GetBonusValue(5, level));
    }
}

[Serializable]
internal class BonusAttacks3BEnchantmentScript : Script, IEnhancementScript
{
    private BonusAttacks3BEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// Logic:
    /// If the chest is on the town level (level == 0 [not sure where the wilderness is]), it is not trapped (default TypeSpecificValue).
    /// A die roll from 1 to the level of the chest is made.  Any value >55 will convert to a random chest trap between 55 and 63.
    /// </remarks>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusAttacks = Math.Max(1, item.GetBonusValue(3, level));
    }
}

[Serializable]
internal class PoorAttacks3BEnchantmentScript : Script, IEnhancementScript
{
    private PoorAttacks3BEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// Logic:
    /// If the chest is on the town level (level == 0 [not sure where the wilderness is]), it is not trapped (default TypeSpecificValue).
    /// A die roll from 1 to the level of the chest is made.  Any value >55 will convert to a random chest trap between 55 and 63.
    /// </remarks>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusAttacks = 0 - (Math.Max(1, item.GetBonusValue(3, level)));
    }
}

[Serializable]
internal class BonusIntelligence5BP1EnchantmentScript : Script, IEnhancementScript
{
    private BonusIntelligence5BP1EnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// Logic:
    /// If the chest is on the town level (level == 0 [not sure where the wilderness is]), it is not trapped (default TypeSpecificValue).
    /// A die roll from 1 to the level of the chest is made.  Any value >55 will convert to a random chest trap between 55 and 63.
    /// </remarks>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusIntelligence = 1 + item.GetBonusValue(5, level);
    }
}

[Serializable]
internal class PoorIntelligence5BP1EnchantmentScript : Script, IEnhancementScript
{
    private PoorIntelligence5BP1EnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// Logic:
    /// If the chest is on the town level (level == 0 [not sure where the wilderness is]), it is not trapped (default TypeSpecificValue).
    /// A die roll from 1 to the level of the chest is made.  Any value >55 will convert to a random chest trap between 55 and 63.
    /// </remarks>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusIntelligence = 0 - (1 + item.GetBonusValue(5, level));
    }
}

[Serializable]
internal class LordlyProtectionEnchantmentScript : Script, IEnhancementScript
{
    private LordlyProtectionEnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// Logic:
    /// If the chest is on the town level (level == 0 [not sure where the wilderness is]), it is not trapped (default TypeSpecificValue).
    /// A die roll from 1 to the level of the chest is made.  Any value >55 will convert to a random chest trap between 55 and 63.
    /// </remarks>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        do
        {
            item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemAdditiveBundleWeightedRandom>(nameof(LordlyResistanceItemAdditiveBundleWeightedRandom)));
        } while (Game.DieRoll(4) == 1);
        item.BonusArmorClass = 10 + Game.DieRoll(5) + item.GetBonusValue(10, level);
    }
}

[Serializable]
internal class BonusArmorClass1D8P10BP5EnchantmentScript : Script, IEnhancementScript
{
    private BonusArmorClass1D8P10BP5EnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// Logic:
    /// If the chest is on the town level (level == 0 [not sure where the wilderness is]), it is not trapped (default TypeSpecificValue).
    /// A die roll from 1 to the level of the chest is made.  Any value >55 will convert to a random chest trap between 55 and 63.
    /// </remarks>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusArmorClass = 5 + Game.DieRoll(8) + item.GetBonusValue(10, level);
    }
}

[Serializable]
internal class PoorArmorClass1D8P10BP5EnchantmentScript : Script, IEnhancementScript
{
    private PoorArmorClass1D8P10BP5EnchantmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// Logic:
    /// If the chest is on the town level (level == 0 [not sure where the wilderness is]), it is not trapped (default TypeSpecificValue).
    /// A die roll from 1 to the level of the chest is made.  Any value >55 will convert to a random chest trap between 55 and 63.
    /// </remarks>
    public void ExecuteEnchantmentScript(Item item, int level)
    {
        item.BonusArmorClass = 0 - (5 + Game.DieRoll(8) + item.GetBonusValue(10, level));
    }
}

