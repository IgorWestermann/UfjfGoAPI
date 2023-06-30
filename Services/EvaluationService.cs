using UfjfGoAPI.DAL;
using UfjfGoAPI.Domain.DTO.Evaluations;
using UfjfGoAPI.Domain.Entity;
using UfjfGoAPI.Services.Base;

namespace UfjfGoAPI.Services
{
    public class EvaluationService
    {
        private readonly AppDbContext _db;

        public EvaluationService(AppDbContext db)
        {
            this._db = db;
        }

        public ServiceResponse<EvaluationResponse> CreateEvaluation(EvaluationCreateRequest model)
        {
            var result = _db.Users.Where(user => user.Id == model.IdUser).FirstOrDefault();

            if (result == null)
                return new ServiceResponse<EvaluationResponse>("User not found");

            var newEvaluation = new Evaluation()
            {
                IdUser = model.IdUser,
                Rate = model.Rate,
                Content = model.Content,
            };

            _db.Add(newEvaluation);
            _db.SaveChanges();

            return new ServiceResponse<EvaluationResponse>(new EvaluationResponse(newEvaluation));
        }
    }
}
