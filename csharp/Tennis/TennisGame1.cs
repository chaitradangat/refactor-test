namespace Tennis
{
    class TennisGame1 : ITennisGame
    {
        private int m_score1 = 0;
        private int m_score2 = 0;
        private string player1Name;
        private string player2Name;

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == this.player1Name)
                m_score1 += 1;
            else
                m_score2 += 1;
        }

        public string GetScore()
        {
            string score = "";
            var tempScore = 0;
            if (m_score1 == m_score2)
            {
                switch (m_score1)
                {
                    case 0:
                        score = "Love-All";
                        break;
                    case 1:
                        score = "Fifteen-All";
                        break;
                    case 2:
                        score = "Thirty-All";
                        break;
                    default:
                        score = "Deuce";
                        break;

                }
            }
            else if (m_score1 >= 4 || m_score2 >= 4)
            {
                var minusResult = m_score1 - m_score2;
                if (minusResult == 1) score = string.Format("{0} {1}", "Advantage",player1Name);
                else if (minusResult == -1) score = string.Format("{0} {1}", "Advantage", player2Name);
                else if (minusResult >= 2) score = string.Format("{0} {1}", "Win for", player1Name);
                else score = string.Format("{0} {1}", "Win for", player2Name);
            }
            else
            {
                for (var i = 1; i < 3; i++)
                {
                    if (i == 1) tempScore = m_score1;
                    else { score += "-"; tempScore = m_score2; }
                    switch (tempScore)
                    {
                        case 0:
                            score += "Love";
                            break;
                        case 1:
                            score += "Fifteen";
                            break;
                        case 2:
                            score += "Thirty";
                            break;
                        case 3:
                            score += "Forty";
                            break;
                    }
                }
            }
            return score;
        }
    }
}

