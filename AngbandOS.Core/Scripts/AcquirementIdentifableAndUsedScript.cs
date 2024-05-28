// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System;
using System.Diagnostics.Tracing;

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class AcquirementIdentifableAndUsedScript : Script, IIdentifableAndUsedScript
{
    private AcquirementIdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifableAndUsedScript()
    {
        Game.Acquirement(Game.MapY.IntValue, Game.MapX.IntValue, 1, true);
        return (true, true);
    }
}

[Serializable]
internal class AggravateMonstersIdentifableAndUsedScript : Script, IIdentifableAndUsedScript
{
    private AggravateMonstersIdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifableAndUsedScript()
    {
        Game.MsgPrint("There is a high pitched humming noise.");
        Game.AggravateMonsters();
        return (true, true);
    }
}


[Serializable]
internal class Blessing1D12P6IdentifableAndUsedScript : Script, IIdentifableAndUsedScript
{
    private Blessing1D12P6IdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifableAndUsedScript()
    {
        if (!Game.BlessingTimer.AddTimer(Game.DieRoll(12) + 6))
        {
            return (false, true);
        }
        return (true, true);
    }
}


[Serializable]
internal class GenocideIdentifableAndUsedScript : Script, IIdentifableAndUsedScript
{
    private GenocideIdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifableAndUsedScript()
    {
        Game.RunScript(nameof(GenocideScript));
        return (true, true);
    }
}


[Serializable]
internal class ChaosBall222R4IdentifableAndUsedScript : Script, IIdentifableAndUsedScript
{
    private ChaosBall222R4IdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifableAndUsedScript()
    {
        Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(ChaosProjectile)), 0, 222, 4);
        if (!Game.HasChaosResistance)
        {
            Game.TakeHit(111 + Game.DieRoll(111), "a Scroll of Chaos");
        }
        return (true, true);
    }
}


[Serializable]
internal class CreateRandomArtifactIdentifableAndUsedScript : Script, IIdentifableAndUsedScript
{
    private CreateRandomArtifactIdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifableAndUsedScript()
    {
        Game.RunScript(nameof(CreateRandomArtifactScript));
        return (true, true);
    }
}


[Serializable]
internal class CurseArmorIdentifableAndUsedScript : Script, IIdentifableAndUsedScript
{
    private CurseArmorIdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifableAndUsedScript()
    {
        if (!Game.CurseArmor())
        {
            return (false, true);
        }
        return (true, true);
    }
}


[Serializable]
internal class CurseWeaponIdentifableAndUsedScript : Script, IIdentifableAndUsedScript
{
    private CurseWeaponIdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifableAndUsedScript()
    {
        if (!Game.CurseWeapon())
        {
            return (false, true);
        }
        return (true, true);
    }
}


[Serializable]
internal class DarknessIdentifableAndUsedScript : Script, IIdentifableAndUsedScript
{
    private DarknessIdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifableAndUsedScript()
    {
        if (!Game.HasBlindnessResistance && !Game.HasDarkResistance)
        {
            Game.BlindnessTimer.AddTimer(3 + Game.DieRoll(5));
        }
        if (!Game.UnlightArea(10, 3))
        {
            return (false, true);
        }
        return (true, true);
    }
}


[Serializable]
internal class DestructionR15IdentifableAndUsedScript : Script, IIdentifableAndUsedScript
{
    private DestructionR15IdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifableAndUsedScript()
    {
        Game.DestroyArea(Game.MapY.IntValue, Game.MapX.IntValue, 15);
        return (true, true);
    }
}


[Serializable]
internal class DetectInvisibleIdentifableAndUsedScript : Script, IIdentifableAndUsedScript
{
    private DetectInvisibleIdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifableAndUsedScript()
    {
        if (!Game.DetectMonstersInvis())
        {
            return (false, true);
        }
        return (true, true);
    }
}


[Serializable]
internal class DispelUndead60IdentifableAndUsedScript : Script, IIdentifableAndUsedScript
{
    private DispelUndead60IdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifableAndUsedScript()
    {
        if (!Game.DispelUndead(60))
        {
            return (false, true);
        }
        return (true, true);
    }
}


[Serializable]
internal class DoorStairLocationIdentifableAndUsedScript : Script, IIdentifableAndUsedScript
{
    private DoorStairLocationIdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifableAndUsedScript()
    {
        bool identified = false;
        if (Game.DetectDoors())
        {
            identified = true;
        }
        if (Game.DetectStairs())
        {
            identified = true;
        }
        return (identified, true);
    }
}

