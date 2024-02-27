﻿using Core.Entities;

namespace Entities.Concretes;

public class Blacklist : BaseEntity<int>
{
    public int ApplicantId { get; set; }
    public string Reason { get; set; }
    public DateTime Date { get; set; }

    public virtual Applicant? Applicant { get; set; }
    public Blacklist()
    {
        
    }

    public Blacklist(int id, int applicantId, string reason, DateTime date)
    {
        Id = id;
        ApplicantId = applicantId;
        Reason = reason;
        Date = date;
    }
}
