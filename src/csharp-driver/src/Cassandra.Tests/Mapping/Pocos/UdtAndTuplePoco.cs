﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cassandra.Tests.Mapping.Pocos
{
    public class UdtAndTuplePoco
    {
        public Guid Id1 { get; set; }

        public Tuple<long, long, string> Tuple1 { get; set; }

        public Song Udt1 { get; set; }

        public SortedSet<Song> UdtSet1 { get; set; }

        public List<Song> UdtList1 { get; set; }

        public SortedDictionary<Tuple<double, double>, string> TupleMapKey1 { get; set; }

        public SortedDictionary<string, Tuple<double, double>> TupleMapValue1 { get; set; }

        public SortedDictionary<string, List<int>> ListMapValue1 { get; set; }
    }
}
