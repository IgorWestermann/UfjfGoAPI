using UfjfGoAPI.Domain.Entity;

namespace UfjfGoAPI.Domain.DTO.Evaluations
{
    public class EvaluationResponse
    {
        public int IdEvaluation { get; set; }
        public int IdUser { get; set; }
        public string Content { get; set; }
        public int Rate { get; set; }

        public EvaluationResponse(Evaluation evaluations)
        {
            IdEvaluation = evaluations.IdEvaluation;
            IdUser = evaluations.IdUser;
            Content = evaluations.Content;
            Rate = evaluations.Rate;
        }
    }
}
