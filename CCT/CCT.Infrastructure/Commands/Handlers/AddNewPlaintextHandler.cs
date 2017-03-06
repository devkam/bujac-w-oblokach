using CCT.Infrastructure.Repository;

namespace CCT.Infrastructure.Commands.Handlers
{
    public class AddNewPlaintextHandler : ICommandHandler<AddNewPlaintextCommand, int>
    {
        private readonly IPlaintextRepository _plaintextRepository;

        public AddNewPlaintextHandler(IPlaintextRepository plainTextRepository) {
            _plaintextRepository = plaintextRepository;
        }

        public int Handle(AddNewPlaintextCommand command)
        {

        }
    }
}
