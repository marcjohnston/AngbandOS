﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class EatRestoringScript : Script, IEatOrQuaffScript
{
    private EatRestoringScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public IdentifiedResultEnum ExecuteEatOrQuaffScript()
    {
        Game.PlaySound(SoundEffectEnum.Eat);
        bool isIdentified = false;
        if (Game.TryRestoringAbilityScore(Game.StrengthAbility))
        {
            isIdentified = true;
        }
        if (Game.TryRestoringAbilityScore(Game.IntelligenceAbility))
        {
            isIdentified = true;
        }
        if (Game.TryRestoringAbilityScore(Game.WisdomAbility))
        {
            isIdentified = true;
        }
        if (Game.TryRestoringAbilityScore(Game.DexterityAbility))
        {
            isIdentified = true;
        }
        if (Game.TryRestoringAbilityScore(Game.ConstitutionAbility))
        {
            isIdentified = true;
        }
        if (Game.TryRestoringAbilityScore(Game.CharismaAbility))
        {
            isIdentified = true;
        }
        return isIdentified ? IdentifiedResultEnum.True : IdentifiedResultEnum.False;
    }
}
