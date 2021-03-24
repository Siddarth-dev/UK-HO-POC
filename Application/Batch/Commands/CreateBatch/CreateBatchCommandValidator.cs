using FluentValidation;

namespace Application.Batch.Commands.CreateBatch
{
    public class CreateBatchCommandValidator : AbstractValidator<CreateBatchCommand>
    {
        public CreateBatchCommandValidator()
        {
            RuleFor(v => v.BusinessUnit).NotEmpty().NotNull();
        }
    }
}