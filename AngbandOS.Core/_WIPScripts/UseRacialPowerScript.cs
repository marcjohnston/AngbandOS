namespace AngbandOS.Core.Scripts;

/// <summary>
/// Retrieves a <see cref="RacePower"/> associated to the current race and character class of the player, performs a racial power test and 
/// </summary>
[Serializable]
internal class UseRacialPowerScript : Script, IScript
{
    private UseRacialPowerScript(Game game) : base(game) { }
    public void ExecuteScript()
    {
        // Check for an overriding race/character class racial power first.
        string raceAndCharacterClassCompositeKey = RacePower.GetCompositeKey(Game.Race, Game.CharacterClass);
        RacePower? raceAndCharacterClassRacialPower = Game.SingletonRepository.GetNullable<RacePower>(raceAndCharacterClassCompositeKey);
        if (raceAndCharacterClassRacialPower is not null)
        {
            raceAndCharacterClassRacialPower.Script.ExecuteScript();
        }
        else
        {
            // Check for a race.
            string raceOnlyCompositeKey = RacePower.GetCompositeKey(Game.Race, null);
            RacePower? raceOnlyRacialPower = Game.SingletonRepository.GetNullable<RacePower>(raceOnlyCompositeKey);
            if (raceOnlyRacialPower is not null)
            {
                raceOnlyRacialPower.Script.ExecuteScript();
            }
        }
    }
}