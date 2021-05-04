using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Revivevzw.DataContracts
{
    [DataContract]
    public class Setting
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "tnumber")]
        public int tnumber { get; set; }

        [DataMember(Name = "keys")]
        public string keys { get; set; }

        [DataMember(Name = "value")]
        public string value { get; set; }

        [DataMember(Name = "v0")]
        public string V0 { get; set; }

        [DataMember(Name = "v1")]
        public string V1 { get; set; }

        [DataMember(Name = "v2")]
        public string V2 { get; set; }

        [DataMember(Name = "v3")]
        public string V3 { get; set; }

        [DataMember(Name = "v4")]
        public string V4 { get; set; }

        [DataMember(Name = "v5")]
        public string V5 { get; set; }

        [DataMember(Name = "v6")]
        public string V6 { get; set; }

        [DataMember(Name = "v7")]
        public string V7 { get; set; }

        [DataMember(Name = "v8")]
        public string V8 { get; set; }

        [DataMember(Name = "v9")]
        public string V9 { get; set; }

        [DataMember(Name = "v10")]
        public string V10 { get; set; }

        [DataMember(Name = "v11")]
        public string V11 { get; set; }

        [DataMember(Name = "v12")]
        public string V12 { get; set; }

        [DataMember(Name = "v13")]
        public string V13 { get; set; }

        [DataMember(Name = "v14")]
        public string V14 { get; set; }

        [DataMember(Name = "n0")]
        public int N0 { get; set; }

        [DataMember(Name = "n1")]
        public int N1 { get; set; }

        [DataMember(Name = "n2")]
        public int N2 { get; set; }

        [DataMember(Name = "n3")]
        public int N3 { get; set; }

        [DataMember(Name = "n4")]
        public int N4 { get; set; }

        [DataMember(Name = "n5")]
        public int N5 { get; set; }

        [DataMember(Name = "n6")]
        public int N6 { get; set; }

        [DataMember(Name = "n7")]
        public int N7 { get; set; }

        [DataMember(Name = "n8")]
        public int N8 { get; set; }

        [DataMember(Name = "n9")]
        public int N9 { get; set; }

        [DataMember(Name = "n10")]
        public int N10 { get; set; }

        [DataMember(Name = "n11")]
        public int N11 { get; set; }

        [DataMember(Name = "n12")]
        public int N12 { get; set; }

        [DataMember(Name = "n13")]
        public int N13 { get; set; }

        [DataMember(Name = "n14")]
        public int N14 { get; set; }

        //[DataMember(Name = "short")]
        //public int short { get; set; }

        [DataMember(Name = "remarks")]
        public string remarks { get; set; }

        [DataMember(Name = "deleted")]
        public char deleted { get; set; }


    }
}
