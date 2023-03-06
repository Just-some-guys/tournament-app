using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentApp.Domain.Entities.BracketEntities
{
    internal class TreshCode
    {


        //DoubleEliminationModel result = new DoubleEliminationModel();

        //    List<Match> UpperBranch = new List<Match>();
        //    List<Match> LowerBranch = new List<Match>();

        //    int teamscount = 32;

        //    List<Team> teams = _context.Teams.ToList();

        //    // Создаются матчи верхней сетки
        //    for (int i = 1; i <= teamscount; i++)
        //    {
        //        UpperBranch.Add(new Match { Id = i });
        //    }

        //    int maxRoundLowerBranch = 2;            // Если корректно определить максимальное количество раундов в ниэней сетке, то всё равнотает нормально
        //    for (int i = 1; i <= teamscount; i *= 2)
        //    {
        //        maxRoundLowerBranch++;
        //    }


        //    // Создаются матчи нижней сетки
        //    for (int matchId = teamscount + 1; matchId <= teamscount * 2 - 2; matchId++)
        //    {
        //        LowerBranch.Add(new Match { Id = matchId });
        //    }

        //    int numberOfMatches = 1;
        //    int numberOfIteration = 0;
        //    int counterFor_I = 0;
        //    for (int i = LowerBranch.Count - 1; i > 0; i -= counterFor_I ) //i -= (numberOfMatches + numberOfMatches)
        //    {
        //        counterFor_I = 0;
        //        int p = 0;
        //        if (p == 0)
        //        {
        //            for(int j = 0; j <= numberOfMatches; j++)
        //            {                      

        //                LowerBranch[i-j].NumberOfRound = maxRoundLowerBranch;                        

        //                if (j == numberOfMatches - 1)
        //                {
        //                    counterFor_I++;
        //                    i -= counterFor_I;

        //                    //i-=numberOfMatches;
        //                }                        
                        
        //            }                    
        //            maxRoundLowerBranch--;
        //            p++;
                    
        //        }
        //        if (p == 1)
        //        {
                    
        //            for (int j = 0; j < numberOfMatches; j++)
        //            {
        //                LowerBranch[i - j].NumberOfRound = maxRoundLowerBranch;
        //               // counterFor_I++;
        //            }                    
        //            maxRoundLowerBranch--;
        //            p++;
        //        }
        //        if (p == 2)
        //        {
        //            numberOfMatches *= 2;
        //            numberOfIteration++;
        //            continue;
        //        }                
                
        //    }



        //    // Этот цикл добавляет команды в матчи
        //    for (int i = 0; i < teamscount / 2; i++)
        //    {
        //        for (int p = 0; p < teamscount; p += 2)
        //        {
        //            //UpperBranch[i].Participants = new List<Participant>();
        //            //UpperBranch[i].Participants.Add(new Participant { Team = teams[p] });
        //            //UpperBranch[i].Participants.Add(new Participant { Team = teams[p + 1] });
        //        }
        //    }

        //    // Этот цикл проставляет NextMatchId для верхней сетки
        //    int upStep = teamscount / 2;
        //    for (int i = 0; i < UpperBranch.Count; i += 2)
        //    {
        //        UpperBranch[i].NextMatchId = i + 1 + upStep;
        //        UpperBranch[i + 1].NextMatchId = i + 1 + upStep;
        //        upStep -= 1;
        //    }

        //    // Этот цикл проставляет NextMatchId для нижней сетки
        //    //int lowStep = teamscount / 4;
        //    //for (int i = 0; i < LowerBranch.Count; i += teamscount / 4)
        //    //{
        //    //    int c = 0;
        //    //    for (int p = 0; p < lowStep; p++)
        //    //    {
        //    //        LowerBranch[i + p].NextMatchId = LowerBranch[i + p].Id + lowStep;
        //    //        c++;
        //    //    }

        //    //    for (int o = c; o <= c + lowStep; o += 2)
        //    //    {
        //    //        LowerBranch[i + o].NextMatchId = LowerBranch[i + o].Id + lowStep;
        //    //        LowerBranch[i + o + 1].NextMatchId = LowerBranch[i + o].Id + lowStep;
        //    //        lowStep -= 1;
        //    //    }
        //    //    i += teamscount / 4;
        //    //}

        //    //LowerBranch[LowerBranch.Count - 2].NextMatchId = LowerBranch[LowerBranch.Count - 1].Id;
        //    //LowerBranch[LowerBranch.Count - 1].NextMatchId = UpperBranch[UpperBranch.Count - 1].Id;


        //    LowerBranch[LowerBranch.Count - 1].NextMatchId = UpperBranch[UpperBranch.Count - 1].Id;
        //    LowerBranch[LowerBranch.Count - 2].NextMatchId = LowerBranch[LowerBranch.Count - 1].Id;

        //    int lowStep = 2;
        //    for (int i = LowerBranch.Count - 3; i >= 0; i -= lowStep)
        //    {
        //        for (int j = 0; j < lowStep; j++)
        //        {
        //            if (LowerBranch[i - j].Id % 2 == 0)
        //            {
        //                LowerBranch[i - j].NextMatchId = LowerBranch[i + 2].Id;
        //            }
        //            if (LowerBranch[i - j].Id % 2 != 0)
        //            {
        //                LowerBranch[i - j].NextMatchId = LowerBranch[i + 1].Id;
        //            }


        //            // LowerBranch[i-j].NextMatchId=LowerBranch[i+1].Id;
        //        }
        //    }



            
















































    }
}
