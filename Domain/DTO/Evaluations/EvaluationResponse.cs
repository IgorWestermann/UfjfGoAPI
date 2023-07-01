using UfjfGoAPI.Domain.Entity;

namespace UfjfGoAPI.Domain.DTO.Evaluations
{
    public class EvaluationResponse
    {
        public int EvaluationId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public int Rate { get; set; }

        public EvaluationResponse(Evaluation evaluations)
        {
            EvaluationId = evaluations.EvaluationId;
            UserId = evaluations.UserId;
            Content = evaluations.Content;
            Rate = evaluations.Rate;
        }
    }
}
