using System;
using System.Collections;
using System.Collections.Generic;
using FastReport;
using FastReport.Data;
using FastReport.Export.Pdf;
using ReferrencedProject;

namespace FastReportIntegration
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Report report = new Report())
            {
                report.Load("c:\\dev\\fastReportIntegration\\FastReportIntegration\\report.frx");

                var outer = new Outer();
                report.RegisterData(new List<Outer>{ outer}, "Outers", 4);

                report.Prepare();

                report.Export(new PDFExport(), "c:\\dev\\fastReportIntegration\\FastReportIntegration\\report.pdf");
            }
        }
    }

    public class Outer
    {
        public string Name { get; } = "OuterName";

        public Inner Second { get; } = new Inner();

        public IList<Inner> Inner { get; } = new List<Inner> { new Inner() };
    }

    public class Inner
    {
        public string Name { get; } = "InnerName";

        public IList<Referrenced> Referreds { get; } = new List<Referrenced> { new Referrenced() };
    }
}
