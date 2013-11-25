using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTier;
using DataTier.DAO;
using DataTier.Entities;
using Service.DTO;

namespace Service.Handler
{
    public class MessageHandler
    {
        public static List<MessageDto> GetMessageUnread()
        {
            List<MessageDto> MessDto = new List<MessageDto>();
            if (MessageDAO.getMessageUnread() == null) return null;
            List<Messages> messages = MessageDAO.getMessageUnread().ToList();

            MessDto = Common.ConvertToMessageDto(messages);

            return MessDto;
        }

        public static List<MessageDto> GetAllMessage()
        {
            List<MessageDto> MessDto = new List<MessageDto>();
            if (MessageDAO.getAllMessage() == null) return null;
            List<Messages> messages = MessageDAO.getAllMessage().ToList();

            MessDto = Common.ConvertToMessageDto(messages);

            return MessDto;
        }

        public static int CountMessageUnread()
        {
            if (MessageDAO.getMessageUnread() == null) return 0;
            List<Messages> messages = MessageDAO.getMessageUnread().ToList();
            return messages.Count;
        }

        public void AddMessage(MessageDto message)
        {
            Messages mess = new Messages();
            mess = Common.ConvertToMessages(message);
            DAO.Execute(mess, Entity.MESSAGE, ExecuteType.ADD);
        }

        public void MessageRead(MessageDto message)
        {
            Messages mess = new Messages();
            mess = Common.ConvertToMessages(message);
            mess.Status = StatusDAO.getStatusById(CONST.STATUS.READ);
            DAO.Execute(mess, Entity.MESSAGE, ExecuteType.UPDATE);
        }

        public void MessageDelete(MessageDto message)
        {
            Messages mess = new Messages();
            mess = Common.ConvertToMessages(message);
            mess.Status = StatusDAO.getStatusById(CONST.STATUS.DELETE);
            DAO.Execute(mess, Entity.MESSAGE, ExecuteType.UPDATE);
        }
    }
}
