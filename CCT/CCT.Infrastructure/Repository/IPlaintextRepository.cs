using CCT.Infrastructure.Entity;

namespace CCT.Infrastructure.Repository
{
    public interface IPlaintextRepository
    {
        PlaintextEntity GetById(int plaintextId);
        int Add(PlaintextEntity plaintext);
    }
}
