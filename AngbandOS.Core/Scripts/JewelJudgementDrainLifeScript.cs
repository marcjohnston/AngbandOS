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
internal class BonusCharisma5BP1EnchantmentScript : Script, IEnhancementScript
{
    private BonusCharisma5BP1EnchantmentScript(Game game) : base(game) { }

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
internal class PoorCharisma5BP1EnchantmentScript : Script, IEnhancementScript
{
    private PoorCharisma5BP1EnchantmentScript(Game game) : base(game) { }

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
internal class PoorCharismaAndWisdom5BP1EnchantmentScript : Script, IEnhancementScript
{
    private PoorCharismaAndWisdom5BP1EnchantmentScript(Game game) : base(game) { }

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
        item.BonusWisdom = item.BonusCharisma;
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
internal class PoorArmorClass10BP5EnchantmentScript : Script, IEnhancementScript
{
    private PoorArmorClass10BP5EnchantmentScript(Game game) : base(game) { }

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
        item.BonusArmorClass = 0 - (5 + item.GetBonusValue(10, level));
    }
}

[Serializable]
internal class BonusSearch1D5P5BEnchantmentScript : Script, IEnhancementScript
{
    private BonusSearch1D5P5BEnchantmentScript(Game game) : base(game) { }

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
internal class PoorSearch1D5P5BEnchantmentScript : Script, IEnhancementScript
{
    private PoorSearch1D5P5BEnchantmentScript(Game game) : base(game) { }

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
internal class BonusSearch5BP1EnchantmentScript : Script, IEnhancementScript
{
    private BonusSearch5BP1EnchantmentScript(Game game) : base(game) { }

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
        item.BonusSearch = 1 + item.GetBonusValue(5, level);
    }
}

[Serializable]
internal class PoorSearch5BP1EnchantmentScript : Script, IEnhancementScript
{
    private PoorSearch5BP1EnchantmentScript(Game game) : base(game) { }

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
        item.BonusSearch = 0 - (1 + item.GetBonusValue(5, level));
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
        item.BonusHit += 5 + Game.DieRoll(8) + item.GetBonusValue(10, level);
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
        item.BonusHit -= 5 + Game.DieRoll(8) + item.GetBonusValue(10, level);
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
        item.BonusDamage += 5 + Game.DieRoll(8) + item.GetBonusValue(10, level);
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
        item.BonusDamage -= 5 + Game.DieRoll(8) + item.GetBonusValue(10, level);
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


[Serializable]
internal class BonusDamage1D7P10BEnchantmentScript : Script, IEnhancementScript
{
    private BonusDamage1D7P10BEnchantmentScript(Game game) : base(game) { }

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
        item.BonusDamage += Game.DieRoll(7) + item.GetBonusValue(10, level);
    }
}

[Serializable]
internal class PoorDamage1D7P10BEnchantmentScript : Script, IEnhancementScript
{
    private PoorDamage1D7P10BEnchantmentScript(Game game) : base(game) { }

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
        item.BonusDamage -= Game.DieRoll(7) + item.GetBonusValue(10, level);
    }
}

[Serializable]
internal class BonusHit1D7P10BEnchantmentScript : Script, IEnhancementScript
{
    private BonusHit1D7P10BEnchantmentScript(Game game) : base(game) { }

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
        item.BonusHit += Game.DieRoll(7) + item.GetBonusValue(10, level);
    }
}

[Serializable]
internal class PoorHit1D7P10BEnchantmentScript : Script, IEnhancementScript
{
    private PoorHit1D7P10BEnchantmentScript(Game game) : base(game) { }

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
        item.BonusHit -= Game.DieRoll(7) + item.GetBonusValue(10, level);
    }
}

[Serializable]
internal class BonusHit1D5P5BEnchantmentScript : Script, IEnhancementScript
{
    private BonusHit1D5P5BEnchantmentScript(Game game) : base(game) { }

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
        item.BonusHit += Game.DieRoll(5) + item.GetBonusValue(5, level);
    }
}

[Serializable]
internal class PoorHit1D5P5BEnchantmentScript : Script, IEnhancementScript
{
    private PoorHit1D5P5BEnchantmentScript(Game game) : base(game) { }

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
        item.BonusHit -= (Game.DieRoll(5) + item.GetBonusValue(5, level));
    }
}

