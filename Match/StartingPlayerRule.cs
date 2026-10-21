namespace TicTacToe
{
    //          FALL #7:
    // VAD:     Delegater och beroendeinjektion.
    // HUR:     StartingPlayerRule är en delegattyp. Game skapar tre
    //          instanser (spelaren börjar, datorn börjar, växla varje
    //          runda) och injicerar den valda via MatchSettings. Match
    //          anropar den i början av varje runda.
    // VARFÖR:  Match behöver inte veta vilken regel som valts, och
    //          en ny regel kan läggas till utan att Match ändras.
    public delegate IPlayer StartingPlayerRule(
        int round,
        IPlayer human,
        IPlayer computer);
}