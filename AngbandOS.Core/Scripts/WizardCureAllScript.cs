// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts
{
    [Serializable]
    internal class WizardCureAllScript : Script
    {
        private WizardCureAllScript(SaveGame saveGame) : base(saveGame) { }

        public override bool Execute()
        {
            SaveGame.RemoveAllCurse();
            SaveGame.Player.RestoreAbilityScore(Ability.Strength);
            SaveGame.Player.RestoreAbilityScore(Ability.Intelligence);
            SaveGame.Player.RestoreAbilityScore(Ability.Wisdom);
            SaveGame.Player.RestoreAbilityScore(Ability.Constitution);
            SaveGame.Player.RestoreAbilityScore(Ability.Dexterity);
            SaveGame.Player.RestoreAbilityScore(Ability.Charisma);
            SaveGame.Player.RestoreLevel();
            SaveGame.Player.Health = SaveGame.Player.MaxHealth;
            SaveGame.Player.FractionalHealth = 0;
            SaveGame.Player.Mana = SaveGame.Player.MaxMana;
            SaveGame.Player.FractionalMana = 0;
            SaveGame.Player.TimedBlindness.ResetTimer();
            SaveGame.Player.TimedConfusion.ResetTimer();
            SaveGame.Player.TimedPoison.ResetTimer();
            SaveGame.Player.TimedFear.ResetTimer();
            SaveGame.Player.TimedParalysis.ResetTimer();
            SaveGame.Player.TimedHallucinations.ResetTimer();
            SaveGame.Player.TimedStun.ResetTimer();
            SaveGame.Player.TimedBleeding.ResetTimer();
            SaveGame.Player.TimedSlow.ResetTimer();
            SaveGame.Player.SetFood(Constants.PyFoodMax - 1);
            SaveGame.DoCmdRedraw();
            return false;
        }
    }
}