[Serializable]
internal class GreatHit1D5P5BP10BEnchantmentScript : Script, IEnhancementScript
{
    private GreatHit1D5P5BP10BEnchantmentScript(Game game) : base(game) { }

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
        item.BonusHit += Game.DieRoll(5) + item.GetBonusValue(5, level) + item.GetBonusValue(10, level);
    }
}

[Serializable]
internal class GoodHit1D5P5BEnchantmentScript : Script, IEnhancementScript
{
    private GoodHit1D5P5BEnchantmentScript(Game game) : base(game) { }

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
        item.BonusHit += Game.DieRoll(5) + item.GetBonusValue(5, level);
    }
}

[Serializable]
internal class GreatAmmoEnchantmentScript : Script, IEnhancementScript
{
    private GreatAmmoEnchantmentScript(Game game) : base(game) { }

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
        switch (Game.DieRoll(12))
        {
            case 1:
            case 2:
            case 3:
                item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(AmmoOfWoundingRareItem));
                break;
            case 4:
                item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(AmmoOfFlameRareItem));
                break;
            case 5:
                item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(AmmoOfFrostRareItem));
                break;
            case 6:
            case 7:
                item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(AmmoOfHurtAnimalRareItem));
                break;
            case 8:
            case 9:
                item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(AmmoOfHurtEvilRareItem));
                break;
            case 10:
                item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(AmmoOfHurtDragonRareItem));
                break;
            case 11:
                item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(AmmoOfShockingRareItem));
                break;
            case 12:
                item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(AmmoOfSlayingRareItem));
                item.DamageDice++;
                break;
        }
        while (Game.RandomLessThan(10 * item.DamageDice * item.DamageSides) == 0)
        {
            item.DamageDice++;
        }
        if (item.DamageDice > 9)
        {
            item.DamageDice = 9;
        }
    }
}

[Serializable]
internal class GreatDiggerEnchantmentScript : Script, IEnhancementScript
{
    private GreatDiggerEnchantmentScript(Game game) : base(game) { }

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
        item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(WeaponOfDiggingRareItem));
    }
}

[Serializable]
internal class PoorDiggerEnchantmentScript : Script, IEnhancementScript
{
    private PoorDiggerEnchantmentScript(Game game) : base(game) { }

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
        item.BonusTunnel = 0 - item.BonusTunnel;
    }
}


[Serializable]
internal class TerribleHit1D5P5BP10BBEnchantmentScript : Script, IEnhancementScript
{
    private TerribleHit1D5P5BP10BBEnchantmentScript(Game game) : base(game) { }

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
        item.BonusHit -= Game.DieRoll(5) + item.GetBonusValue(5, level) + item.GetBonusValue(10, level);
    }
}

[Serializable]
internal class BonusDamage10BEnchantmentScript : Script, IEnhancementScript
{
    private BonusDamage10BEnchantmentScript(Game game) : base(game) { }

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
        item.BonusDamage += item.GetBonusValue(10, level);
    }
}

[Serializable]
internal class GoodDamage1D5P5BEnchantmentScript : Script, IEnhancementScript
{
    private GoodDamage1D5P5BEnchantmentScript(Game game) : base(game) { }

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
        item.BonusDamage += Game.DieRoll(5) + item.GetBonusValue(5, level);
    }
}

[Serializable]
internal class GreatDamage1D5P5BP10BEnchantmentScript : Script, IEnhancementScript
{
    private GreatDamage1D5P5BP10BEnchantmentScript(Game game) : base(game) { }

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
        item.BonusDamage += Game.DieRoll(5) + item.GetBonusValue(5, level) + item.GetBonusValue(10, level);
    }
}

[Serializable]
internal class PoorDamage10BEnchantmentScript : Script, IEnhancementScript
{
    private PoorDamage10BEnchantmentScript(Game game) : base(game) { }

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
        item.BonusDamage -= item.GetBonusValue(10, level);
    }
}

[Serializable]
internal class PoorDamage1D5P5BEnchantmentScript : Script, IEnhancementScript
{
    private PoorDamage1D5P5BEnchantmentScript(Game game) : base(game) { }

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
        item.BonusDamage -= Game.DieRoll(5) + item.GetBonusValue(5, level);
    }
}

[Serializable]
internal class TerribleDamage10BEnchantmentScript : Script, IEnhancementScript
{
    private TerribleDamage10BEnchantmentScript(Game game) : base(game) { }

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
        item.BonusDamage -= 2 * item.GetBonusValue(10, level);
    }
}

