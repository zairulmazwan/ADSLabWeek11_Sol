// List<int> data = FileData.genData(5);
// FileData.printList(data);

// List<Double> dataDouble = FileData.genDoubleData(100);
// FileData.printList(dataDouble);
// FileData.writeFile(dataDouble,"dataset.csv");

// List<Double> data = FileData.readData(@"/Users/zairulmazwan/Dotnet/ADSLabWeek11_Sol/ADSLabWeek11/dataset.csv");
List<Double> data = FileData.readData("./Sample_6/data.csv");



// FileData.printList(data);

// HillClimbing hc = new HillClimbing(data);
// hc.printSolution();
// Console.WriteLine();
// Console.WriteLine(hc.fitness);
// Console.WriteLine("\n------------------");
// HillClimbing hc2 = new HillClimbing(data);
// hc2 = hc.copySolution();
// hc2.printSolution();
// Console.WriteLine();
// Console.WriteLine(hc2.fitness);
// Console.WriteLine();

// Console.WriteLine("Perform Small Change");
// hc2.smallChange();
// hc2.printSolution();
// Console.WriteLine();
// Console.WriteLine(hc2.fitness);


// Console.WriteLine(hc.fitness);
Experiment.runHCExp();
Experiment.runSHCExp();
