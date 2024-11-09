using System;
using System.Collections.Generic;
using System.Text;

public class RemoteJobOffer : JobOffer
{
    private bool fullyRemote;

    public RemoteJobOffer(string jobTitle, string company, double salary, bool fullyRemote) : base(jobTitle, company, salary)
    {
        FullyRemote = fullyRemote;
    }

    public bool FullyRemote
    {
        get
        {
            return fullyRemote;
        }
        set
        {
            fullyRemote = value;
        }
    }

    public override string ToString()
    {
        return base.ToString() + $"Fully Remote: {(fullyRemote ? "yes" : "no")}";
    }
}