[Serializable]
internal class EnchantArmor1IdentifableAndUsedScript : Script, IIdentifableAndUsedScript
{
    private EnchantArmor1IdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifableAndUsedScript()
    {
        if (!Game.EnchantItem(0, 0, 1))
        {
            return (true, false);
        }
        return (true, true);
    }
}


[Serializable]
internal class EnchantWeaponToDamage1IdentifableAndUsedScript : Script, IIdentifableAndUsedScript
{
    private EnchantWeaponToDamage1IdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifableAndUsedScript()
    {
        if (!Game.EnchantItem(0, 1, 0))
        {
            return (true, false);
        }
        return (true, true);
    }
}


[Serializable]
internal class EnchantWeaponToHit1IdentifableAndUsedScript : Script, IIdentifableAndUsedScript
{
    private EnchantWeaponToHit1IdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifableAndUsedScript()
    {
        if (!Game.EnchantItem(1, 0, 0))
        {
            return (true, false);
        }
        return (true, true);
    }
}



[Serializable]
internal class FireIdentifableAndUsedScript : Script, IIdentifableAndUsedScript
{
    private FireIdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifableAndUsedScript()
    {
        Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(FireProjectile)), 0, 150, 4);
        if (!(Game.FireResistanceTimer.Value != 0 || Game.HasFireResistance || Game.HasFireImmunity))
        {
            Game.TakeHit(50 + Game.DieRoll(50), "a Scroll of Fire");
        }
        return (true, true);
    }
}


[Serializable]
internal class Blessing1D24P12IdentifableAndUsedScript : Script, IIdentifableAndUsedScript
{
    private Blessing1D24P12IdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifableAndUsedScript()
    {
        if (!Game.BlessingTimer.AddTimer(Game.DieRoll(24) + 12))
        {
            return (false, true);
        }
        return (true, true);
    }
}


[Serializable]
internal class Blessing1D48P24IdentifableAndUsedScript : Script, IIdentifableAndUsedScript
{
    private Blessing1D48P24IdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifableAndUsedScript()
    {
        if (!Game.BlessingTimer.AddTimer(Game.DieRoll(48) + 24))
        {
            return (false, true);
        }
        return (true, true);
    }
}


[Serializable]
internal class Ice175R4IdentifableAndUsedScript : Script, IIdentifableAndUsedScript
{
    private Ice175R4IdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifableAndUsedScript()
    {
        Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(IceProjectile)), 0, 175, 4);
        if (!(Game.ColdResistanceTimer.Value != 0 || Game.HasColdResistance || Game.HasColdImmunity))
        {
            Game.TakeHit(100 + Game.DieRoll(100), "a Scroll of Ice");
        }
        return (true, true);
    }
}


[Serializable]
internal class IdentifyIdentifableAndUsedScript : Script, IIdentifableAndUsedScript
{
    private IdentifyIdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifableAndUsedScript()
    {
        if (Game.RunCancellableScript(nameof(IdentifyItemCancellableScript)))
        {
            return (true, false);
        }
        return (true, true);
    }
}


[Serializable]
internal class InvocationIdentifableAndUsedScript : Script, IIdentifableAndUsedScript
{
    private InvocationIdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifableAndUsedScript()
    {
        Patron patron = Game.SingletonRepository.ToWeightedRandom<Patron>().ChooseOrDefault();
        if (patron == null)
        {
            throw new Exception("There are no Patrons configured to invoke.");
        }
        Game.MsgPrint($"You invoke the secret name of {patron.LongName}.");
        patron.GetReward();
        return (true, true);
    }
}


[Serializable]
internal class Light2D8R2IdentifableAndUsedScript : Script, IIdentifableAndUsedScript
{
    private Light2D8R2IdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifableAndUsedScript()
    {
        if (!Game.LightArea(Game.DiceRoll(2, 8), 2))
        {
            return (false, true);
        }
        return (true, true);
    }
}


[Serializable]
internal class MagicMappingIdentifableAndUsedScript : Script, IIdentifableAndUsedScript
{
    private MagicMappingIdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifableAndUsedScript()
    {
        Game.RunScript(nameof(MapAreaScript));
        return (true, true);
    }
}


