using Gallery3SelfHost;
using System.Runtime.Serialization;

namespace Selfhost.DTO
{
    [DataContract]
    public class clsArtist
    //data only class
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Speciality { get; set; }
        [DataMember]
        public string Phone { get; set; }

        public Artist MapToEntity()
        {
            return new Artist()
            { Name = this.Name, Phone = this.Phone, Speciality = this.Speciality };
        }
    }
}