namespace TicTacToe
{
    // En delegattyp som beskriver en funktion som väljer vem som börjar
    public delegate IPlayer StartingPlayerRule(
        int round,
        IPlayer human,
        IPlayer computer);
}