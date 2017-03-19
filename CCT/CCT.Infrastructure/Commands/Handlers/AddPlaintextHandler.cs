using CCT.Infrastructure.Repository;

namespace CCT.Infrastructure.Commands.Handlers
{
    public class AddPlaintextHandler : ICommandHandler<AddPlaintextCommand>
    {
        private readonly IPlaintextRepository _plaintextRepository;

        public AddPlaintextHandler(IPlaintextRepository plaintextRepository) {
            _plaintextRepository = plaintextRepository;
        }

        public void Handle(AddPlaintextCommand command)
        {
            _plaintextRepository.Add(new Entity.Plaintext
            {
                Content = command.Content
            });
        }
    }
}
