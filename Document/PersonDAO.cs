using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFAM.Common;
using EFAM.Common.Constants;
using EFAM.Common.DTO;
using EFAM.Common.Logging;
using NHibernate;
using NHibernate.Criterion;

namespace EFAM.DAL.DAO
{
    public class PersonDAO
    {
        private static void AddYear(Person p)
        {
            try
            {
                if (p.TimeOfBirth != null)
                {
                    var timeOfBirth = (DateTime)p.TimeOfBirth;
                    p.TimeOfBirth = timeOfBirth.AddYears(GeneralConstants.YEAR_INCREMENT);
                }
            }
            catch (Exception ex) { }

            try
            {
                if (p.TimeOfDeath != null)
                {
                    var timeOfDeath = (DateTime)p.TimeOfDeath;
                    p.TimeOfDeath = timeOfDeath.AddYears(GeneralConstants.YEAR_INCREMENT);
                }
            }
            catch (Exception ex) { }
        }

        private static void SubstractYear(Person p)
        {
            try
            {
                if (p.TimeOfBirth != null)
                {
                    var timeOfBirth = (DateTime)p.TimeOfBirth;
                    p.TimeOfBirth = timeOfBirth.AddYears(GeneralConstants.YEAR_DECREMENT);
                }
            }
            catch (Exception ex) { }

            try
            {
                if (p.TimeOfDeath != null)
                {
                    var timeOfDeath = (DateTime)p.TimeOfDeath;
                    p.TimeOfDeath = timeOfDeath.AddYears(GeneralConstants.YEAR_DECREMENT);
                }
            }
            catch (Exception ex) { }
        }

