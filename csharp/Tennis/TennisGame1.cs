using System.Collections.Generic;

namespace Tennis
{
    class TennisGame1 : ITennisGame
    {
        private int m_score1 = 0;
        private int m_score2 = 0;
        private string player1Name;
        private string player2Name;
        private readonly Dictionary<int, string> tie;
        private readonly Dictionary<int, string> notie;

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;

            tie = new Dictionary<int, string>
            {
                {0,"Love-All"},
                {1,"Fifteen-All" },
                {2,"Thirty-All" }
            };

            notie = new Dictionary<int, string>
            {
                {0,"Love"},
                {1,"Fifteen" },
                {2,"Thirty" },
                {3,"Forty" }
            };
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
            
            if (m_score1 == m_score2)
            {
                score = tie.ContainsKey(m_score1) ? tie[m_score1] : "Deuce";
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
                score = notie[m_score1] + "-" + notie[m_score2];
            }
            return score;
        }
    }
}

