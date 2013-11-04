using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFAM.Common;
using EFAM.Common.DTO;
using NHibernate;
using EFAM.Common.Constants;
using NHibernate.Criterion;

namespace EFAM.DAL.DAO
{
    public class EventDAO
    {
        public static void Add(Event Event)
        {
            {
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(Event);
                    transaction.Commit();
                }
            }
        }
        public static void Update(Event Event)
        {
            {
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(Event);
                    transaction.Commit();
                }
            }
        }

        public static void Remove(Event Event)
        {
            {
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(Event);
                    transaction.Commit();
                }
            }
        }
        public static Event GetEventById(long EventId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.Get<Event>(EventId);
        }
        public static IList<Event> GetEventRangeByFamilyId(long familyId, int index, int offset)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var Event = session.QueryOver<Event>()
                        .Where(p => p.Family.FamilyId == familyId
                            && p.DeleteFlag == FlagConstants.DELETE_FLAG_NOT_DELETED
                            && p.ActiveFlag == FlagConstants.ACTIVE_FLAG_ACTIVE)
                        .OrderBy(e => e.StartTime)
                        .Desc
                        .List();
                    List<Event> GetChildList = new List<Event>();
                    for (int i = index; i < index + offset; i++)
                    {
                        if (i <= Event.ToList().Count - 1)
                            GetChildList.Add(Event.ToList().ElementAt(i));
                    }
                    return GetChildList;
                }
            }
            catch (Exception ex)
            {
                EFAM.Common.Logging.Logger.Log.Error("Get event list error (EventDAO) : " + ex);
                return null;
            }
        }
        public static IList<Event> GetHiddenEventByFamilyId(long familyId)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var Event = session.QueryOver<Event>()
                        .Where(p => p.Family.FamilyId == familyId
                            && p.HiddenFlag == FlagConstants.EVENT_HIDDEN)
                        .List();
                    return Event.ToList();
                }
            }
            catch (Exception ex)
            {
                EFAM.Common.Logging.Logger.Log.Error("Get event list error (EventDAO) : " + ex);
                return null;
            }
        }
        public static int GetEventCountFamilyId(long familyId)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var Event = session.QueryOver<Event>()
                        .Where(p => p.Family.FamilyId == familyId
                            && p.DeleteFlag == FlagConstants.DELETE_FLAG_NOT_DELETED
                            && p.ActiveFlag == FlagConstants.ACTIVE_FLAG_ACTIVE)
                        .List();
                    return Event.Count;
                }
            }
            catch (Exception ex)
            {
                EFAM.Common.Logging.Logger.Log.Error("Get event list count error (EventDAO) : " + ex);
                return 0;
            }
        }
        public static IList<Event> GetAnnalByFamilyId(long familyId)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var Event = session.QueryOver<Event>()
                        .Where(p => p.Family.FamilyId == familyId
                            && p.ImportanceFlag == FlagConstants.IMPORTANT_FLAG_TRUE
                            && p.DeleteFlag == FlagConstants.DELETE_FLAG_NOT_DELETED
                            && p.ActiveFlag == FlagConstants.ACTIVE_FLAG_ACTIVE)
                        .List();
                    return Event.ToList();
                }
            }
            catch (Exception ex)
            {
                EFAM.Common.Logging.Logger.Log.Error("Get Annal list error (EventDAO) : " + ex);
                return null;
            }
        }
        public static IList<Event> GetAnnalByFamilyIdByAdmin(long familyId)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var Event = session.QueryOver<Event>()
                        .Where(p => p.Family.FamilyId == familyId
                            && p.ImportanceFlag == FlagConstants.IMPORTANT_FLAG_TRUE
                            && p.DeleteFlag == FlagConstants.DELETE_FLAG_NOT_DELETED
                            && p.ActiveFlag == FlagConstants.ACTIVE_FLAG_ACTIVE
                            && (p.HiddenFlag == FlagConstants.EVENT_UNHIDDEN || p.HiddenFlag == null))
                        .List();
                    return Event.ToList();
                }
            }
            catch (Exception ex)
            {
                EFAM.Common.Logging.Logger.Log.Error("Get Annal list error (EventDAO) : " + ex);
                return null;
            }
        }
        public static IList<Event> GetUnAnnalByFamilyId(long familyId)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var Event = session.QueryOver<Event>()
                        .Where(p => p.Family.FamilyId == familyId
                            && p.ImportanceFlag == FlagConstants.IMPORTANT_FLAG_FALSE
                            && p.DeleteFlag == FlagConstants.DELETE_FLAG_NOT_DELETED
                            && p.ActiveFlag == FlagConstants.ACTIVE_FLAG_ACTIVE
                            && (p.HiddenFlag == FlagConstants.EVENT_UNHIDDEN || p.HiddenFlag == null))
                        .List();
                    return Event.ToList();
                }
            }
            catch (Exception ex)
            {
                EFAM.Common.Logging.Logger.Log.Error("Get UnAnnal list error (EventDAO) : " + ex);
                return null;
            }
        }
        public static IList<Event> GetUnApproveEventByFamilyId(long familyId)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var Event = session.QueryOver<Event>()
                        .Where(p => p.Family.FamilyId == familyId
                            && p.ActiveFlag == FlagConstants.ACTIVE_FLAG_INACTIVE
                            && p.DeleteFlag == FlagConstants.DELETE_FLAG_NOT_DELETED
                            && (p.HiddenFlag == FlagConstants.EVENT_UNHIDDEN || p.HiddenFlag == null))
                        .List();
                    return Event.ToList();
                }
            }
            catch (Exception ex)
            {
                EFAM.Common.Logging.Logger.Log.Error("Get UnApproved event list error (EventDAO) : " + ex);
                return null;
            }
        }
        public static IList<Event> GetDeletedEventByFamilyId(long familyId)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var Event = session.QueryOver<Event>()
                        .Where(p => p.Family.FamilyId == familyId
                            && p.DeleteFlag == FlagConstants.DELETE_FLAG_DELETED
                            && (p.HiddenFlag == FlagConstants.EVENT_UNHIDDEN || p.HiddenFlag == null))
                        .List();
                    return Event.ToList();
                }
            }
            catch (Exception ex)
            {
                EFAM.Common.Logging.Logger.Log.Error("Get UnApproved event list error (EventDAO) : " + ex);
                return null;
            }
        }
        public static IList<Event> GetEventListByDate(long familyId, DateTime start, DateTime end)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var Event = session.QueryOver<Event>()
                        .Where(p => p.Family.FamilyId == familyId
                            && p.StartTime > start
                            && p.StartTime < end
                            && p.ActiveFlag == FlagConstants.ACTIVE_FLAG_ACTIVE
                            && p.DeleteFlag == FlagConstants.DELETE_FLAG_NOT_DELETED)
                        .List();
                    return Event.ToList();
                }
            }
            catch (Exception ex)
            {
                EFAM.Common.Logging.Logger.Log.Error("Get Event list by Date error (EventDAO) : " + ex);
                return null;
            }
        }
        #region search event in family by content
        public static QueryOver<Event> QuerySearchByFamilyAndContent(string keyword, int activeFlag, long familyId)
        {
            var likeKeyword = "%" + Utilities.RemoveDuplicateSpaces(keyword.Trim()) + "%";
            var query = QueryOver.Of<Event>().Where(
                           new LikeExpression("Title", likeKeyword) ||
                           new LikeExpression("Body", likeKeyword)).
                           And(e => e.Family.FamilyId == familyId);
            if (activeFlag > 2)
            {
                return query;
            }
            return query.And(e => e.ActiveFlag == activeFlag);
        }       
        #endregion

        #region search event by content and date in range
        public static QueryOver<Event> QuerySearchEventByFamilyAndContentInRange(string keyword, int activeFlag, long familyId, DateTime before, DateTime after)
        {
            var likeKeyword = "%" + Utilities.RemoveDuplicateSpaces(keyword.Trim()) + "%";
            var query = QueryOver.Of<Event>().Where(
                           new LikeExpression("Title", likeKeyword) ||
                           new LikeExpression("Body", likeKeyword)).
                           And(e => e.Family.FamilyId == familyId && e.DeleteFlag == 0 &&
                               ((before <= e.StartTime && e.StartTime <= after) ||
                               (before <= e.EndTime && e.EndTime <= after && e.EndTime != null) ||
                               (e.StartTime <= before && after <= e.EndTime && e.EndTime != null)
                               ));
            if (activeFlag > 2)
            {
                return query;
            }
            return query.And(e => e.ActiveFlag == activeFlag);
        }
        #endregion

        #region search event in family by content and date before a specific date
        public static QueryOver<Event> QuerySearchEventByFamilyAndContentBefore(string keyword, int activeFlag, long familyId, DateTime before)
        {
            var likeKeyword = "%" + Utilities.RemoveDuplicateSpaces(keyword.Trim()) + "%";
            var query = QueryOver.Of<Event>().Where(
                new LikeExpression("Title", likeKeyword) ||
                new LikeExpression("Body", likeKeyword)).
                And(e => e.Family.FamilyId == familyId && e.DeleteFlag == 0 &&
                         (e.EndTime <= before) ||
                         (e.EndTime == null && e.StartTime <= before)
                );
            if (activeFlag > 2)
            {
                return query;
            }
            return query.And(e => e.ActiveFlag == activeFlag);
        }
        #endregion

        #region search event in family by content and date after a specific date
        public static QueryOver<Event> QuerySearchEventByFamilyAndContentAfter(string keyword, int activeFlag, long familyId, DateTime after)
        {
            var likeKeyword = "%" + Utilities.RemoveDuplicateSpaces(keyword.Trim()) + "%";
            var query = QueryOver.Of<Event>().Where(
                new LikeExpression("Title", likeKeyword) ||
                new LikeExpression("Body", likeKeyword)).
                And(e => e.Family.FamilyId == familyId && e.DeleteFlag == 0 &&
                         (after <= e.StartTime));
            if (activeFlag > 2)
            {
                return query;
            }
            return query.And(e => e.ActiveFlag == activeFlag);
        }
        #endregion

        public static int CountQueryResult(QueryOver<Event> query)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return query.GetExecutableQueryOver(session).Select(Projections.Count<Event>(e => e.EventId)).RowCount();
            }
        }

        public static IList<Event> GetQueryResult(int skip, int maxRow, QueryOver<Event> query)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return query.GetExecutableQueryOver(session).Skip(skip).Take(maxRow).List();
            }
        }
    }
}
