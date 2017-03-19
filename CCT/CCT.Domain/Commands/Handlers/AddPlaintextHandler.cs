using CCT.Domain.Repositories;

namespace CCT.Domain.Commands.Handlers
{
    public class AddPlaintextHandler : ICommandHandler<AddPlaintextCommand>
    {
        private readonly IPlaintextRepository _plaintextRepository;

        public AddPlaintextHandler(IPlaintextRepository plaintextRepository) {
            _plaintextRepository = plaintextRepository;
        }

        public void Handle(AddPlaintextCommand command)
        {
            _plaintextRepository.Add(new Domain.Plaintext
            {
                Content = command.Content
            });
        }
    }
}
