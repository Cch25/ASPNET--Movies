using System;

namespace Filme.Core.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public byte MembershipTypeId { get; set; }
        public MembershipTypeDto MembershipType{ get; set; }

        //[Is18YearsOldOrMember]
        public DateTime? Birthdate { get; set; }
    }
}