switch(args.FirstOrDefault()?.ToLower()) {
    case "shp":
        Console.WriteLine("Shapefile operations.");
        break;
    case null:
        Console.WriteLine("No command entered");
        break;
    default:
        Console.WriteLine("No recognized command entered.");
        break;
}