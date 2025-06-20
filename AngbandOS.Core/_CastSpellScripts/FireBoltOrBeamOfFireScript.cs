// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class FireBoltOrBeamOfFireScript : Script, IScript, ICastSpellScript
{
    private FireBoltOrBeamOfFireScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Fires a bolt or beam of fire in a chosen direction.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        int beam;
        switch (Game.BaseCharacterClass.ID)
        {
            case CharacterClassEnum.Mage:
                beam = Game.ExperienceLevel.IntValue;
                break;

            case CharacterClassEnum.HighMage:
                beam = Game.ExperienceLevel.IntValue + 10;
                break;

            default:
                beam = Game.ExperienceLevel.IntValue / 2;
                break;
        }
        if (!Game.GetDirectionWithAim(out int dir))
        {
            return;
        }
        Game.FireBoltOrBeam(beam, Game.SingletonRepository.Get<Projectile>(nameof(FireProjectile)), dir, Game.DiceRoll(8 + ((Game.ExperienceLevel.IntValue - 5) / 4), 8));
    }
    public string LearnedDetails => $"dam {6 + ((Game.ExperienceLevel.IntValue - 5) / 4)}d8";
}
