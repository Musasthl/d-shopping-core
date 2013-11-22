using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTier.Entities;
using NHibernate;

namespace DataTier.DAO
{
    public class CommentDAO:DAO
    {
        public static Comments getCommentById(int id)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                    return session.Get<Comments>(id);

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static IList<Comments> getAllCommentByProduct(int productId)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var Comment = session.QueryOver<Comments>()
                        .Where(p => p.Status.Id == "Active"
                            && p.Product.Id == productId
                        )
                        .OrderBy(p => p.CreatedDate).Desc
                        .List();
                    return Comment.ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
