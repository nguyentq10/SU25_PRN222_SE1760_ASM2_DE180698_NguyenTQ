﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace DNATest.Repositories.NguyenTQ.Models;

public partial class TestResultThanhDc
{
    public int TestResultThanhDcid { get; set; }

    public int? BookingMinhNdaid { get; set; }

    public string ResultCode { get; set; }

    public decimal? MatchPercent { get; set; }

    public decimal? ProbabilityPaternity { get; set; }

    public string Conclusion { get; set; }

    public DateTime? ResultDate { get; set; }

    public string EvaluatedBy { get; set; }

    public bool? IsDelivered { get; set; }

    public string Note { get; set; }

    public virtual BookingMinhNdum BookingMinhNda { get; set; }

    public virtual ICollection<RelationshipTestThanhDc> RelationshipTestThanhDcs { get; set; } = new List<RelationshipTestThanhDc>();
}