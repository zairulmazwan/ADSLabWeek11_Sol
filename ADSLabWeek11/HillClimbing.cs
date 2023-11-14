public class HillClimbing
{
    public List<int> solution;

    public double fitness;

    public List<Double> data = new List<double>();

    public HillClimbing(List<Double> d)
    {
        Random r = new Random();
        data = d;
        solution = new List<int>();
        for (int i=0; i<d.Count; i++)
        {
            int gene = r.Next(0,2);
            solution.Add(gene);
        }
        calCurrentFit();
    }

    public void printSolution()
    {
        foreach(int x in solution)
        {
            Console.WriteLine(x);
        }
    }

    public List<int> getSolution()
    {
        return solution;
    }

    public void calCurrentFit()
    {
        fitness = 0;
        double left=0, right=0;
        for(int i=0; i<solution.Count; i++)
        {
            if(solution[i]==0){
                left+=data[i];
                // Console.WriteLine("Left "+currenSol[i]);
            }else{
                right+=data[i];
                // Console.WriteLine("Right "+currenSol[i]);
            }
        }
        fitness = Math.Round(Math.Abs(left-right),2);
    }

    public double getFitness()
    {
        calCurrentFit();
        return fitness;
    }

    public List<int> copySolution()
    {
        List<int> res = new List<int>();
        res = solution.ToList();
        return res;
    }

    public void smallChange()
    {
        Random r = new Random();
        int ind = r.Next(solution.Count);
        // Console.WriteLine(ind);
        // Console.WriteLine("Val "+solution[ind]);

        if(solution[ind]==0)
        {
            solution[ind] = 1;
        }
        else
        {
            solution[ind] = 0;
        }
    }
}

public class Experiment
{
    public static void runExp ()
    {
        Console.WriteLine("Running Experiments...");
        int iter=200;

        double [,] results = new double[iter,3];
        List<List<int>> new_solutions = new List<List<int>>();

        //Read the dataset
        List<Double> data = FileData.readData("Sample_6/data.csv");

        //Initialise a random solution for HC
        HillClimbing sol = new HillClimbing(data);

        Console.WriteLine("Initial fitness: "+sol.fitness);
        Console.WriteLine("Initial solution ");
        // sol.printSolution();
        FileData.writeFile(sol.solution,"init_sol.csv");

        for(int i=0; i<iter; i++)
        {
            // Console.WriteLine("ITER "+i);
            HillClimbing newSol = new HillClimbing(data);
            newSol.solution = sol.copySolution();
            newSol.smallChange();
            new_solutions.Add(newSol.solution);

            // Console.WriteLine("Fitness: "+sol.fitness);
            // Console.WriteLine("New Fitness: "+newSol.fitness);

            if(newSol.getFitness()<sol.getFitness()){
                sol.solution = newSol.copySolution();
                //sol.fitness = newSol.fitness;
            }
            results[i,0] = i;
            results[i,1] = sol.getFitness();
            results[i,2] = newSol.getFitness();
        }
        //  Console.WriteLine("Final fitness: "+sol.fitness);
        //  Console.WriteLine("Final solution ");
        //  sol.printSolution();
         FileData.writeFile(sol.solution,"final_sol.csv");
         FileData.writeFitnessResults(results, "results.csv");
         FileData.writeSolutions(new_solutions,"new_solutions.csv");
    }
}