[Serializable]
internal class AmmoOfBackbitingEnchantmentScript : Script, IEnhancementScript
{
    private AmmoOfBackbitingEnchantmentScript(Game game) : base(game) { }

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
        if (Game.RandomLessThan(Constants.MaxDepth) < level)
        {
            item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(AmmoOfBackbitingRareItem));
        }
    }
}

[Serializable]
internal class TerribleDiggerEnchantmentScript : Script, IEnhancementScript
{
    private TerribleDiggerEnchantmentScript(Game game) : base(game) { }

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
        item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(TerribleWeaponOfDiggingRareItem));
    }
}

[Serializable]
internal class TerribleAmmoEnchantmentScript : Script, IEnhancementScript
{
    private TerribleAmmoEnchantmentScript(Game game) : base(game) { }

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
        item.BonusHit -= Game.DieRoll(5) + item.GetBonusValue(5, level) + item.GetBonusValue(10, level);
        item.BonusDamage -= Game.DieRoll(5) + item.GetBonusValue(5, level) + item.GetBonusValue(10, level);
        if (Game.RandomLessThan(Constants.MaxDepth) < level)
        {
            item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(AmmoOfBackbitingRareItem));
        }
    }
}


[Serializable]
internal class BonusSpeed1D5P5BEnchantmentScript : Script, IEnhancementScript
{
    private BonusSpeed1D5P5BEnchantmentScript(Game game) : base(game) { }

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
        item.BonusSpeed = Game.DieRoll(5) + item.GetBonusValue(5, level);
        while (Game.RandomLessThan(100) < 50)
        {
            item.BonusSpeed++;
        }
    }
}

[Serializable]
internal class PoorSpeed1D5P5EnchantmentScript : Script, IEnhancementScript
{
    private PoorSpeed1D5P5EnchantmentScript(Game game) : base(game) { }

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
        item.BonusSpeed = Game.DieRoll(5) + item.GetBonusValue(5, level);
        while (Game.RandomLessThan(100) < 50)
        {
            item.BonusSpeed++;
        }
        item.BonusSpeed = 0 - item.BonusSpeed;
    }
}

[Serializable]
internal class BonusStrength5BP1EnchantmentScript : Script, IEnhancementScript
{
    private BonusStrength5BP1EnchantmentScript(Game game) : base(game) { }

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
        item.BonusStrength = 1 + item.GetBonusValue(5, level);
    }
}

[Serializable]
internal class PoorStrength5BP1EnchantmentScript : Script, IEnhancementScript
{
    private PoorStrength5BP1EnchantmentScript(Game game) : base(game) { }

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
        item.BonusStrength = 0 - (1 + item.GetBonusValue(5, level));
    }
}

[Serializable]
internal class GoodOrbOfLightEnchantmentScript : Script, IEnhancementScript
{
    private GoodOrbOfLightEnchantmentScript(Game game) : base(game) { }

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
        WeightedRandom<ItemAdditiveBundle> weightedRandom = new WeightedRandom<ItemAdditiveBundle>(Game);
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfAcidRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfLightningRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfLightRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfDarknessRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfLifeRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfSightRareItem)));
        weightedRandom.Add(2, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfCourageRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfVenomRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfClarityRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfSoundRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfChaosRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfShardsRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfUnlifeRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfStabilityRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfMagicRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfFreedomRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfStrengthRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfWisdomRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfFlameRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfDexterityRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfConstitutionRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfIntelligenceRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfCharismaRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfLightnessRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfInsightRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfTheMindRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfSustenanceRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfHealthRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfFrostRareItem)));
        item.RareItem = weightedRandom.ChooseOrDefault();
    }
}


