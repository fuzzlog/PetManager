using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PetManager.Models
{
    [DataContract]
    public class AnimalMetaData
    {
        [DataMember]

        public int AnimalsID { get; set; }
        [DataMember]
        public string moniker { get; set; }
        [DataMember]
        public Nullable<int> petid { get; set; }
        [DataMember]
        public string city { get; set; }
        [DataMember]
        public Nullable<System.DateTime> located { get; set; }

    }
}
