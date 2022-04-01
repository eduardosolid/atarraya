namespace WebAPI.Data.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using DbPerson = Entities.Person;
    using ModelPerson = ClassLibrary.Models.Person;
    public class PeopleRepository
    {
        private readonly DemoOneContext _demoOneContext;
        public PeopleRepository(DemoOneContext demoOneContext)
        {
            _demoOneContext = demoOneContext;
        }

        public async Task Add(ModelPerson model)
        {
            _demoOneContext.People!.Add(new DbPerson(model.PersonId, model.FirstName!, model.FatherLastName!, model.MotherLastName!, model.BirthDate, model.BirthState!));
            await _demoOneContext.SaveChangesAsync();
        }

        public async Task Update(ModelPerson model)
        {
            _demoOneContext.People!.Update(new DbPerson(model.PersonId, model.FirstName!, model.FatherLastName!, model.MotherLastName!, model.BirthDate, model.BirthState!));
            await _demoOneContext.SaveChangesAsync();
        }

        public async Task Remove(ModelPerson model)
        {
            _demoOneContext.People!.Remove(new DbPerson(model.PersonId, model.FirstName!, model.FatherLastName!, model.MotherLastName!, model.BirthDate, model.BirthState!));
            await _demoOneContext.SaveChangesAsync();
        }

        public async Task<List<ModelPerson>> Select(Guid? personId = null, string? firstName = null, string? fatherLastName = null,
            string? motherLastName = null, DateTime? birthDate = null, string? birthState = null)
        {
            var query = _demoOneContext.People!.AsNoTracking();
            if (personId.HasValue)
                query.Where(p => p.PersonId == personId);

            if (!string.IsNullOrEmpty(firstName))
                query.Where(p => p.FirstName == firstName);

            if (!string.IsNullOrEmpty(fatherLastName))
                query.Where(p => p.FatherLastName == fatherLastName);

            if (!string.IsNullOrEmpty(motherLastName))
                query.Where(p => p.MotherLastName == motherLastName);

            if (birthDate.HasValue)
                query.Where(p => p.BirthDate == birthDate);

            if (!string.IsNullOrEmpty(birthState))
                query.Where(p => p.BirthState == birthState);

            var people = await query.Select(p => new ModelPerson
            {
                PersonId = p.PersonId,
                FirstName = p.FirstName,
                FatherLastName = p.FatherLastName,
                MotherLastName = p.MotherLastName,
                BirthDate = p.BirthDate,
                BirthState = p.BirthState

            }).ToListAsync();

            return people;
        }

        public async Task<bool> Any(Guid? personId = null, string? firstName = null, string? fatherLastName = null,
            string? motherLastName = null, DateTime? birthDate = null, string? birthState = null)
        {
            var query = _demoOneContext.People!.AsNoTracking();

            Expression<Func<DbPerson, bool>> filter1 = MakeExpression1(personId, firstName, fatherLastName, motherLastName, birthDate, birthState);

            var any = await query.AnyAsync(filter1);

            return any;
        }

        public async Task<ModelPerson?> First(Guid? personId = null, string? firstName = null, string? fatherLastName = null,
            string? motherLastName = null, DateTime? birthDate = null, string? birthState = null)
        {
            var query = _demoOneContext.People!.AsNoTracking();

            Expression<Func<ModelPerson, bool>> filter1 = MakeExpression2(personId, firstName, fatherLastName, motherLastName, birthDate, birthState);

            var first = await query.Select(p => new ModelPerson
            {
                PersonId = p.PersonId,
                FirstName = p.FirstName,
                FatherLastName = p.FatherLastName,
                MotherLastName = p.MotherLastName,
                BirthDate = p.BirthDate,
                BirthState = p.BirthState

            }).FirstOrDefaultAsync(filter1);

            return first;
        }

        public async Task<List<ModelPerson>> Select()
        {
            var people = await _demoOneContext.People!.Select(p => new ModelPerson
            {
                PersonId = p.PersonId,
                FirstName = p.FirstName,
                FatherLastName = p.FatherLastName,
                MotherLastName = p.MotherLastName,
                BirthDate = p.BirthDate,
                BirthState = p.BirthState

            }).ToListAsync();

            return people;
        }
        private Expression<Func<DbPerson, bool>> MakeExpression1(Guid? personId = null, string? firstName = null, string? fatherLastName = null,
            string? motherLastName = null, DateTime? birthDate = null, string? birthState = null)
        {
            Expression<Func<DbPerson, bool>> filter1 = null;
            Expression<Func<DbPerson, bool>> filter2 = null;
            Expression<Func<DbPerson, bool>> filterCombined;

            if (personId.HasValue)
                filter1 = p => p.PersonId == personId;

            if (!string.IsNullOrEmpty(firstName))
            {
                if (filter1 != null)
                {
                    filter2 = p => p.FirstName == firstName;
                    filterCombined = filter1.And(filter2);
                    filter1 = filterCombined;
                }
                else
                {
                    filter1 = p => p.FirstName == firstName;
                }
            }

            if (!string.IsNullOrEmpty(fatherLastName))
            {
                if (filter1 != null)
                {
                    filter2 = p => p.FatherLastName == fatherLastName;
                    filterCombined = filter1.And(filter2);
                    filter1 = filterCombined;
                }
                else
                {
                    filter1 = p => p.FatherLastName == fatherLastName;
                }
            }

            if (!string.IsNullOrEmpty(motherLastName))
            {
                if (filter1 != null)
                {
                    filter2 = p => p.MotherLastName == motherLastName;
                    filterCombined = filter1.And(filter2);
                    filter1 = filterCombined;
                }
                else
                {
                    filter1 = p => p.MotherLastName == motherLastName;
                }
            }

            if (birthDate.HasValue)
            {
                if (filter1 != null)
                {
                    filter2 = p => p.BirthDate == birthDate;
                    filterCombined = filter1.And(filter2);
                    filter1 = filterCombined;
                }
                else
                {
                    filter1 = p => p.BirthDate == birthDate;
                }
            }

            if (!string.IsNullOrEmpty(birthState))
            {
                if (filter1 != null)
                {
                    filter2 = p => p.BirthState == birthState;
                    filterCombined = filter1.And(filter2);
                    filter1 = filterCombined;
                }
                else
                {
                    filter1 = p => p.BirthState == birthState;
                }
            }
            return filter1;
        }

        private Expression<Func<ModelPerson, bool>> MakeExpression2(Guid? personId = null, string? firstName = null, string? fatherLastName = null,
        string? motherLastName = null, DateTime? birthDate = null, string? birthState = null)
        {
            Expression<Func<ModelPerson, bool>> filter1 = null;
            Expression<Func<ModelPerson, bool>> filter2 = null;
            Expression<Func<ModelPerson, bool>> filterCombined;

            if (personId.HasValue)
                filter1 = p => p.PersonId == personId;

            if (!string.IsNullOrEmpty(firstName))
            {
                if (filter1 != null)
                {
                    filter2 = p => p.FirstName == firstName;
                    filterCombined = filter1.And(filter2);
                    filter1 = filterCombined;
                }
                else
                {
                    filter1 = p => p.FirstName == firstName;
                }
            }

            if (!string.IsNullOrEmpty(fatherLastName))
            {
                if (filter1 != null)
                {
                    filter2 = p => p.FatherLastName == fatherLastName;
                    filterCombined = filter1.And(filter2);
                    filter1 = filterCombined;
                }
                else
                {
                    filter1 = p => p.FatherLastName == fatherLastName;
                }
            }

            if (!string.IsNullOrEmpty(motherLastName))
            {
                if (filter1 != null)
                {
                    filter2 = p => p.MotherLastName == motherLastName;
                    filterCombined = filter1.And(filter2);
                    filter1 = filterCombined;
                }
                else
                {
                    filter1 = p => p.MotherLastName == motherLastName;
                }
            }

            if (birthDate.HasValue)
            {
                if (filter1 != null)
                {
                    filter2 = p => p.BirthDate == birthDate;
                    filterCombined = filter1.And(filter2);
                    filter1 = filterCombined;
                }
                else
                {
                    filter1 = p => p.BirthDate == birthDate;
                }
            }

            if (!string.IsNullOrEmpty(birthState))
            {
                if (filter1 != null)
                {
                    filter2 = p => p.BirthState == birthState;
                    filterCombined = filter1.And(filter2);
                    filter1 = filterCombined;
                }
                else
                {
                    filter1 = p => p.BirthState == birthState;
                }
            }
            return filter1;
        }
    }
    public static class Utility
    {
        public static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
        {
            // build parameter map (from parameters of second to parameters of first)
            var map = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] }).ToDictionary(p => p.s, p => p.f);

            // replace parameters in the second lambda expression with parameters from the first
            var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);

            // apply composition of lambda expression bodies to parameters from the first expression 
            return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.And);
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.Or);
        }
    }
    public class ParameterRebinder : ExpressionVisitor
    {
        private readonly Dictionary<ParameterExpression, ParameterExpression> map;

        public ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
        {
            this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
        }

        public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
        {
            return new ParameterRebinder(map).Visit(exp);
        }
        protected override Expression VisitParameter(ParameterExpression p)
        {
            ParameterExpression replacement;
            if (map.TryGetValue(p, out replacement))
            {
                p = replacement;
            }

            return base.VisitParameter(p);
        }

    }
}