namespace AngbandOS.Core.Scripts;

/// <summary>
/// Retrieves a <see cref="RacialPower"/> associated to the current race and character class of the player, performs a racial power test and 
/// </summary>
[Serializable]
internal class UseRacialPowerScript : Script, IScript
{
    private UseRacialPowerScript(Game game) : base(game) { }
    public void ExecuteScript()
    {
        // Check for an overriding race/character class racial power first.
        string raceAndCharacterClassCompositeKey = RacialPower.GetCompositeKey(Game.Race, Game.BaseCharacterClass);
        RacialPower? raceAndCharacterClassRacialPower = Game.SingletonRepository.GetNullable<RacialPower>(raceAndCharacterClassCompositeKey);
        if (raceAndCharacterClassRacialPower is not null)
        {
            raceAndCharacterClassRacialPower.Script.ExecuteScript();
        }
        else
        {
            // Check for a race.
            string raceOnlyCompositeKey = RacialPower.GetCompositeKey(Game.Race, null);
            RacialPower? raceOnlyRacialPower = Game.SingletonRepository.GetNullable<RacialPower>(raceOnlyCompositeKey);
            if (raceOnlyRacialPower is not null)
            {
                raceOnlyRacialPower.Script.ExecuteScript();
            }
        }
    }
}