[Serializable]
internal class GreatOrbOfLightEnchantmentScript : Script, IEnhancementScript
{
    private GreatOrbOfLightEnchantmentScript(Game game) : base(game) { }

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
        item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfPowerRareItem));
        for (int i = 0; i < 3; i++)
        {
            WeightedRandomAction weightedRandomAction = new WeightedRandomAction(Game);
            weightedRandomAction.Add(2, () => item.Characteristics.ResDark = true);
            weightedRandomAction.Add(1, () => item.Characteristics.ResLight = true);
            weightedRandomAction.Add(1, () => item.Characteristics.ResBlind = true);
            weightedRandomAction.Add(1, () => item.Characteristics.ResFear = true);
            weightedRandomAction.Add(1, () => item.Characteristics.ResAcid = true);
            weightedRandomAction.Add(1, () => item.Characteristics.ResElec = true);
            weightedRandomAction.Add(1, () => item.Characteristics.ResFire = true);
            weightedRandomAction.Add(1, () => item.Characteristics.ResCold = true);
            weightedRandomAction.Add(1, () => item.Characteristics.ResPois = true);
            weightedRandomAction.Add(1, () => item.Characteristics.ResConf = true);
            weightedRandomAction.Add(1, () => item.Characteristics.ResSound = true);
            weightedRandomAction.Add(1, () => item.Characteristics.ResShards = true);
            weightedRandomAction.Add(1, () => item.Characteristics.ResNether = true);
            weightedRandomAction.Add(1, () => item.Characteristics.ResNexus = true);
            weightedRandomAction.Add(1, () => item.Characteristics.ResChaos = true);
            weightedRandomAction.Add(1, () => item.Characteristics.ResDisen = true);
            weightedRandomAction.Add(1, () => item.Characteristics.FreeAct = true);
            weightedRandomAction.Add(1, () => item.Characteristics.HoldLife = true);
            weightedRandomAction.Add(1, () => item.Characteristics.SustStr = true);
            weightedRandomAction.Add(1, () => item.Characteristics.SustInt = true);
            weightedRandomAction.Add(1, () => item.Characteristics.SustWis = true);
            weightedRandomAction.Add(1, () => item.Characteristics.SustDex = true);
            weightedRandomAction.Add(1, () => item.Characteristics.SustCon = true);
            weightedRandomAction.Add(1, () => item.Characteristics.SustCha = true);
            weightedRandomAction.Add(1, () => item.Characteristics.Feather = true);
            weightedRandomAction.Add(1, () => item.Characteristics.SeeInvis = true);
            weightedRandomAction.Add(1, () => item.Characteristics.Telepathy = true);
            weightedRandomAction.Add(1, () => item.Characteristics.SlowDigest = true);
            weightedRandomAction.Add(1, () => item.Characteristics.Regen = true);
            weightedRandomAction.Choose();
        }
    }
}


[Serializable]
internal class PoorOrbOfLightEnchantmentScript : Script, IEnhancementScript
{
    private PoorOrbOfLightEnchantmentScript(Game game) : base(game) { }

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
        switch (Game.DieRoll(2)) // Cursed
        {
            case 1:
                {
                    item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfIrritationRareItem));
                    item.IsBroken = true;
                    item.IsCursed = true;
                    break;
                }
            case 2:
                {
                    item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfInstabilityRareItem));
                    item.IsBroken = true;
                    item.IsCursed = true;
                    break;
                }
        }
    }
}


[Serializable]
internal class CursedWeaponEnchantmentScript : Script, IEnhancementScript
{
    private CursedWeaponEnchantmentScript(Game game) : base(game) { }

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
        if (item.BonusHit + item.BonusDamage < 0)
        {
            item.IsCursed = true;
        }
    }
}


[Serializable]
internal class FillLanternEnchantmentScript : Script, IEnhancementScript
{
    private FillLanternEnchantmentScript(Game game) : base(game) { }

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
        item.TurnsOfLightRemaining = Constants.FuelLamp / 2;
    }
}

[Serializable]
internal class UsedLanternEnchantmentScript : Script, IEnhancementScript
{
    private UsedLanternEnchantmentScript(Game game) : base(game) { }

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
        if (item.TurnsOfLightRemaining != 0)
        {
            item.TurnsOfLightRemaining = Game.DieRoll(item.TurnsOfLightRemaining);
        }
    }
}

[Serializable]
internal class FillTorchEnchantmentScript : Script, IEnhancementScript
{
    private FillTorchEnchantmentScript(Game game) : base(game) { }

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
        item.TurnsOfLightRemaining = Constants.FuelTorch / 2;
    }
}

[Serializable]
internal class UsedTorchEnchantmentScript : Script, IEnhancementScript
{
    private UsedTorchEnchantmentScript(Game game) : base(game) { }

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
        if (item.TurnsOfLightRemaining != 0)
        {
            item.TurnsOfLightRemaining = Game.DieRoll(item.TurnsOfLightRemaining);
        }
    }
}

