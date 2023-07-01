using Microsoft.EntityFrameworkCore;
using UfjfGoAPI.DAL;
using UfjfGoAPI.Domain.DTO.Users;
using UfjfGoAPI.Domain.Entity;
using UfjfGoAPI.Services.Base;

namespace UfjfGoAPI.Services
{
    public class UserService
    {
        private readonly AppDbContext _db;

        public UserService(AppDbContext db)
        {
            this._db = db;
        }

        public ServiceResponse<UserResponse> CreateNewUser(UserCreateRequest request)
        {
            var newUser = new User()
            {
                Name = request.Name,
                Email = request.Email,
                Password = request.Password,
                Matricula = request.Matricula,
                Curso = request.Curso,
                Phone = request.Phone,
                Photo = request.Photo,
                Cnh = request.Cnh,
                User_type_id = request.User_type_id,
            };
            _db.Add(newUser);
            _db.SaveChanges();

            return new ServiceResponse<UserResponse>(new UserResponse(newUser));
        }

        public IEnumerable<UserResponse>? Find()
        {
            var result = _db.Users
                .Include(x => x.Evaluations)
                .Include(y => y.Rides)
                .ToList();

            IEnumerable<UserResponse> userList = result.Select(x => new UserResponse(x));

            return userList;
        }

        public ServiceResponse<UserResponse> FindById(int id)
        {
            var result = _db.Users.Where(user => user.Id == id).FirstOrDefault();

            if (result == null)
                return new ServiceResponse<UserResponse>("User not found");

            return new ServiceResponse<UserResponse>(new UserResponse(result));
        }

        public ServiceResponse<UserResponse> FindByName(string name)
        {
            var result = _db.Users.Where(user => user.Name.ToLower() == name.ToLower()).FirstOrDefault();

            if (result == null)
                return new ServiceResponse<UserResponse>("User not found");

            return new ServiceResponse<UserResponse>(new UserResponse(result));
        }

        public ServiceResponse<UserResponse> Edit(int id, UserUpdateRequest request)
        {
            var result = _db.Users.Where(user => user.Id == id).FirstOrDefault();

            if (result == null)
                return new ServiceResponse<UserResponse>("User not found");

            result.Password = request.Password;
            result.Photo = request.Photo;
            result.Cnh = request.Cnh;

            _db.Users.Add(result).State = EntityState.Modified;
            _db?.SaveChanges();

            return new ServiceResponse<UserResponse>(new UserResponse(result));
        }

        public ServiceResponse<bool> Delete(int id)
        {
            var result = _db.Users.Where(user => user.Id == id).FirstOrDefault();

            if (result == null)
                return new ServiceResponse<bool>("User not found");

            _db?.Users.Remove(result);
            _db?.SaveChanges();

            return new ServiceResponse<bool>(true);
        }


    }
}
