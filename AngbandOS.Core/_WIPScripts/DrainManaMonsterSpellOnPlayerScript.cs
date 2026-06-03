// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class DrainManaMonsterSpellOnPlayerScript : Script, IScriptMonster
{
    private DrainManaMonsterSpellOnPlayerScript(Game game) : base(game) { }
    public void ExecuteScriptMonster(Monster monster)
    {
        string monsterName = monster.Name;
        bool playerIsBlind = Game.BlindnessTimer.Value != 0;
        int monsterLevel = monster.Race.Level >= 1 ? monster.Race.Level : 1;
        bool seenByPlayer = !playerIsBlind && monster.IsVisible;

        if (Game.Mana.IntValue != 0)
        {
            Game.MsgPrint($"{monsterName} draws psychic energy from you!");
            int r1 = (base.Game.DieRoll(monsterLevel) / 2) + 1;
            if (r1 >= Game.Mana.IntValue)
            {
                r1 = Game.Mana.IntValue;
                Game.Mana.IntValue = 0;
                Game.FractionalMana = 0;
            }
            else
            {
                Game.Mana.IntValue -= r1;
            }
            if (monster.Health < monster.MaxHealth)
            {
                monster.Health += 6 * r1;
                if (monster.Health > monster.MaxHealth)
                {
                    monster.Health = monster.MaxHealth;
                }
                if (seenByPlayer)
                {
                    Game.MsgPrint($"{monsterName} appears healthier.");
                }
            }
        }
        Game.UpdateSmartLearn(monster, base.Game.SingletonRepository.Get<SpellResistantDetection>(nameof(ManaSpellResistantDetection)));
    }
}
