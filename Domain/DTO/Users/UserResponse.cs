using UfjfGoAPI.Domain.DTO.Evaluations;
using UfjfGoAPI.Domain.Entity;

namespace UfjfGoAPI.Domain.DTO.Users
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Password { get; set; }
        public string? Matricula { get; set; }
        public string? Curso { get; set; }
        public string? Phone { get; set; }
        public string? Photo { get; set; }
        public string? Cnh { get; set; }
        public int User_type_id { get; set; }

        public List<EvaluationResponse> Evaluations { get; set; }

        public UserResponse(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
            Password = user.Password;
            Matricula = user.Matricula;
            Curso = user.Curso;
            Phone = user.Phone;
            Photo = user.Photo;
            Cnh = user.Cnh;
            User_type_id = user.User_type_id;
            if (user.Evaluations != null && user.Evaluations.Any())
            {
                Evaluations = new List<EvaluationResponse>();
                Evaluations.AddRange(user.Evaluations.Select(x => new EvaluationResponse(x)));
            }
        }
    }

}
