﻿namespace NZWalks.API.Models.Domain
{
    public class Region
    {
        public Guid ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Area { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public long Population { get; set; }

        //Navigation Property 
        // one Region can have multiple walks

        public IEnumerable<Walk> walks { get; set; }
    }
}
