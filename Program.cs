using System;
using System.Collections.Generic;

namespace planYourHeist
{
    class Program
    {
        static void Main (string[] args)
        {
            Console.WriteLine ("Plan Your Heist!");
            Console.WriteLine ("What is the difficulty level of the bank you want to rob?");
            int bankLevel = int.Parse (Console.ReadLine ());

            List<Dictionary<string, string>> team = new List<Dictionary<string, string>> ();

            while (true)
            {
                Dictionary<string, string> teamMember = new Dictionary<string, string> ();

                Console.WriteLine ("What is your team members name?");
                string memberName = Console.ReadLine ();
                if (memberName == "")
                {
                    break;
                }
                teamMember.Add ("name", $"{memberName}");

                Console.WriteLine ("What is your team members skill level (1-50)?");
                string memberSkill = Console.ReadLine ();
                teamMember.Add ("skillLevel", $"{memberSkill}");

                Console.WriteLine ("What is your team members courage factor (0.0-2.0)?");
                string memberCourage = Console.ReadLine ();
                teamMember.Add ("courageFactor", $"{memberCourage}");

                Console.WriteLine ("Your new team member:");
                foreach (KeyValuePair<string, string> pair in teamMember)
                {
                    Console.WriteLine ($"{pair.Key}: {pair.Value}");
                };

                team.Add (teamMember);
            }

            Console.WriteLine ($"Your team has {team.Count} members.");

            Console.WriteLine ("How many trial runs would you like to perform?");
            string trialRuns = Console.ReadLine ();
            int trialRunsInt = int.Parse (trialRuns);

            int successfulAttempts = 0;
            int failedAttempts = 0;

            for (int i = 0; i < trialRunsInt; i++)
            {
                Console.WriteLine (bankLevel);
                int luckNumber = new Random ().Next (-10, 11);
                int bankLevelLuck = bankLevel + luckNumber;

                int teamSkillLevel = 0;

                foreach (Dictionary<string, string> member in team)
                {
                    int memberSkillLevel = int.Parse (member["skillLevel"]);
                    teamSkillLevel += memberSkillLevel;
                }

                Console.WriteLine ($"Your team's skill level is {teamSkillLevel}");
                Console.WriteLine ($"The bank's difficulty level is {bankLevelLuck}");

                if (teamSkillLevel >= bankLevelLuck)
                {
                    Console.WriteLine ("Success! Your team's skill level is high enough to rob this bank!");
                    successfulAttempts++;
                }
                else
                {
                    Console.WriteLine ("Looks like you'll need to add more members to your team to rob this bank.");
                    failedAttempts++;
                }
            }
            Console.WriteLine ("Team trial report:");
            Console.WriteLine ($"Successful attempts: {successfulAttempts}");
            Console.WriteLine ($"Failed attempts: {failedAttempts}");
        }
    }
}