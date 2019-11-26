using System.Collections.Generic;
using System.Threading.Tasks;
using TriVagas.Domain.Interfaces;
using TriVagas.Domain.Models;
using TriVagas.Services.Interfaces;
using TriVagas.Services.Notify;
using TriVagas.Services.Requests;
using TriVagas.Services.Responses;

namespace TriVagas.Services.Services
{

    public class ClassService : BaseService , IClassService
    {
        private readonly IClassRepository _classRepository;

        public ClassService( 
            IClassRepository classRepository,
            INotify notify) : base(notify)
        {
            _classRepository = classRepository;
        }

        public async Task<List<Class>> GetAll()
        {
            return await _classRepository.GetAll();
        }

        public async Task<ClassResponse> GetById(int id)
        {
            var classs = await _classRepository.GetById(id);
            return new ClassResponse()
            {
                Id = classs.Id,
                Name = classs.Name
            };
        }

        public async Task<ClassResponse> Register(CreateClassRequest request, User user)
        {
            if (user == null) 
                Notify("User not found");

            if (!HasNotification())
            {
                var newClass = new Class(request.Name, user);
                var createdClass = await _classRepository.Add(newClass);

                return new ClassResponse()
                {
                    Id = createdClass.Id,
                    Name = createdClass.Name
                };
            }
            else
                return null;
        }

        public async Task<bool> Remove(int id)
        {
            return await _classRepository.Remove(id);
        }

        public Task<ClassResponse> Update(CreateClassRequest request, User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
