namespace Atarraya.Tests.One.Data.Repositories
{

    using Microsoft.EntityFrameworkCore;
    using DbPerson = Entities.Person;
    using ModelPerson = Models.Person;
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
            var any = _demoOneContext.People!.Where(m=>
                 m.FirstName == firstName ||
                 m.FatherLastName == fatherLastName ||
                 m.MotherLastName == motherLastName ||
                 m.BirthDate == birthDate ||
                 m.BirthState == birthState
                ).AsNoTracking().Any();
            
            return any;
        }

        public async Task<ModelPerson?> First(Guid? personId = null, string? firstName = null, string? fatherLastName = null,
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

            var first = await query.Select(p => new ModelPerson
            {
                PersonId = p.PersonId,
                FirstName = p.FirstName,
                FatherLastName = p.FatherLastName,
                MotherLastName = p.MotherLastName,
                BirthDate = p.BirthDate,
                BirthState = p.BirthState

            }).FirstOrDefaultAsync();

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
    }
}