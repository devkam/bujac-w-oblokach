using CCT.Infrastructure.Repository;

namespace CCT.Infrastructure.Commands.Handlers
{
    public class AddNewPlaintextHandler : ICommandHandler<AddNewPlaintextCommand, int>
    {
        private readonly IPlaintextRepository _plaintextRepository;

        public AddNewPlaintextHandler(IPlaintextRepository plaintextRepository) {
            _plaintextRepository = plaintextRepository;
        }

        public int Execute(AddNewPlaintextCommand command)
        {
            return _plaintextRepository.Add(new Entity.Plaintext
            {
                Content = command.Content
            });
        }
    }
}
