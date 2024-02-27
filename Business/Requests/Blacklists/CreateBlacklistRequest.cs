﻿namespace Business.Requests.Blacklists;

public class CreateBlacklistRequest
{
    public int ApplicantId { get; set; }
    public string Reason { get; set; }
    public DateTime Date { get; set; }
}
