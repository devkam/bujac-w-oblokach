using CCT.Infrastructure.Entity;

namespace CCT.Infrastructure.Repository
{
    public interface IPlaintextRepository
    {
        Plaintext GetById(int plaintextId);
        int Add(Plaintext plaintext);
    }
}
