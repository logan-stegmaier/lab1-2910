namespace Lab_1___2910
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string projectRootFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString();
            string filePath = projectRootFolder + "/videogames.csv";

            string filePathInterpolated = $"{projectRootFolder}{Path.DirectorySeparatorChar}videogames.csv";

            // Step 1 
            // ** step 2 is on VideoGame.cs ** 

            List<VideoGame> games = new List<VideoGame>();

            using (var sr = new StreamReader(filePathInterpolated))
            {

                sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();

                    string[] lineData = line.Split(','); //csvs are separated by ,

                    VideoGame game = new VideoGame()
                    {
                        //Name,Platform,Year,Genre,Publisher,NA_Sales,EU_Sales,JP_Sales,Other_Sales,Global_Sales 

                        Name = lineData[0],
                        Platform = lineData[1],
                        Year = Int32.Parse(lineData[2]),
                        Genre = lineData[3],
                        Publisher = lineData[4],
                        NA_Sales = Double.Parse(lineData[5]),
                        EU_Sales = Double.Parse(lineData[6]),
                        JP_Sales = Double.Parse(lineData[7]),
                        Other_Sales = Double.Parse(lineData[8]),
                        Global_Sales = Double.Parse(lineData[9]),

                    };

                    games.Add(game);
                }

            }

            games.Sort();

            // LINQ PROCESS 
            // Step 3

            var listFromPublisher = games.Where(p => p.Publisher == "Nintendo");
            foreach (var p in listFromPublisher)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine("\n\n");

            // Step 4 
            // I could've made a method for below but I figured since I am separating this out into two parts, I wouldn't make one that would overcomplicate this.

            float numNintendoGames = listFromPublisher.Count(); // Nintendo Games based on what was declared earlier
            float numAllGames = games.Count(); // All games based on the list that I had created (which is based on the csv file) 

            double pct = numNintendoGames / numAllGames;

            Console.WriteLine($"Out of {numAllGames} games, {numNintendoGames} are developed by Nintendo, which is {pct.ToString("#0.##%")}\n"); // this tostring method is p cool

            ConsoleClear(); 

            // LINQ PROCESS again 
            // Step 5

            var listFromGenre = games.Where(p => p.Genre == "Role-Playing"); // now sorting based on Genre - Roleplaying specific
            foreach (var p in listFromGenre)
            {
                Console.WriteLine(p);
            }

            // Step 6
            float numOfRolePlayingGenre = listFromGenre.Count();
            // we don't need to make another datatype for numAllGames since we used it previously
            double pctRP = numOfRolePlayingGenre / numAllGames;

            Console.WriteLine($"Out of {numAllGames} games, {numOfRolePlayingGenre} are Role-Playing games, which is {pctRP.ToString("#0.##%")}");

            ConsoleClear(); 

            Console.WriteLine("Which publisher would you like to retrieve data from?");
            string PublisherSelection = Console.ReadLine();

            PublisherData(games, PublisherSelection); // gotta reference that OG list

            ConsoleClear();

            Console.WriteLine("Which genre would you like to retrieve data from?");
            string GenreSelection = Console.ReadLine();

            GenreData(games, GenreSelection);


            static void PublisherData(List<VideoGame> games, string PublisherSelection)
            {
                var listFromPublisher = games.Where(p => p.Publisher == PublisherSelection);
                foreach (var p in listFromPublisher)
                {
                    Console.WriteLine(p);
                }
                Console.WriteLine("\n\n");

                float numPublisherGames = listFromPublisher.Count(); 
                float numAllGames = games.Count(); 

                double pct = numPublisherGames / numAllGames;

                Console.WriteLine($"Out of {numAllGames} games, {numPublisherGames} are developed by {PublisherSelection}, which is {pct.ToString("#0.##%")}\n");
            }

            static void GenreData(List<VideoGame> games, string GenreSelection)
            {
                var listFromGenre = games.Where(p => p.Genre == GenreSelection); // now sorting based on Genre - Roleplaying specific
                foreach (var p in listFromGenre)
                {
                    Console.WriteLine(p);
                }

                
                float numOfRolePlayingGenre = listFromGenre.Count();
                float numAllGames = games.Count(); 

                double pctRP = numOfRolePlayingGenre / numAllGames;

                Console.WriteLine($"Out of {numAllGames} games, {numOfRolePlayingGenre} are {GenreSelection} games, which is {pctRP.ToString("#0.##%")}");

            }

            static void ConsoleClear()
            {
                Console.WriteLine("Press Any KEY to continue (This will clear the previous feed and begin the next lines of code)");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}

