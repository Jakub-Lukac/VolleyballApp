using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static VolleyballApp.Models.ExercisesModels;

namespace VolleyballApp_DataManagement
{
    public class Program
    {
        static void Main(string[] args)
        {
            ExeriseData db = new ExeriseData();

            using (db)
            {
                Exercise e1 = new Exercise
                {
                    ExerciseId = 1,
                    Title = "Passing Triangle Drill",
                    Difficulty = "Beginner",
                    Description = "Three players form a triangle and pass the ball to each other, focusing on accurate forearm passing. The goal is to maintain a controlled rally for at least 10 passes without dropping the ball.",
                    Time = "10-15 minutes"
                };
                Exercise e2 = new Exercise
                {
                    ExerciseId = 2,
                    Title = "Wall Passing Drill",
                    Difficulty = "Beginner",
                    Description = "Stand 6–8 feet away from a wall and pass the ball using forearms or fingertips (sets). Try to complete 50 consecutive passes without dropping the ball to improve ball control.",
                    Time = "10 minutes"
                };
                Exercise e3 = new Exercise
                {
                    ExerciseId = 3,
                    Title = "Underhand Serving Accuracy",
                    Difficulty = "Beginner",
                    Description = "Practice underhand serves aiming at specific court targets. The focus is on consistent ball contact, follow-through, and accuracy to build a reliable serve.",
                    Time = "15 minutes"
                };
                Exercise e4 = new Exercise
                {
                    ExerciseId = 4,
                    Title = "3-Touch Transition Drill",
                    Difficulty = "Intermediate",
                    Description = "A group of three players must complete a pass, set, and attack before returning the ball over the net, emphasizing teamwork and offensive coordination.",
                    Time = "15-20 minutes"
                };
                Exercise e5 = new Exercise
                {
                    ExerciseId = 5,
                    Title = "Digging Reaction Drill",
                    Difficulty = "Intermediate",
                    Description = "A coach or teammate spikes or throws balls unpredictably, requiring the player to dig the ball back into play, improving reaction time and defensive positioning.",
                    Time = "15 minutes"
                };
                Exercise e6 = new Exercise
                {
                    ExerciseId = 6,
                    Title = "Jump Serving Practice",
                    Difficulty = "Intermediate",
                    Description = "Players work on jump serves, focusing on toss consistency, timing, and ball contact. Targets are placed on the court to improve accuracy and placement.",
                    Time = "20 minutes"
                };
                Exercise e7 = new Exercise
                {
                    ExerciseId = 7,
                    Title = "Blocking Reaction Drill",
                    Difficulty = "Expert",
                    Description = "Two blockers react to a coach's or setter’s signals, predicting and blocking a spiker’s attack, enhancing reading the setter and closing the block.",
                    Time = "15 minutes"
                };
                Exercise e8 = new Exercise
                {
                    ExerciseId = 8,
                    Title = "Rapid-Fire Attack Drill",
                    Difficulty = "Expert",
                    Description = "A coach or setter feeds balls rapidly to a hitter, requiring consecutive spikes with minimal recovery time, building explosive hitting power and endurance.",
                    Time = "20 minutes"
                };
                Exercise e9 = new Exercise
                {
                    ExerciseId = 9,
                    Title = "Scramble Defense Drill",
                    Difficulty = "Expert",
                    Description = "A team must defend against randomly placed attacks with quick dives, rolls, and hustle plays, improving defensive transitions and emergency responses.",
                    Time = "20-25 minutes"
                };
                Exercise e10 = new Exercise
                {
                    ExerciseId = 10,
                    Title = "6-on-6 Full-Speed Rally Drill",
                    Difficulty = "Expert",
                    Description = "A full-team live scrimmage where teams cannot tip or lightly touch the ball—only full-power spikes, fast digs, and quick transitions, enhancing game-speed decision-making.",
                    Time = "25-30 minutes"
                };

                db.Exercises.Add(e1);
                db.Exercises.Add(e2);
                db.Exercises.Add(e3);
                db.Exercises.Add(e4);
                db.Exercises.Add(e5);
                db.Exercises.Add(e6);
                db.Exercises.Add(e7);
                db.Exercises.Add(e8);
                db.Exercises.Add(e9);
                db.Exercises.Add(e10);

                db.SaveChanges();
                Console.WriteLine("Exercises table updated");
            }
        }
    }
}
