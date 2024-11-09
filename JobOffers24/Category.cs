using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Category
{
    private string name;
    private List<JobOffer> jobOffers;

    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            if(value.Length < 2 || value.Length > 40)
            {
                throw new ArgumentException("Name should be between 2 and 40 characters!");
            }
            name = value;
        }
    }

    public Category(string name)
    {
        Name = name;
        jobOffers = new List<JobOffer>();
    }

    public void AddJobOffer(JobOffer offer)
    {
        jobOffers.Add(offer);
    }

    public double AverageSalary()
    {
        if (jobOffers.Count > 0)
        {
            return jobOffers.Average(item => item.Salary);
        }
        else
        {
            return 0;
        }
    }

    public List<JobOffer> GetOffersAboveSalary(double salary)
    {
        return jobOffers
            .Where(item => item.Salary >= salary)
            .OrderByDescending(item => item.Salary)
            .ToList();
    }

    public List<JobOffer> GetOffersWithoutSalary()
    {
        return jobOffers
            .Where(item => item.Salary == 0)
            .OrderBy(item => item.Company)
            .ToList();
    }

    public override string ToString()
    {
        return $"Category {Name}\nTotal Offers: {jobOffers.Count}";
    }
}