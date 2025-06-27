// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class WildChaoticMagicScript : Script, ICastSpellScript
{
    private WildChaoticMagicScript(Game game) : base(game) { }

    /// <summary>
    /// Returns information about the script, or blank if there is no detailed information.  Returns blank, by default.
    /// </summary>
    public string LearnedDetails => "";

    /// <summary>
    /// Executes a random chaotic spell.
    /// </summary>
    /// <param name="spellLevel">A spell level from 0 to 38.  The actual spell cast will be in the range of spell ... spell + 1d8.</param>
    /// <returns></returns>
    public void ExecuteCastSpellScript(Spell spell)
    {
        int spellIndex = spell.SpellIndex;
        Game.MsgPrint("You produce a chaotic effect!");
        switch (Game.DieRoll(spellIndex) + Game.DieRoll(8)) // TODO: Convert this to WeightedRandom
        {
            case 1:
            case 2:
            case 3:
                Game.RunScript(nameof(TeleportSelf10TeleportSelfScript));
                break;

            case 4:
            case 5:
            case 6:
                Game.RunScript(nameof(TeleportSelf100TeleportSelfScript));
                break;

            case 7:
            case 8:
                Game.RunScript(nameof(TeleportSelf200TeleportSelfScript));
                break;

            case 9:
            case 10:
            case 11:
                Game.UnlightArea(10, 3);
                break;

            case 12:
            case 13:
            case 14:
                Game.LightArea(Game.DiceRoll(2, 3), 2);
                break;

            case 15:
                Game.RunScript(nameof(DestroyAdjacentDoorsScript));
                break;

            case 16:
            case 17:
                Game.WallBreaker();
                break;

            case 18:
                Game.RunScript(nameof(OldSleep1xr1ProjectileScript));
                break;

            case 19:
            case 20:
                Game.RunScript(nameof(MakeTrapr1ProjectileScript));
                break;

            case 21:
            case 22:
                Game.RunScript(nameof(CreateDoorProjectileScript));
                break;

            case 23:
            case 24:
            case 25:
                Game.AggravateMonsters();
                break;

            case 26:
                Game.Earthquake(Game.MapY.IntValue, Game.MapX.IntValue, 5);
                break;

            case 27:
            case 28:
                Game.RunScript(nameof(GainMutationScript));
                break;

            case 29:
            case 30:
                Game.RunScript(nameof(ApplyDisenchantScript));
                break;

            case 31:
                Game.LoseAllInfo();
                break;

            case 32:
                Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(ChaosProjectile)), 0, spellIndex + 5, 1 + (spellIndex / 10));
                break;

            case 33:
                Game.RunScript(nameof(WallOfStoneScript));
                break;

            case 34:
            case 35:
                int counter = 0;
                while (counter++ < 8)
                {
                    Game.SummonSpecific(Game.MapY.IntValue, Game.MapX.IntValue, Game.Difficulty * 3 / 2, Game.GetRandomBizarreMonsterSelector(), true, false);
                }
                break;

            case 36:
            case 37:
                Game.ActivateHiSummon();
                break;

            case 38:
                Game.SummonReaver();
                break;

            default:
                Game.ActivateDreadCurse();
                break;
        }
    }
}
