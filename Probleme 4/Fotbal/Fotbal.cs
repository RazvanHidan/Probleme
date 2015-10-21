using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fotbal
{
    [TestClass]
    public class Fotbal
    {
        [TestMethod]
        public void TestAddANDTotal()
        {
            FootballRound[] Etapa = new  FootballRound [1];
            Etapa[0].Home = "Steaua";
            Etapa[0].HomeGoal = 2;
            Etapa[0].AwayGoal = 3;
            Etapa[0].Away = "Dinamo";
            AddMatch(ref Etapa,"U Cluj",4,0,"CFR");
            Assert.AreEqual(TotalGoals(Etapa), 9);
        }
        [TestMethod]
        public void TestDiffMin()
        {
            FootballRound[] Etapa = new FootballRound[1];
            Etapa[0].Home = "Steaua";
            Etapa[0].HomeGoal = 0;
            Etapa[0].AwayGoal = 3;
            Etapa[0].Away = "Dinamo";
            AddMatch(ref Etapa, "U Cluj", 4, 0, "CFR");
            AddMatch(ref Etapa, "Astra", 3, 5, "Unirea");
            Assert.AreEqual("Unirea", BestTeam(Etapa));
        }
        [TestMethod]
        public void TestAverage()
        {
            FootballRound[] Etapa = new FootballRound[1];
            Etapa[0].Home = "Steaua";
            Etapa[0].HomeGoal = 2;
            Etapa[0].AwayGoal = 3;
            Etapa[0].Away = "Dinamo";
            AddMatch(ref Etapa, "U Cluj", 4, 0, "CFR");
            Assert.AreEqual(Average(Etapa), 4.5, 0.01);
        }
        [TestMethod]
        public void TestDelete()
        {
            FootballRound[] Etapa = new FootballRound[1];
            Etapa[0].Home = "Steaua";
            Etapa[0].HomeGoal = 0;
            Etapa[0].AwayGoal = 3;
            Etapa[0].Away = "Dinamo";
            AddMatch(ref Etapa, "U Cluj", 8, 0, "CFR");
            AddMatch(ref Etapa, "Astra", 3, 5, "Unirea");
            AddMatch(ref Etapa, "Jiu", 3, 5, "Dej");
            Assert.AreEqual(Etapa.Length, 4);
            DeleteMatch(ref Etapa);
            Assert.AreEqual(Etapa .Length ,3);
        }

        public struct FootballRound
        {
            public string Home;
            public int HomeGoal;
            public int AwayGoal;
            public string Away;
        }
        
        void AddMatch(ref FootballRound[] match,string Home, int HomeGoal,int AwayGoal, string Away)
        {
            Array.Resize(ref match, match.Length + 1);
            int length = match.Length - 1;
            match[length].Home = Home;
            match[length].HomeGoal = HomeGoal;
            match[length].AwayGoal = AwayGoal;
            match[length].Away = Away;
        }

        int TotalGoals(FootballRound[] matchs)
        {
            int totalGoals = 0;
            for (int i = 0; i < matchs.Length; i++)
                totalGoals += (matchs[i].AwayGoal + matchs[i].HomeGoal);
            return totalGoals;
        }
        double Difference(int number1,  int number2)
        {
            return Math.Abs(number1 - number2);
        }
        void WinerTeam(FootballRound matchs, ref string team, ref int difference)
        {
            team = (matchs.HomeGoal > matchs.AwayGoal) ? (matchs.Home) : (matchs.Away);
            difference = Math.Abs(matchs.HomeGoal - matchs.AwayGoal);
        }

        string BestTeam(FootballRound[] matchs)
        {
            int difference=0;
            string team=" ";
            WinerTeam(matchs[0], ref team, ref difference);
            for (int i = 1; i < matchs.Length; i++)
                if ((matchs[i].HomeGoal != 0) || (matchs[i].AwayGoal != 0))
                    if (Difference(matchs[i].HomeGoal, matchs[i].AwayGoal) < difference) 
                        WinerTeam(matchs[i], ref team, ref difference);
            return team;   
        }  
        double Average(FootballRound [] matchs)
        {
            double average = 0;
            for (int i=0; i < matchs.Length; i++)
                average += (matchs[i].AwayGoal + matchs[i].HomeGoal) ;
            return average / matchs.Length;
        }

        int Position(FootballRound[] match)
        {
            int position=0;
            string team=" ";
            int difference=0;
            WinerTeam(match[0], ref team, ref difference);
            for (int i = 0; i < match.Length; i++)
                position = (Difference(match[i].HomeGoal, match[i].AwayGoal) > difference) ? i : position;
            return position;
        }
        void DeleteMatch (ref FootballRound [] match)
        {
            int matchNumber = Position(match);
            if (matchNumber != (match.Length - 1))
                for (int i = matchNumber; i < match.Length - 1; i++)
                    match[i] = match[i + 1];
            Array.Resize(ref match, match.Length - 1);
        }
    }
}
