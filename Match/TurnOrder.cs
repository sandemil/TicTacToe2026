namespace TicTacToe
{
    // Håller reda på vems tur det är under en runda
    public class TurnOrder
    {
        private readonly MatchSettings settings;
        private IPlayer current;

        public TurnOrder(MatchSettings settings, int round)
        {
            this.settings = settings;
            //          FALL #8:
            // VAD:     Delegater och beroendeinjektion
            // HUR:     Game har tre metoder med samma signatur som
            //          delegaten StartingPlayerRule: PlayerStarts,
            //          ComputerStarts och TakeTurns. Den som börjar
            //          väljs genom att delegaten injiceras i
            //          MatchSettings och anropas här.
            // VARFÖR:  TurnOrder behöver inte veta hur startspelaren
            //          väljs. Varje regel är en egen metod i stället
            //          för if-satser, och en ny regel läggs till med
            //          en metod och ett menyval.
            current = settings.StartingPlayer(
                round,
                settings.Human,
                settings.Computer);
        }

        public IPlayer GetCurrent()
        {
            return current;
        }

        public void Switch()
        {
            if (current == settings.Human)
            {
                current = settings.Computer;
            }
            else
            {
                current = settings.Human;
            }
        }
    }
}