[Serializable]
internal class MassCarnageIdentifableAndUsedScript : Script, IIdentifableAndUsedScript
{
    private MassCarnageIdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifableAndUsedScript()
    {
        Game.RunScriptBool(nameof(MassCarnageScript), true);
        return (true, true);
    }
}



[Serializable]
internal class MonsterConfusionIdentifableAndUsedScript : Script, IIdentifableAndUsedScript
{
    private MonsterConfusionIdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifableAndUsedScript()
    {
        if (Game.HasConfusingTouch)
        {
            return (false, true);
        }
        Game.MsgPrint("Your hands begin to glow.");
        Game.HasConfusingTouch = true;
        return (true, true);
    }
}


[Serializable]
internal class DetectNormalObjectsIdentifableAndUsedScript : Script, IIdentifableAndUsedScript
{
    private DetectNormalObjectsIdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifableAndUsedScript()
    {
        if (!Game.RunSuccessfulScript(nameof(DetectNormalObjectsScript)))
        {
            return (false, true);
        }
        return (true, true);
    }
}


[Serializable]
internal class PhaseDoorIdentifableAndUsedScript : Script, IIdentifableAndUsedScript
{
    private PhaseDoorIdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifableAndUsedScript()
    {
        Game.RunScript(nameof(PhaseDoorScript));
        return (true, true);
    }
}


[Serializable]
internal class ProtectionFromEvilIdentifableAndUsedScript : Script, IIdentifableAndUsedScript
{
    private ProtectionFromEvilIdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifableAndUsedScript()
    {
        int i = 3 * Game.ExperienceLevel.IntValue;
        if (!Game.ProtectionFromEvilTimer.AddTimer(Game.DieRoll(25) + i))
        {
            return (false, true);
        }
        return (true, true);
    }
}


[Serializable]
internal class Recharge60IdentifableAndUsedScript : Script, IIdentifableAndUsedScript
{
    private Recharge60IdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifableAndUsedScript()
    {
        if (!Game.RunCancellableScriptInt(nameof(RechargeItemCancellableScriptInt), 60))
        {
            return (true, false);
        }
        return (true, true);
    }
}


[Serializable]
internal class RemoveCurseIdentifableAndUsedScript : Script, IIdentifableAndUsedScript
{
    private RemoveCurseIdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifableAndUsedScript()
    {
        if (!Game.RunSuccessfulScript(nameof(RemoveCurseScript)))
        {
            return (false, true);
        }
        Game.MsgPrint("You feel as if someone is watching over you.");
        return (true, true);
    }
}


[Serializable]
internal class RumorIdentifableAndUsedScript : Script, IIdentifableAndUsedScript
{
    private RumorIdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifableAndUsedScript()
    {
        Game.MsgPrint("There is message on the scroll. It says:");
        Game.MsgPrint(null);
        Game.RunScript(nameof(GetRumorScript));
        return (true, true);
    }
}


[Serializable]
internal class RuneOfProtectionIdentifableAndUsedScript : Script, IIdentifableAndUsedScript
{
    private RuneOfProtectionIdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifableAndUsedScript()
    {
        Game.RunScript(nameof(ElderSignScript));
        return (true, true);
    }
}


[Serializable]
internal class SatisfyHungerIdentifableAndUsedScript : Script, IIdentifableAndUsedScript
{
    private SatisfyHungerIdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifableAndUsedScript()
    {
        if (!Game.SetFood(Constants.PyFoodMax - 1))
        {
            return (false, true);
        }
        return (true, true);
    }
}

[Serializable]
internal class SpecialAcquirementIdentifableAndUsedScript : Script, IIdentifableAndUsedScript
{
    private SpecialAcquirementIdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifableAndUsedScript()
    {
        Game.Acquirement(Game.MapY.IntValue, Game.MapX.IntValue, Game.DieRoll(2) + 1, true);
        return (true, true);
    }
}


[Serializable]
internal class EnchantArmor1D3P2IdentifableAndUsedScript : Script, IIdentifableAndUsedScript
{
    private EnchantArmor1D3P2IdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifableAndUsedScript()
    {
        if (!Game.EnchantItem(0, 0, Game.DieRoll(3) + 2))
        {
            return (true, false);
        }
        return (true, true);
    }
}


