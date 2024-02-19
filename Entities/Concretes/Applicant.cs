using Core.Entities;

namespace Entities.Concretes;

public class Applicant : User
{
    public string About { get; set; }
    public Applicant()
    {

    }

    public Applicant(string about)
    {
        About = about;
    }
}
