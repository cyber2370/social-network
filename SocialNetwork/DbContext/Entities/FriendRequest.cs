using System;

namespace DbContext.Entities
{
    public class FriendRequest
    {
        public FriendRequest()
        {
        }

        public FriendRequest(
            int userRequesterId,
            int userConfirmerId,
            bool isConfirmed,
            DateTime sendedDateTime)
        {
            UserRequesterId = userRequesterId;
            UserConfirmerId = userConfirmerId;
            IsConfirmed = isConfirmed;
            RequestedDateTime = sendedDateTime;
        }

        public int Id { get; set; }

        public int UserRequesterId { get; set; }
        public User Requester { get; set; }

        public int UserConfirmerId { get; set; }
        public User Confirmer { get; set; }

        public DateTime RequestedDateTime { get; set; }

        public bool IsConfirmed { get; set; }
    }
}
