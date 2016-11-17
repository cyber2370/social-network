using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Managers.Interfaces;
using Managers.Models;

namespace SocialNetworkApi.Controllers
{
    public class MessagesController : ApiController
    {
        private readonly IMessagesManager _messagesManager;

        public MessagesController(IMessagesManager messagesManager)
        {
            _messagesManager = messagesManager;
        }

        [HttpPost]
        public async Task<MessageModel> SendMessage([FromBody]MessageModel model)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpRequestException("Invalid model state");    
            }

            return await _messagesManager.AddMessage(model);
        }
        
        [HttpDelete]
        public async Task<bool> RemoveMessage(int id)
        {
            return await _messagesManager.DeleteMessage(id);
        }
    }
}