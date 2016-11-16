using System;

namespace Managers.Models
{
    public class FriendRequestModel
    {
        public FriendRequestModel()
        {
        }

        public FriendRequestModel(
            UserModel requester,
            UserModel confirmer,
            bool isConfirmed,
            DateTime sendedDateTime)
        {
            Requester = requester;
            Confirmer = confirmer;
            IsConfirmed = isConfirmed;
            RequestedDateTime = sendedDateTime;
        }

        public int Id { get; set; }
        
        public UserModel Requester { get; set; }
        
        public UserModel Confirmer { get; set; }

        public DateTime RequestedDateTime { get; set; }

        public bool IsConfirmed { get; set; }
    }
}
