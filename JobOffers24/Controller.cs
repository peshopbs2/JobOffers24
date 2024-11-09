using System;
using System.Collections.Generic;
using System.Text;


public class Controller
{
    private readonly Dictionary<string, Category> categories;

    public Controller()
    {
        categories = new Dictionary<string, Category>();
    }

    public string AddCategory(List<string> args)
    {
        string name = args[0];
        Category category = new Category(name);
        categories.Add(name, category);
        return $"Created Category {name}!";
    }

    public string AddJobOffer(List<string> args)
    {
        string name = args[0];
        string jobTitle = args[1];
        string company = args[2];
        double salary = double.Parse(args[3]);
        string type = args[4];
        JobOffer offer = null;
        if (type == "onsite")
        {
            string city = args[5];
            offer = new OnSiteJobOffer
                (jobTitle, company, salary, city);
        }
        else
        {
            bool fullyRemote = bool.Parse(args[5]);
            offer = new RemoteJobOffer(jobTitle, company, salary, fullyRemote);
        }
        categories[name].AddJobOffer(offer);
        return $"Created JobOffer {jobTitle} in Category {name}!";
    }

    public string GetAverageSalary(List<string> args)
    {
        string name = args[0];
        double averageSalary = categories[name].AverageSalary();
        return $"The average salary is: {averageSalary:F2} BGN";
    }

    public string GetOffersAboveSalary(List<string> args)
    {
        string name = args[0];
        double salary = double.Parse(args[1]);
        List<JobOffer> offers = categories[name]
            .GetOffersAboveSalary(salary);
        return string.Join("\n", offers);
    }

    public string GetOffersWithoutSalary(List<string> args)
    {
        string name = args[0];
        List<JobOffer> offers = categories[name]
            .GetOffersWithoutSalary();
        return string.Join("\n", offers);
    }

}