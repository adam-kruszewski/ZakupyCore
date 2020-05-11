namespace Kruchy.Core.Cryptography
{
    public interface IAesKeyProvider
    {
        byte[] GetKey();

        byte[] GetIV();
    }
}