using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTier.Entities;
using NHibernate;

namespace DataTier.DAO
{
    public class MessageDAO:DAO
    {
        public static Messages getMessageById(int id)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                    return session.Get<Messages>(id);

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static IList<Messages> getMessageUnread()
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var Messages = session.QueryOver<Messages>()
                        .Where(p => p.Status.Id == "Unread"
                        )
                        .OrderBy(p => p.CreatedDate).Desc
                        .List();
                    return Messages.ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static IList<Messages> getAllMessage()
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var Messages = session.QueryOver<Messages>()
                        .WhereNot(p => p.Status.Id == "Delete")
                        .OrderBy(p => p.CreatedDate).Desc
                        .List();
                    return Messages.ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