[Serializable]
internal class EnchantWeaponToDamage1D3AndToHit1D3IdentifableAndUsedScript : Script, IIdentifableAndUsedScript
{
    private EnchantWeaponToDamage1D3AndToHit1D3IdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifableAndUsedScript()
    {
        if (!Game.EnchantItem(Game.DieRoll(3), Game.DieRoll(3), 0))
        {
            return (true, false);
        }
        return (true, true);
    }
}


[Serializable]
internal class IdentifyItemFullyIdentifableAndUsedScript : Script, IIdentifableAndUsedScript
{
    private IdentifyItemFullyIdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifableAndUsedScript()
    {
        if (Game.RunCancellableScript(nameof(IdentifyItemFullyCancellableScript)))
        {
            return (true, false);
        }
        return (true, true);
    }
}


[Serializable]
internal class SpecialRemoveAllCurseIdentifableAndUsedScript : Script, IIdentifableAndUsedScript
{
    private SpecialRemoveAllCurseIdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifableAndUsedScript()
    {
        Game.RunScript(nameof(RemoveAllCurseScript));
        return (true, true);
    }
}



[Serializable]
internal class SummonMonsterIdentifableAndUsedScript : Script, IIdentifableAndUsedScript
{
    private SummonMonsterIdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifableAndUsedScript()
    {
        bool identified = false;
        for (int i = 0; i < Game.DieRoll(3); i++)
        {
            if (Game.SummonSpecific(Game.MapY.IntValue, Game.MapX.IntValue, Game.Difficulty, null))
            {
                identified = true;
            }
        }
        return (identified, true);
    }
}


[Serializable]
internal class SummonUndeadIdentifableAndUsedScript : Script, IIdentifableAndUsedScript
{
    private SummonUndeadIdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifableAndUsedScript()
    {
        bool identified = false;
        for (int i = 0; i < Game.DieRoll(3); i++)
        {
            if (Game.SummonSpecific(Game.MapY.IntValue, Game.MapX.IntValue, Game.Difficulty, Game.SingletonRepository.Get<MonsterFilter>(nameof(UndeadMonsterFilter))))
            {
                identified = true;
            }
        }
        return (identified, true);
    }
}


[Serializable]
internal class TeleportationIdentifableAndUsedScript : Script, IIdentifableAndUsedScript
{
    private TeleportationIdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifableAndUsedScript()
    {
        Game.RunScriptInt(nameof(TeleportSelfScript), 100);
        return (true, true);
    }
}



[Serializable]
internal class TeleportLevelIdentifableAndUsedScript : Script, IIdentifableAndUsedScript
{
    private TeleportLevelIdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifableAndUsedScript()
    {
        Game.RunScript(nameof(TeleportLevelScript));
        return (true, true);
    }
}



[Serializable]
internal class CreateTrapIdentifableAndUsedScript : Script, IIdentifableAndUsedScript
{
    private CreateTrapIdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifableAndUsedScript()
    {
        if (!Game.TrapCreation())
        {
            return (false, true);
        }
        return (true, true);
    }
}


[Serializable]
internal class DetectTrapsIdentifableAndUsedScript : Script, IIdentifableAndUsedScript
{
    private DetectTrapsIdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifableAndUsedScript()
    {
        if (!Game.DetectTraps())
        {
            return (false, true);
        }
        return (true, true);
    }
}


[Serializable]
internal class DestroyTrapsAndDoorsIdentifableAndUsedScript : Script, IIdentifableAndUsedScript
{
    private DestroyTrapsAndDoorsIdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifableAndUsedScript()
    {
        if (!Game.RunSuccessfulScript(nameof(DestroyAdjacentDoorsScript)))
        {
            // If nothing was destroyed, then we do not know what happened.
            return (false, true);
        }
        return (true, true);
    }
}


[Serializable]
internal class DetectTreasureIdentifableAndUsedScript : Script, IIdentifableAndUsedScript
{
    private DetectTreasureIdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifableAndUsedScript()
    {
        bool identified = false;
        if (Game.DetectTreasure())
        {
            identified = true;
        }
        if (Game.DetectObjectsGold())
        {
            identified = true;
        }
        return (identified, true);
    }
}


[Serializable]
internal class WordOfRecallIdentifableAndUsedScript : Script, IIdentifableAndUsedScript
{
    private WordOfRecallIdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifableAndUsedScript()
    {
        Game.RunScript(nameof(ToggleRecallScript));
        return (true, true);
    }
}

