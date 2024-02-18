// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class WildChaoticMagicScript : Script, IScriptInt
{
    private WildChaoticMagicScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes a random chaotic spell.
    /// </summary>
    /// <param name="spellLevel">A spell level from 0 to 38.  The actual spell cast will be in the range of spell ... spell + 1d8.</param>
    /// <returns></returns>
    public void ExecuteScriptInt(int spellLevel)
    {
        SaveGame.MsgPrint("You produce a chaotic effect!");
        switch (SaveGame.DieRoll(spellLevel) + SaveGame.DieRoll(8)) // TODO: Convert this to WeightedRandom
        {
            case 1:
            case 2:
            case 3:
                SaveGame.RunScriptInt(nameof(TeleportSelfScript), 10);
                break;

            case 4:
            case 5:
            case 6:
                SaveGame.RunScriptInt(nameof(TeleportSelfScript), 100);
                break;

            case 7:
            case 8:
                SaveGame.RunScriptInt(nameof(TeleportSelfScript), 200);
                break;

            case 9:
            case 10:
            case 11:
                SaveGame.UnlightArea(10, 3);
                break;

            case 12:
            case 13:
            case 14:
                SaveGame.LightArea(SaveGame.DiceRoll(2, 3), 2);
                break;

            case 15:
                SaveGame.RunScript(nameof(DestroyAdjacentDoorsScript));
                break;

            case 16:
            case 17:
                SaveGame.WallBreaker();
                break;

            case 18:
                SaveGame.SleepMonstersTouch();
                break;

            case 19:
            case 20:
                SaveGame.TrapCreation();
                break;

            case 21:
            case 22:
                SaveGame.RunScript(nameof(CreateDoorScript));
                break;

            case 23:
            case 24:
            case 25:
                SaveGame.AggravateMonsters();
                break;

            case 26:
                SaveGame.Earthquake(SaveGame.MapY, SaveGame.MapX, 5);
                break;

            case 27:
            case 28:
                SaveGame.RunScript(nameof(GainMutationScript));
                break;

            case 29:
            case 30:
                SaveGame.RunScript(nameof(ApplyDisenchantScript));
                break;

            case 31:
                SaveGame.LoseAllInfo();
                break;

            case 32:
                SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get(nameof(ChaosProjectile)), 0, spellLevel + 5, 1 + (spellLevel / 10));
                break;

            case 33:
                SaveGame.WallStone();
                break;

            case 34:
            case 35:
                int counter = 0;
                while (counter++ < 8)
                {
                    SaveGame.SummonSpecific(SaveGame.MapY, SaveGame.MapX, SaveGame.Difficulty * 3 / 2, SaveGame.GetRandomBizarreMonsterSelector());
                }
                break;

            case 36:
            case 37:
                SaveGame.ActivateHiSummon();
                break;

            case 38:
                SaveGame.SummonReaver();
                break;

            default:
                SaveGame.ActivateDreadCurse();
                break;
        }
    }
}
