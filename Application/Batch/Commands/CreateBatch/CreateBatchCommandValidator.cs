using Application.Batch.Queries.GetBatchDetail;
using FluentValidation;

namespace Application.Batch.Commands.CreateBatch
{
    public class CreateBatchCommandValidator : AbstractValidator<CreateBatchCommand>
    {
        public CreateBatchCommandValidator()
        {
            RuleFor(v => v.BusinessUnit).NotEmpty().NotNull();
            RuleFor(v => v.Attributes).NotEmpty().NotNull();
            RuleForEach(v => v.Attributes).SetValidator(new BatchAttributeValidator());
        }
    }

    public class BatchAttributeValidator : AbstractValidator<BatchAttributeDetailModel>
    {
        public BatchAttributeValidator()
        {
            RuleFor(v => v.Key).NotEmpty().NotEmpty().NotNull();
            RuleFor(v => v.Value).NotEmpty().NotEmpty().NotNull();
        }
    }
}