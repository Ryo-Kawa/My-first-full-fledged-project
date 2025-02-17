public class Turn
{
    private int m_turn_count = 0;

    public int TurnCount { get { return m_turn_count; } }

    public void ProceedTurn()
    {
        m_turn_count++;
    }
}