        public static void Add(Person person)
        {
            AddYear(person);

            {
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(person);
                    transaction.Commit();
                }
            }
        }
        public static void Update(Person person)
        {
            AddYear(person);

            {
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(person);
                    transaction.Commit();
                }
            }
        }

        public static void Remove(Person person)
        {
            {
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(person);
                    transaction.Commit();
                }
            }
        }

        public static Person GetByPersonId(long familyId, string inFamilyId)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var person = session.QueryOver<Person>().Where(
                        p => p.Family.FamilyId == familyId && p.InFamilyId == inFamilyId).SingleOrDefault<Person>();
                    SubstractYear(person);
                    return person.PersonDetail.DeleteFlag == FlagConstants.DELETE_FLAG_DELETED ? null : person;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static List<Person> GetListPersonByFamilyId(long familyId)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var persons = session.QueryOver<Person>().Where(p => p.Family.FamilyId == familyId).List();
                    persons = persons.Where(p => p.PersonDetail.DeleteFlag != FlagConstants.DELETE_FLAG_DELETED).ToList();
                    foreach (var person in persons)
                    {
                        SubstractYear(person);
                    }
                    return persons.ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static List<Person> GetByParentAndParentPartner(long familyId, string parentId, string parentPartnerId)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var persons = session.QueryOver<Person>().Where(p =>
                                                                    p.Family.FamilyId == familyId &&
                                                                    p.ParentId == parentId &&
                                                                    p.ParentPartnerId == parentPartnerId).List();
                    persons = persons.Where(p => p.PersonDetail.DeleteFlag != FlagConstants.DELETE_FLAG_DELETED).ToList();
                    foreach (var person in persons)
                    {
                        SubstractYear(person);
                    }
                    return persons.ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static List<Person> GetPersons(long familyId, string fullname)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var personsInFamily = session.QueryOver<Person>().Where(p => p.Family.FamilyId == familyId).List();
                    personsInFamily = personsInFamily.Where(p => p.PersonDetail.DeleteFlag != FlagConstants.DELETE_FLAG_DELETED).ToList();
                    foreach (var person in personsInFamily)
                    {
                        SubstractYear(person);
                    }
                    return personsInFamily.Where(p => Utilities.GetFullname(p).Equals(fullname)).ToList();
                }
            }
            catch (Exception ex)
            {
                return new List<Person>();
            }
        }

        public static List<Person> GetCandidatesForJFR(long familyId, string fullname)
        {
            try
            {
                var personsWithSameFullname = GetPersons(familyId, fullname);
                var candidates = new List<Person>();
                foreach (var person in personsWithSameFullname)
                {
                    if (person.IsDeceased != null)
                    {
                        if (!((bool)person.IsDeceased))
                        {
                            candidates.Add(person);
                        }
                    }
                    else
                    {
                        candidates.Add(person);
                    }
                }

                return candidates.Where(p => UserDAO.GetUserByPerson(p.Family.FamilyId, p.InFamilyId) == null).ToList();
            }
            catch (Exception ex)
            {
                return new List<Person>();
            }
        }

        public static List<Person> GetChildren(long familyId, string inFamilyId)
        {
            if (inFamilyId == null)
            {
                return new List<Person>();
            }
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var persons = session.QueryOver<Person>().Where(
                        p => p.Family.FamilyId == familyId && p.ParentId == inFamilyId).List();
                    foreach (var person in persons)
                    {
                        SubstractYear(person);
                    }
                    return persons.Where(p => p.PersonDetail.DeleteFlag != FlagConstants.DELETE_FLAG_DELETED).ToList();
                }
            }
            catch (Exception ex)
            {
                return new List<Person>();
            }
        }

        public static List<Person> GetChildren_IncludeDeleted(long familyId, string inFamilyId)
        {
            if (inFamilyId == null)
            {
                return new List<Person>();
            }
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var persons = session.QueryOver<Person>().Where(
                        p => p.Family.FamilyId == familyId && p.ParentId == inFamilyId).List();
                    foreach (var person in persons)
                    {
                        SubstractYear(person);
                    }
                    return persons.ToList();
                }
            }
            catch (Exception ex)
            {
                return new List<Person>();
            }
        }

        // This function's functionality is as same as function GetByParentAndParentPartner(familyId, parentId, parentPartnerId)
        public static List<Person> GetChildren(long familyId, string inFamilyId, string partnerId)
        {
            if (inFamilyId == null)
            {
                return new List<Person>();
            }
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var persons = session.QueryOver<Person>().Where(
                        p => p.Family.FamilyId == familyId && p.ParentId == inFamilyId && p.ParentPartnerId == partnerId).List();
                    foreach (var person in persons)
                    {
                        SubstractYear(person);
                    }
                    return persons.Where(p => p.PersonDetail.DeleteFlag != FlagConstants.DELETE_FLAG_DELETED).ToList();
                }
            }
            catch (Exception ex)
            {
                return new List<Person>();
            }
        }

        public static List<Person> GetSiblings(long familyId, string inFamilyId)
        {
            try
            {
                var parentId = Utilities.GetParentIdFromChildId(inFamilyId);
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var persons = session.QueryOver<Person>().Where(
                        p => p.Family.FamilyId == familyId && p.ParentId == parentId).List();
                    foreach (var person in persons)
                    {
                        SubstractYear(person);
                    }
                    return persons.Where(p => p.PersonDetail.DeleteFlag != FlagConstants.DELETE_FLAG_DELETED)
                                  .Where(p => p.InFamilyId != inFamilyId).ToList();
                }
            }
            catch (Exception ex)
            {
                return new List<Person>();
            }
        }

        #region search person by full name (search like)

        private static QueryOver<Person> QuerySearchByFullname(long familyId, string keyword)
        {
            string[] fullname = Utilities.ConvertFullNameToFamilyNameMiddleNameGivenName(keyword);
            var querySearch = QueryOver.Of<Person>().Where(
                        (new LikeExpression("FamilyName", "%" + fullname[0] + "%") &&
                            (new LikeExpression("MiddleName", "%" + fullname[1] + "%") ||
                            new NullExpression("MiddleName")) &&
                            new LikeExpression("GivenName", "%" + fullname[2] + "%")) ||
                        (new LikeExpression("MiddleName", "%" + fullname[0] + "%") && new LikeExpression("GivenName", "%" + fullname[2] + "%"))
                        ).And(e => e.Family.FamilyId == familyId
                        ).JoinQueryOver(e => e.PersonDetail).Where(pd => pd.DeleteFlag == 0
                        );
            return querySearch;
        }

        public static int CountSearchByFullname(long familyId, string keyword)
        {
            var query = QuerySearchByFullname(familyId, keyword);
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    return query.GetExecutableQueryOver(session).Select(Projections.Count<Person>(p => p.InFamilyId)).RowCount();
                }
            }
            catch (Exception e)
            {
                Logger.Log.Error("Error search person by fullname: " + e);
                return 0;
            }
        }

        // search all result if maxRow parameter equal to 0
        public static IList<Person> SearchByFullname(int skip, int maxRow, long familyId, string keyword)
        {
            var query = QuerySearchByFullname(familyId, keyword);
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    if (maxRow == 0)
                    {
                        return query.GetExecutableQueryOver(session).Skip(skip).List();
                    }
                    return query.GetExecutableQueryOver(session).Skip(skip).Take(maxRow).List();
                }
            }
            catch (Exception e)
            {
                Logger.Log.Error("Error search person by fullname: " + e);
                return new List<Person>();
            }
        }

        #endregion

        #region search person by fullname and birthday in range

        private static QueryOver<Person> QuerySearchByFullnameAndBirthdayInRange(long familyId, string keyword, DateTime start, DateTime end)
        {
            string[] fullname = Utilities.ConvertFullNameToFamilyNameMiddleNameGivenName(keyword);
            /*start = start.AddYears(GeneralConstants.YEAR_INCREMENT);
            end = end.AddYears(GeneralConstants.YEAR_INCREMENT);*/

            return QueryOver.Of<Person>().Where(
                (new LikeExpression("FamilyName", "%" + fullname[0] + "%") &&
                            (new LikeExpression("MiddleName", "%" + fullname[1] + "%") ||
                            new NullExpression("MiddleName")) &&
                            new LikeExpression("GivenName", "%" + fullname[2] + "%")) ||
                (new LikeExpression("MiddleName", "%" + fullname[0] + "%") && new LikeExpression("GivenName", "%" + fullname[2] + "%"))
                ).And(e => e.Family.FamilyId == familyId &&
                    e.TimeOfBirth != null && (start <= e.TimeOfBirth && e.TimeOfBirth <= end)
                ).JoinQueryOver(e => e.PersonDetail).Where(pd => pd.DeleteFlag == 0
                );
        }

        public static int CountSearchByFullnameAndBirthdayInRange(long familyId, string keyword, DateTime start, DateTime end)
        {
            var query = QuerySearchByFullnameAndBirthdayInRange(familyId, keyword, start, end);
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    return query.GetExecutableQueryOver(session).Select(Projections.Count<Person>(p => p.InFamilyId)).RowCount();
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("Error when search person by fullname and birthday in range: " + ex);
                return 0;
            }
        }

        public static IList<Person> SearchByFullnameAndBirthdayInRange(int skip, int maxRow, long familyId, string keyword, DateTime start, DateTime end)
        {
            var query = QuerySearchByFullnameAndBirthdayInRange(familyId, keyword, start, end);
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    return
                        query.GetExecutableQueryOver(session).Skip(skip).Take(maxRow).List();
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("Error when search person by fullname and birthday in range: " + ex);
                return new List<Person>();
            }
        }
        #endregion

        #region search person by fullname and birthday before a specific time
        private static QueryOver<Person> QuerySearchByFullnameAndBirthdayBefore(long familyId, string keyword, DateTime before)
        {
            string[] fullname = Utilities.ConvertFullNameToFamilyNameMiddleNameGivenName(keyword);
            /*before = before.AddYears(GeneralConstants.YEAR_INCREMENT);*/

            return QueryOver.Of<Person>().Where(
                (new LikeExpression("FamilyName", "%" + fullname[0] + "%") &&
                            (new LikeExpression("MiddleName", "%" + fullname[1] + "%") ||
                            new NullExpression("MiddleName")) &&
                            new LikeExpression("GivenName", "%" + fullname[2] + "%")) ||
                (new LikeExpression("MiddleName", "%" + fullname[0] + "%") && new LikeExpression("GivenName", "%" + fullname[2] + "%"))
                ).And(e => e.Family.FamilyId == familyId && e.TimeOfBirth != null &&
                           e.TimeOfBirth <= before
                ).JoinQueryOver(e => e.PersonDetail).Where(pd => pd.DeleteFlag == 0
                );
        }

        public static int CountSearchByFullnameAndBirthdayBefore(long familyId, string keyword, DateTime before)
        {
            var query = QuerySearchByFullnameAndBirthdayBefore(familyId, keyword, before);

            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    return query.GetExecutableQueryOver(session).Select(Projections.Count<Person>(p => p.InFamilyId)).RowCount();
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("Error when search person by fullname and birthday before: " + ex);
                return 0;
            }
        }
        public static IList<Person> SearchByFullnameAndBirthdayBefore(int skip, int maxRow, long familyId, string keyword, DateTime before)
        {
            var query = QuerySearchByFullnameAndBirthdayBefore(familyId, keyword, before);
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    return query.GetExecutableQueryOver(session).Skip(skip).Take(maxRow).List();
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("Error when search person by fullname and birthday before: " + ex);
                return new List<Person>();
            }
        }
        #endregion

        #region search person by fullname and birthday after a specific time

        private static QueryOver<Person> QuerySearchByFullnameAndBirthdayAfter(long familyId, string keyword, DateTime after)
        {
            string[] fullname = Utilities.ConvertFullNameToFamilyNameMiddleNameGivenName(keyword);
            /*after = after.AddYears(GeneralConstants.YEAR_INCREMENT);*/

            return QueryOver.Of<Person>().Where(
                (new LikeExpression("FamilyName", "%" + fullname[0] + "%") &&
                            (new LikeExpression("MiddleName", "%" + fullname[1] + "%") ||
                            new NullExpression("MiddleName")) &&
                            new LikeExpression("GivenName", "%" + fullname[2] + "%")) ||
                (new LikeExpression("MiddleName", "%" + fullname[0] + "%") && new LikeExpression("GivenName", "%" + fullname[2] + "%"))
                ).And(e => e.Family.FamilyId == familyId && e.TimeOfBirth != null &&
                           after <= e.TimeOfBirth
                ).JoinQueryOver(e => e.PersonDetail).Where(pd => pd.DeleteFlag == 0);
        }

        public static int CountSearchByFullnameAndBirthdayAfter(long familyId, string keyword, DateTime after)
        {
            try
            {
                var query = QuerySearchByFullnameAndBirthdayAfter(familyId, keyword, after);
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    return query.GetExecutableQueryOver(session).Select(Projections.Count<Person>(p => p.InFamilyId)).RowCount();
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("Error when search person by fullname and birthday after: " + ex);
                return 0;
            }
        }
        public static IList<Person> SearchByFullnameAndBirthdayAfter(int skip, int maxRow, long familyId, string keyword, DateTime after)
        {
            try
            {
                var query = QuerySearchByFullnameAndBirthdayAfter(familyId, keyword, after);
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    return query.GetExecutableQueryOver(session).Skip(skip).Take(maxRow).List();
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("Error when search person by fullname and birthday after: " + ex);
                return new List<Person>();
            }
        }
        #endregion

        #region search person by fullname and parent name
        private static QueryOver<Person> QuerySearchByFullnameAndParentName(long familyId, string keyword, string parentName)
        {
            string[] fullname = Utilities.ConvertFullNameToFamilyNameMiddleNameGivenName(keyword);
            string[] parentFullname = Utilities.ConvertFullNameToFamilyNameMiddleNameGivenName(parentName);

            // parent name input is father or mother that is a member of family                    
            // search person table for parent name (parent name is in person table)
            // parentId of child object mapping with a record in person table
            var parentIdP1SubQuery = QueryOver.Of<Person>().Where(
                (new LikeExpression("FamilyName", "%" + parentFullname[0] + "%") &&
                    (new LikeExpression("MiddleName", "%" + parentFullname[1] + "%") ||
                    new NullExpression("MiddleName")) &&
                    new LikeExpression("GivenName", "%" + parentFullname[2] + "%")) ||
                (new LikeExpression("MiddleName", "%" + parentFullname[0] + "%") && new LikeExpression("GivenName", "%" + parentFullname[2] + "%"))
                ).And(p1 => p1.Family.FamilyId == familyId
                ).JoinQueryOver(p1 => p1.PersonDetail).Where(pd => pd.DeleteFlag == 0
                ).Select(Projections.Distinct(Projections.Property<Person>(p1 => p1.InFamilyId)));
            // parent name input is father or mother that is not a member of family                    
            // search partner table for parent name (parent name is in partner table)
            // parentPartnerId of child object mapping with a record in partner table
            var parentIdPmSubQuery = QueryOver.Of<Partner>().Where(
                (new LikeExpression("FamilyName", "%" + parentFullname[0] + "%") &&
                    (new LikeExpression("MiddleName", "%" + parentFullname[1] + "%") ||
                    new NullExpression("MiddleName")) &&
                    new LikeExpression("GivenName", "%" + parentFullname[2] + "%")) ||
                (new LikeExpression("MiddleName", "%" + parentFullname[0] + "%") && new LikeExpression("GivenName", "%" + parentFullname[2] + "%"))
                ).JoinQueryOver(pm => pm.PartnerDetail).Where(pmd => pmd.DeleteFlag == 0
                ).Select(Projections.Distinct(Projections.Property<Partner>(pm => pm.PartnerId)));
            // parent name input is father or mother that is a member of family                    
            // search person table for parent name (parent name is in person table)
            // parentPartnerId of child object mapping with a record in person table
            var parentIdP2SubQuery = QueryOver.Of<Person>().Where(
                (new LikeExpression("FamilyName", "%" + parentFullname[0] + "%") &&
                    (new LikeExpression("MiddleName", "%" + parentFullname[1] + "%") ||
                    new NullExpression("MiddleName")) &&
                    new LikeExpression("GivenName", "%" + parentFullname[2] + "%")) ||
                (new LikeExpression("MiddleName", "%" + parentFullname[0] + "%") && new LikeExpression("GivenName", "%" + parentFullname[2] + "%"))
                ).And(p2 => p2.Family.FamilyId == familyId
                ).JoinQueryOver(p2 => p2.PersonDetail).Where(pd => pd.DeleteFlag == 0
                ).Select(Projections.Distinct(Projections.Property<Person>(p2 => p2.InFamilyId)));

            // search parent name in 3 cases
            // parentId in person or parentPartnerId in partner or parentPartnerId in person
            var or = Restrictions.Disjunction();
            or.Add(Subqueries.WhereProperty<Person>(c => c.ParentId).In(parentIdP1SubQuery));
            or.Add(Subqueries.WhereProperty<Person>(c => c.ParentPartnerId).In(parentIdPmSubQuery));
            or.Add(Subqueries.WhereProperty<Person>(c => c.ParentPartnerId).In(parentIdP2SubQuery));

            return QueryOver.Of<Person>().Where(
                (new LikeExpression("FamilyName", "%" + fullname[0] + "%") &&
                            (new LikeExpression("MiddleName", "%" + fullname[1] + "%") ||
                            new NullExpression("MiddleName")) &&
                            new LikeExpression("GivenName", "%" + fullname[2] + "%")) ||
                (new LikeExpression("MiddleName", "%" + fullname[0] + "%") && new LikeExpression("GivenName", "%" + fullname[2] + "%"))
                ).And(c => c.Family.FamilyId == familyId
                ).Where(Restrictions.Disjunction().Add(or)
                ).JoinQueryOver(c => c.PersonDetail).Where(cd => cd.DeleteFlag == 0
                );
        }

        // search parent by parent id and partner id
        public static int CountSearchByFullnameAndParentName(long familyId, string keyword, string parentName)
        {
            var query = QuerySearchByFullnameAndParentName(familyId, keyword, parentName);
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    return query.GetExecutableQueryOver(session).Select(Projections.Count<Person>(p => p.InFamilyId)).RowCount();
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("Error on searching person by name and parent name : " + ex);
                return 0;
            }
        }
        public static IList<Person> SearchByFullnameAndParentName(int skip, int maxRow, long familyId, string keyword, string parentName)
        {
            var query = QuerySearchByFullnameAndParentName(familyId, keyword, parentName);
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    return query.GetExecutableQueryOver(session).Skip(skip).Take(maxRow).List();
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("Error on searching person by name and parent name : " + ex);
                return new List<Person>();
            }
        }
        #endregion

    }
}
